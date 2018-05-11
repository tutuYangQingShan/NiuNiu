/*
 * 由SharpDevelop创建。
 * 用户： kvqing
 * 日期: 2017/4/19
 * 时间: 20:47
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Collections.Generic;
using Protocol;
namespace myClient
{
	/// <summary>
	/// Description of ClientControl.
	/// </summary>
	public class ClientControl
	{
		#region 成员变量
		private  Socket clientSocket;
		
		public List<UserData> userList=new List<UserData>();//在线用户列表
		
		public string myName;
		
		private bool flag; //状态标识符 true连接中，false断开
		
		private volatile static ClientControl _instance = null;
        private static readonly object lockHelper = new object();
		
		//使用委托方法用于ClientControl和Form的数据传递
		public delegate void TransmitData(int type,string str); //定义委托类型
		
		public event TransmitData _Senddata; //定义委托对象
		
		#endregion
		
		public ClientControl(){}
		
		
		#region 对外接口，获取单例
		public static ClientControl CreateInstance() {
	        if(_instance == null)
	        {
	            lock(lockHelper)
	            {
	                if(_instance == null)
	                     _instance = new ClientControl();
	            }
	        }
	        return _instance;
	    }
		#endregion
		
		#region 连接服务器
		public bool Connect(string ip,int port){
			
			bool b=true;
			//AddressFamily.InterNetwork IPv4地址
			//SocketType.Stream          流式传输
			//ProtocolType.Tcp           协议类型
			clientSocket=new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
			try{
			    clientSocket.Connect(ip,port);
			}
			catch{
				
			    b=false;
			    
			    clientSocket=null;
			    
			}
			
		    return b;
		}
		#endregion
		
		#region 断开服务器连接
		public void CloseConnect(){
			
			this.flag=false;
			if(clientSocket!=null){
				clientSocket.Close();
			}
		}
		#endregion
		
		#region 用户登录 
		public bool UserLogin(string id,string pwd){
			
			bool b=false;
			ProtocolChat protocolChat1=new ProtocolChat();
			protocolChat1.model=1;
			protocolChat1.ope=2;
			UserInfo userInfo=new UserInfo();
			userInfo.Name=id;
			userInfo.Pwd=pwd;
			protocolChat1.data=userInfo;
			
			
			//向服务器发消息
		    this.Send(protocolChat1);
			//接受服务器消息
			var protocolChat2=this.Receive();
			
			if(protocolChat2.model==1 && protocolChat2.ope==2){
				SysMsg sysmsg=protocolChat2.data as SysMsg;
				if(sysmsg.Type==0){
					//登录成功！
					b=true;
					this.myName=id;//用户名字
					this.flag=true;
					//创建线程
					Thread threadHandlingMsg=new Thread(this.HandlingMsg);
				    //设置为后台线程
				    threadHandlingMsg.IsBackground=true;
				    //启动线程
				    threadHandlingMsg.Start();
				}
			}
		    return b;
		}
		#endregion
		
		#region 请求更新在线用户列表 
		public void UpdateUser(){
			ProtocolChat protocolChat=new ProtocolChat();
			protocolChat.model=2;
			protocolChat.ope=0;
			this.Send(protocolChat);
		}
		#endregion
		
		#region 聊天消息封装 
		public void ChatData(string receive,string content){
			ProtocolChat protocolChat=new ProtocolChat();
			protocolChat.model=2;
			protocolChat.ope=1;
			ChatMsg chatMsg=new ChatMsg();
			chatMsg.SendName=myName;
			chatMsg.ReceiveName=receive;
			chatMsg.Content=content;
			protocolChat.data=chatMsg;
			
			//向客户端发消息
		    this.Send(protocolChat);
		}
		#endregion
		
		#region 发送数据给服务器
		public void Send(ProtocolChat chat){
			
			//ProtocolGame对象转数据流
			//---------------------------------
			MemoryStream stream=new MemoryStream();
			
			BinaryFormatter formater=new BinaryFormatter();
			
			formater.Serialize(stream,chat);
			
			byte []msg=stream.GetBuffer();
			
			//---------------------------------
			//先发送数据包的长度
			clientSocket.Send(BitConverter.GetBytes(msg.Length));
			
			//再发送数据包
			clientSocket.Send(msg);
		}
		#endregion
		
		#region 监听服务器发来的数据 返回ProtocolChat对象
		public ProtocolChat Receive(){
		    
			//先接收消息的长度
			byte []datalen= new byte[4];
			clientSocket.Receive(datalen);
			int len=BitConverter.ToInt32(datalen, 0); 
			
			//按长度创建byte[]数组
			byte[] msg=new byte[len];
		
			int msglen=clientSocket.Receive(msg);
			
			//数据流转回ProtocolGame对象
			MemoryStream stream=new MemoryStream(msg,0,msglen);
			
			BinaryFormatter formater=new BinaryFormatter();
			
			var protocolChat=formater.Deserialize(stream) as ProtocolChat;
			
			return protocolChat;
		}
		#endregion	
		
		#region 服务器消息处理
		public void HandlingMsg(){
			
			while(this.flag){
				try{
                    //接收服务器消息
					var protocolChat=this.Receive();
					
					switch(protocolChat.model){
							
						case 1://用户
							switch(protocolChat.ope){
								case 1:    // 注册
									break;
								case 2:    // 登录
									SysMsg sysmsg=protocolChat.data as SysMsg;
									this.DataWriteLine(sysmsg.Type,"登录返回消息");
									break;
								case 3:    // 找回密码
									break;
								default:
									break;
							 }
							 break;
							
						case 2://聊天
							switch(protocolChat.ope){
							 		
							 	case 0://在线用户列表
							 		userList=protocolChat.data as List<UserData>;
							 		this.DataWriteLine(0,"更新列表");
							 		break;
							 		
								case 1:// 聊天消息
									ChatMsg chatMsg= protocolChat.data as ChatMsg;
									if(chatMsg.ReceiveName!=myName){
										this.DataWriteLine(1,"【"+chatMsg.SendName+"】说："+chatMsg.Content);
									}
									else{
										this.DataWriteLine(2,"【"+chatMsg.SendName+"】悄悄对你说："+chatMsg.Content);
									}
									break;
									
								case 2://用户上线
									var user1=protocolChat.data as UserData;
									userList.Add(user1);
									this.DataWriteLine(0,"更新列表");
									this.DataWriteLine(3,"系统消息：用户【"+user1.Id+"】上线了");
									break;
									
								case 3://用户下线
									var user2=protocolChat.data as UserData;
									for (int i=0; i<userList.Count;i++){
										if(userList[i].Id==user2.Id){
											userList.Remove(userList[i]);
											break;
										}
									}
									this.DataWriteLine(3,"系统消息：用户【"+user2.Id+"】下线了");
									this.DataWriteLine(0,"更新列表");
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
				//和服务器断开了
				catch{
					//这里当服务器关闭或网络中断时会出现异常
					this.DataWriteLine(4,"和服务器断开了");
					this.flag=false;
					break;
					
				}
			}
			//退出监听服务器消息
		}
		#endregion
		
		#region 向委托函数传递消息
		public void DataWriteLine(int type,string text){
			if(_Senddata!=null){
				_Senddata(type,text);//执行委托
			}
		}
		#endregion
	}
}
