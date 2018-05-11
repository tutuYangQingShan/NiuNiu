/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2016-12-9
 * 时间: 10:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Protocol;
using IniFile_RW;

namespace myClient
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class LoginForm : Form
	{
		private ClientControl clientcontrol;
		public LoginForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void RegisterlinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			
			MessageBox.Show("非常抱歉，暂时未开放注册功能。","提示");

		}
		
		void GetBacklinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("非常抱歉，暂时未开放密码找回功能。","提示");
		}
		
		//用户登录
		void LoginbuttonClick(object sender, EventArgs e)
		{
			
			if(this.UserIDtextBox.Text==""){
				MessageBox.Show("用户ID不能为空","警告");
				return;
			}
			
			if(this.UserIDtextBox.Text=="所有人"){
				MessageBox.Show("不能使用 所有人 这个ID","警告");
				return;
			}
			
			this.Loginbutton.Enabled=false;
			
			//从配置文件System.ini中读取服务器的IP和端口
			IniFile_RW.OperateIniFile iniFile=new IniFile_RW.OperateIniFile();
			string path=Environment.CurrentDirectory;//获取当前程序路径
			string ip=iniFile.ReadIniData("Server","IP","NO",path+"\\System.ini");
			string prot=iniFile.ReadIniData("Server","PROT","NO",path+"\\System.ini");
			if(ip=="NO" || prot=="NO"){
				MessageBox.Show("配置文件读取失败！请检查"+path+"\\System.ini文件","提示");
				return;
			}
			
			//连接服务器
			if(!clientcontrol.Connect(ip,int.Parse(prot))){
				MessageBox.Show("连接服务器失败！","提示");
				Loginbutton.Enabled=true;
				
				return;
			}
			
			if(clientcontrol.UserLogin(UserIDtextBox.Text,UserPwdtextBox.Text)){
				MessageBox.Show("登录成功！","提示");
				this.Hide();//隐藏登录窗口
			    MainForm temp=new MainForm();
			    temp.ShowDialog();
		        this.Close();//关闭登录窗口
			}
			else{
				clientcontrol.CloseConnect();//断开连接
				MessageBox.Show("登录失败用户已在线，请换个用户名登录！","提示");
			}
			Loginbutton.Enabled=true;
		}
		
		void LoginFormLoad(object sender, EventArgs e)
		{
			clientcontrol=ClientControl.CreateInstance();
		}
		
		//关闭窗口时，把服务器连接关掉
		void LoginFormFormClosed(object sender, FormClosedEventArgs e)
		{
			//clientcontrol.CloseConnect();
		}
	}
}
