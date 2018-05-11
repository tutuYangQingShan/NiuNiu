/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2017-3-23
 * 时间: 15:31
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace myServer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private ServerControl servercontrol;
        
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
		
		void MainFormLoad(object sender, EventArgs e)
		{
			servercontrol=new ServerControl();
			servercontrol._Senddata+=new ServerControl.TransmitData(this.MsgWriteLine);
			this.btnStop.Enabled=false;
            this.cmbIP.Text="127.0.0.1";
            this.txtPort.Text = "18888";
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
            servercontrol.Start(cmbIP.Text,int.Parse(txtPort.Text));
            this.AddRunningInfo(">> " + DateTime.Now.ToString() + " Server 启动成功.");
            btnStart.Enabled = false;
            
            btnStop.Enabled = true;
		}
		
		void BtnStopClick(object sender, EventArgs e)
		{
            servercontrol.Stop();
            this.AddRunningInfo(">> " + DateTime.Now.ToString() + " Server 关闭");
            btnStart.Enabled = true;
            btnStop.Enabled = false;
		}

		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			servercontrol.Stop();
		}
		
		private void AddRunningInfo(string message)
        {
            lstRunningInfo.BeginUpdate();
            lstRunningInfo.Items.Insert(0, message);

            if (lstRunningInfo.Items.Count > 100)
            {
                lstRunningInfo.Items.RemoveAt(100);
            }

            lstRunningInfo.EndUpdate();
        }
		
		//接收ServerControl委托消息
		public void MsgWriteLine(int type,string str){
			
			this.AddRunningInfo(">> " + DateTime.Now.ToString() + str);
		}
	}
}
