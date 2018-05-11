/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2017-3-23
 * 时间: 15:31
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace myServer
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbIP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lstRunningInfo = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnStop);
			this.groupBox1.Controls.Add(this.btnStart);
			this.groupBox1.Controls.Add(this.txtPort);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cmbIP);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 31);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(617, 77);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Server Setting";
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(497, 28);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(97, 23);
			this.btnStop.TabIndex = 5;
			this.btnStop.Text = "Stop Server";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(375, 28);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(99, 23);
			this.btnStart.TabIndex = 4;
			this.btnStart.Text = "Start Server";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(277, 30);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(76, 21);
			this.txtPort.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(229, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port:";
			// 
			// cmbIP
			// 
			this.cmbIP.Location = new System.Drawing.Point(80, 30);
			this.cmbIP.Name = "cmbIP";
			this.cmbIP.Size = new System.Drawing.Size(131, 21);
			this.cmbIP.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server IP:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lstRunningInfo);
			this.groupBox2.Location = new System.Drawing.Point(12, 127);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(617, 269);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Running Info";
			// 
			// lstRunningInfo
			// 
			this.lstRunningInfo.FormattingEnabled = true;
			this.lstRunningInfo.ItemHeight = 12;
			this.lstRunningInfo.Location = new System.Drawing.Point(7, 21);
			this.lstRunningInfo.Name = "lstRunningInfo";
			this.lstRunningInfo.Size = new System.Drawing.Size(604, 232);
			this.lstRunningInfo.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(641, 416);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "myServer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox lstRunningInfo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox cmbIP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
