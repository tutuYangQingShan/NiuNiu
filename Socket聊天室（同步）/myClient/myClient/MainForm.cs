/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2017-3-23
 * 时间: 16:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace myClient
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
	    private ClientControl clientcontrol;
	    
	    List< int> colorIndexList=new List<int>();//字体颜色索引
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnSendClick(object sender, EventArgs e)
		{
			if(UserInputBox.Text!=""){
				clientcontrol.ChatData(this.comboBox_ReceiveName.Text,UserInputBox.Text);
				if(this.comboBox_ReceiveName.Text=="所有人"){
					AddRunningInfo("【"+clientcontrol.myName+"】说："+UserInputBox.Text);
					this.colorIndexList.Add(4);
				}
				else{
					AddRunningInfo("你悄悄地对【"+this.comboBox_ReceiveName.Text+"】说："+UserInputBox.Text);
					this.colorIndexList.Add(2);
				}
				UserInputBox.Text="";
			}
		}

        private void AddRunningInfo(string message)
        {
            lstChatInfo.BeginUpdate();
            lstChatInfo.Items.Add(message);

            if (lstChatInfo.Items.Count > 100)
            {
                lstChatInfo.Items.RemoveAt(0);
                this.colorIndexList.RemoveAt(0);
            }

            lstChatInfo.EndUpdate();
        }
       
        void Sotp(){
        	
        	clientcontrol.CloseConnect();
        }
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.comboBox_ReceiveName.Items.Add("所有人");
			this.comboBox_ReceiveName.SelectedIndex=0;
			
            clientcontrol=ClientControl.CreateInstance();
            clientcontrol._Senddata+=new ClientControl.TransmitData(this.MsgWriteLine);
            this.Text=this.Text+"-"+clientcontrol.myName;
            clientcontrol.UpdateUser();//请求在线用户列表
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
		    Sotp();
		}
		
		//接收ServerControl发过来的数据
		public void MsgWriteLine(int type,string str){
			switch(type){
				
			    case 0://更新在线用户列表
			        UserlistBox.Items.Clear();
			        this.comboBox_ReceiveName.Items.Clear();
			        this.comboBox_ReceiveName.Items.Add("所有人");
			        this.comboBox_ReceiveName.SelectedIndex=0;
			        for(int i=0; i<clientcontrol.userList.Count; i++){
			        	
			        	UserlistBox.Items.Add(clientcontrol.userList[i].Name);
			        	this.comboBox_ReceiveName.Items.Add(clientcontrol.userList[i].Name);
			        }
			        labelUserNum.Text="（"+UserlistBox.Items.Count+"）人在线";
			        
			        break;
			        
			   case 1: //聊天消息添加到 lstChatInfo控件上
			        this.AddRunningInfo(str);
			        this.colorIndexList.Add(type);
			        break;
			        
			   case 2:
			        this.AddRunningInfo(str);
			        this.colorIndexList.Add(type);
			        break;
			        
			    case 3:
			        this.AddRunningInfo(str);
			        this.colorIndexList.Add(type);
			        break;
			   case 4:
			        MessageBox.Show("服务器断开了");
			        clientcontrol.CloseConnect();
			        this.Close();
			        break;
			        
			   default:
			        break;
			}
		}
		
		void UserlistBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboBox_ReceiveName.Text=UserlistBox.Text;
		}
		
		private void LstChatInfoDrawItem(object sender, DrawItemEventArgs e)
		{
		    e.DrawBackground(); 
            Color fontColor=Color.Black;           
            switch(this.colorIndexList[e.Index]){
            	case 0:
           		    fontColor=Color.Black;
           	        break;
           	    case 2:
           	        fontColor=Color.SpringGreen;
           	        break;
           	    case 3:
           	        fontColor=Color.Red; 
           	        break;
           	    case 4:
           	        fontColor=Color.Blue; 
           	        break;
           }
           e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, new SolidBrush(fontColor), e.Bounds);
           e.DrawFocusRectangle();  
		}
		
		void LstChatInfoSelectedIndexChanged(object sender, EventArgs e)
		{
			string pattern = @"(?<=【)([^】]+)";
			Match result = Regex.Match(this.lstChatInfo.Text,pattern);//单一捕获
			if(result!=null){
				for(int i=0;i<this.comboBox_ReceiveName.Items.Count;i++){
					if(result.ToString()==this.comboBox_ReceiveName.Items[i].ToString()){
						this.comboBox_ReceiveName.Text=result.ToString();
						break;
					}
				}
			}
		}
	}
}
