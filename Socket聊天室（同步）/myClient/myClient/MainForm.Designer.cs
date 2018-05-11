/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2017-3-23
 * 时间: 16:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace myClient
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
			this.labelUserNum = new System.Windows.Forms.Label();
			this.UserlistBox = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lstChatInfo = new System.Windows.Forms.ListBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.comboBox_ReceiveName = new System.Windows.Forms.ComboBox();
			this.btQuit = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.UserInputBox = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelUserNum);
			this.groupBox1.Controls.Add(this.UserlistBox);
			this.groupBox1.Location = new System.Drawing.Point(438, 22);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(143, 398);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "在线用户：";
			// 
			// labelUserNum
			// 
			this.labelUserNum.Location = new System.Drawing.Point(31, 17);
			this.labelUserNum.Name = "labelUserNum";
			this.labelUserNum.Size = new System.Drawing.Size(89, 25);
			this.labelUserNum.TabIndex = 1;
			this.labelUserNum.Text = "（0）人在线";
			// 
			// UserlistBox
			// 
			this.UserlistBox.FormattingEnabled = true;
			this.UserlistBox.ItemHeight = 12;
			this.UserlistBox.Location = new System.Drawing.Point(7, 45);
			this.UserlistBox.Name = "UserlistBox";
			this.UserlistBox.Size = new System.Drawing.Size(130, 352);
			this.UserlistBox.TabIndex = 0;
			this.UserlistBox.SelectedIndexChanged += new System.EventHandler(this.UserlistBoxSelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lstChatInfo);
			this.groupBox2.Location = new System.Drawing.Point(5, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(427, 235);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "聊天信息：";
			// 
			// lstChatInfo
			// 
			this.lstChatInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.lstChatInfo.FormattingEnabled = true;
			this.lstChatInfo.ItemHeight = 12;
			this.lstChatInfo.Location = new System.Drawing.Point(7, 21);
			this.lstChatInfo.Name = "lstChatInfo";
			this.lstChatInfo.Size = new System.Drawing.Size(414, 208);
			this.lstChatInfo.TabIndex = 0;
			this.lstChatInfo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LstChatInfoDrawItem);
			this.lstChatInfo.SelectedIndexChanged += new System.EventHandler(this.LstChatInfoSelectedIndexChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.comboBox_ReceiveName);
			this.groupBox3.Controls.Add(this.btQuit);
			this.groupBox3.Controls.Add(this.btnSend);
			this.groupBox3.Controls.Add(this.UserInputBox);
			this.groupBox3.Location = new System.Drawing.Point(5, 270);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(427, 149);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "用户输入框：";
			// 
			// comboBox_ReceiveName
			// 
			this.comboBox_ReceiveName.FormattingEnabled = true;
			this.comboBox_ReceiveName.Location = new System.Drawing.Point(25, 32);
			this.comboBox_ReceiveName.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox_ReceiveName.Name = "comboBox_ReceiveName";
			this.comboBox_ReceiveName.Size = new System.Drawing.Size(99, 20);
			this.comboBox_ReceiveName.TabIndex = 4;
			// 
			// btQuit
			// 
			this.btQuit.Location = new System.Drawing.Point(229, 120);
			this.btQuit.Name = "btQuit";
			this.btQuit.Size = new System.Drawing.Size(71, 23);
			this.btQuit.TabIndex = 3;
			this.btQuit.Text = "退出";
			this.btQuit.UseVisualStyleBackColor = true;
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(335, 120);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(73, 23);
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "发送";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.BtnSendClick);
			// 
			// UserInputBox
			// 
			this.UserInputBox.Location = new System.Drawing.Point(65, 66);
			this.UserInputBox.Name = "UserInputBox";
			this.UserInputBox.Size = new System.Drawing.Size(344, 26);
			this.UserInputBox.TabIndex = 2;
			this.UserInputBox.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 469);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "聊天室";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox comboBox_ReceiveName;
		private System.Windows.Forms.Label labelUserNum;
		private System.Windows.Forms.Button btQuit;
		private System.Windows.Forms.RichTextBox UserInputBox;
		private System.Windows.Forms.ListBox UserlistBox;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox lstChatInfo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
