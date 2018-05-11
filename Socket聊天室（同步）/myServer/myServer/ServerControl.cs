/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2017-4-19
 * 时间: 14:45
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;//BinaryFormater
using Protocol;

namespace myServer
{
	/// <summary>
	/// Description of myServer.
	/// </summary>
	public class ServerControl
	{
        #region 成员变量
        //服务器状态标识符 true开启，false关闭
        private bool flag; 
		private Socket serverSocket;
		private Dictionary<string,ClientData> clientDic=new Dictionary<string, ClientData>();//在线用户字典
		
		//使用委托方法用于UserControl和Form的数据传递
		public delegate void TransmitData(int type,string str); //定义委托类型
		
		public event TransmitData _Senddata; //定义委托对象
		
		#endregion
		
		//类的构造函数
		public ServerControl(){}
		
		#region  启动服务器
        //IP:地址，Prot:端口号
		public void Start(string IP,int Prot){
			
			//AddressFamily.InterNetwork IPv4地址
			//SocketType.Stream          流式传输
			//ProtocolType.Tcp           协议类型
            //建立链接
            //1,socket()函数
			serverSocket=new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
			
			//绑定IP、端口
            //2，bind()函数
			IPAddress ip = IPAddress.Parse(IP); 

			serverSocket.Bind(new IPEndPoint(ip, Prot));
			
			//使用IPAddress.Any参数这个参数是使用本机可用的IP。
			//serverSocket.Bind(new IPEndPoint(IPAddress.Any,Prot));
			
			//设定最多50个排队连接请求 
            //3，Listen()函数
            serverSocket.Listen(50);  
            
            //服务器状态标识为开启
            this.flag=true;
            
            //接收客户端的方法serverSocket.Accept(); 会挂起当前线程(阻塞) 所以开子线程来处理
            //创建新线程
            //4，接收客户端传来的Accept()
            Thread threadAccept=new Thread(Accept);
            
            //设置为后台线程
            threadAccept.IsBackground=true;
            
            //启动线程
            threadAccept.Start();
		}
		#endregion
		
		#region 关闭服务器
		public void Stop(){
			
			//服务器状态标识为关闭
			this.flag=false;
			
			//强制client关闭
			foreach (var item in clientDic){
				item.Value.Client.Close();
			}
			//清空客户端列表
			clientDic.Clear();
			
			//关闭serverSocket
			if(serverSocket!=null){
			    serverSocket.Close();
			}
		}
		#endregion
		
		#region 监听客户端连接
		public void Accept(){
			
			while(this.flag){
				try{
					
					Socket client = serverSocket.Accept(); 
					IPEndPoint point=client.RemoteEndPoint as IPEndPoint;
					//point.Address 客户端IP
					//point.Port    客户端端口
					DataWriteLine(0,"["+point.Address+"]"+point.Port.ToString()+"连接服务器");
					
					//创建新线程 
		            Thread threadHandlingMsg=new Thread(HandlingMsg);
		            //设置为后台线程
		            threadHandlingMsg.IsBackground=true;
		            //启动线程
		            threadHandlingMsg.Start(client);
				}
				catch {}
		    }
		}
		#endregion	
		
		#region 监听客户端发过来的数据 返回ProtocolChat对象
		public ProtocolChat Receive(Socket client){
		
			//先接收消息的长度
		    byte []datalen=new byte[4];
			client.Receive(datalen);
			int len = BitConverter.ToInt32(datalen, 0); 
			
			//按长度创建byte[]数组
			byte[] msg=new byte[len];
			
			int msglen=client.Receive(msg);
			
			IPEndPoint point=client.RemoteEndPoint as IPEndPoint;
			
			DataWriteLine(0,"收到客户端["+point.Address+"]"+point.Port.ToString()+"发来的消息");
			
			//数据流转回ProtocolGame对象
			MemoryStream stream=new MemoryStream(msg,0,msglen);
			
			BinaryFormatter formater=new BinaryFormatter();
			
			var protocolChat=formater.Deserialize(stream) as ProtocolChat;
			
			return protocolChat;
		}
		#endregion	
		
		#region 客户端消息处理
		public void HandlingMsg(object obj){
			
			Socket client=obj as Socket;
			
			while(this.flag) {
				
				try{
					//接收客户端消息
					var protocolChat=Receive(client);
					
					switch(protocolChat.model){
							
						case 1://用户
							
							switch(protocolChat.ope){
								case 1://注册
									var userInfo1= protocolChat.data as UserInfo;//得到用户数据
									break;
								case 2://登录
									var userInfo2= protocolChat.data as UserInfo;
									
									//如果userInfo2.Name key键不存在
									if(!clientDic.ContainsKey(userInfo2.Name)){
									
										//用户登录成功！
										DataWriteLine(0,"["+userInfo2.Name+"]用户上线了……");
										ClientData clientdata=new ClientData();
										clientdata.Client=client;
										clientdata.id=userInfo2.Name;
										clientdata.name=userInfo2.Name;
										//当前客户端用户信息添加进在线用户字典
										clientDic.Add(userInfo2.Name,clientdata);
										
										SysMsg sysmsg=new SysMsg();
										sysmsg.Type=0;
										protocolChat.data=sysmsg;
										//向客户端发送登录成功消息
										Send(client,protocolChat);
										
										//广播通知所有客户端有用户上线
							    		protocolChat.model=2;//聊天
							    		protocolChat.ope=2;  //上线
							    		UserData user=new UserData();
							    		user.Id=userInfo2.Name;
							    		user.Name=userInfo2.Name;
							    		protocolChat.data=user;
							    		Broadcast(client,protocolChat);
									}
									else{
										SysMsg sysmsg=new SysMsg();
										sysmsg.Type=1;
										protocolChat.data=sysmsg;
										//向客户端发送登录失败消息
										Send(client,protocolChat);
										return ;
									}
									break;
									
								case 3://找回密码
									break;
								default:
									break;
							}
					
							break;
						case 2://聊天
							switch(protocolChat.ope){
									
								case 0://在线用户列表(客户端请求在线用户列表)
									List<UserData> userList=new List<UserData>();
									foreach(KeyValuePair<string,ClientData>kvp in clientDic) {
										UserData tempUserData=new UserData();
										tempUserData.Id=kvp.Value.id;
										tempUserData.Name=kvp.Value.name;
										userList.Add(tempUserData);
									}
									protocolChat.data=userList;
									Send(client,protocolChat);
									
									break;
									
								case 1://聊天消息
									var charMsg= protocolChat.data as ChatMsg;//得到用户数据
									if(charMsg.ReceiveName == "所有人"){
										DataWriteLine(0,"用户["+charMsg.SendName+"]说："+charMsg.Content);
										//向所有客户端广播消息
										Broadcast(client,protocolChat);
									}
									else{
										try{
											//如果charMsg.ReceiveName key键存在
									        if(clientDic.ContainsKey(charMsg.ReceiveName)){
												//向指定的人发送消息
											    DataWriteLine(0,"用户["+charMsg.SendName+"]悄悄地对["+charMsg.ReceiveName+"]说："+charMsg.Content);
											    Send(clientDic[charMsg.ReceiveName].Client,protocolChat);
										    }
										}
										catch{}
									}
									break;
									
								case 2:
									break;
								default:
									break;
							}
							break;
						case 3:
							break;
						default:
							break;
					}
			    }
				catch{
				    //如果出错和客户端断开 在线用户列表移除用户数据
				    foreach(KeyValuePair<string,ClientData>kvp in clientDic) {
				    	if(kvp.Value.Client == client ){
				    		//广播通知所有客户端有用户下线
				    		ProtocolChat chat=new ProtocolChat();
				    		chat.model=2;//聊天
				    		chat.ope=3;  //下线
				    		UserData user=new UserData();
				    		user.Id=kvp.Value.id;
				    		user.Name=kvp.Value.name;
				    		chat.data=user;
				    		Broadcast(client,chat);
				    		
				    		//客户端列表删除断开的用户
				    		clientDic.Remove(kvp.Key);
				    		DataWriteLine(0,"用户["+kvp.Value.name+"]下线了");
				    		
				    		break;
				    	}
				    }
				}
			}
		}
		#endregion
		
		#region 发送数据给客户端
		public void Send(Socket client,ProtocolChat chat){
			
			//ProtocolGame对象转数据流
			//---------------------------------
			MemoryStream stream=new MemoryStream();
			
			BinaryFormatter formater=new BinaryFormatter();
			
			formater.Serialize(stream,chat);
			
			byte []msg=stream.GetBuffer();
			//---------------------------------
			//先发送数据包的长度
			client.Send(BitConverter.GetBytes(msg.Length));
			//再发送数据包
			client.Send(msg);
		}
		#endregion
		
		#region  向客户端广播消息
		public void Broadcast(Socket client,ProtocolChat chat){
			
			foreach(KeyValuePair<string,ClientData>kvp in clientDic) {
				try {
					if(kvp.Value.Client!=client){
					    Send(kvp.Value.Client,chat);
					    IPEndPoint point =kvp.Value.Client.RemoteEndPoint as IPEndPoint;
					}
				}
				catch{
					DataWriteLine(0,"向用户发送消息失败！");
				}
			}
		}
		#endregion
		
		#region 向委托函数传递消息
		public void DataWriteLine(int type,string text){
			
			_Senddata(0,text);//执行委托
		}
		#endregion
	}
}
