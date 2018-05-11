/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2016-12-9
 * 时间: 10:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace myClient
{
	partial class LoginForm
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
			this.UserIDlabel = new System.Windows.Forms.Label();
			this.UserPwdlabel = new System.Windows.Forms.Label();
			this.UserIDtextBox = new System.Windows.Forms.TextBox();
			this.UserPwdtextBox = new System.Windows.Forms.TextBox();
			this.RegisterlinkLabel = new System.Windows.Forms.LinkLabel();
			this.GetBacklinkLabel = new System.Windows.Forms.LinkLabel();
			this.Loginbutton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// UserIDlabel
			// 
			this.UserIDlabel.Location = new System.Drawing.Point(67, 154);
			this.UserIDlabel.Name = "UserIDlabel";
			this.UserIDlabel.Size = new System.Drawing.Size(42, 23);
			this.UserIDlabel.TabIndex = 0;
			this.UserIDlabel.Text = "帐号：";
			// 
			// UserPwdlabel
			// 
			this.UserPwdlabel.Location = new System.Drawing.Point(67, 210);
			this.UserPwdlabel.Name = "UserPwdlabel";
			this.UserPwdlabel.Size = new System.Drawing.Size(42, 23);
			this.UserPwdlabel.TabIndex = 1;
			this.UserPwdlabel.Text = "密码：";
			// 
			// UserIDtextBox
			// 
			this.UserIDtextBox.Location = new System.Drawing.Point(115, 151);
			this.UserIDtextBox.Name = "UserIDtextBox";
			this.UserIDtextBox.Size = new System.Drawing.Size(152, 21);
			this.UserIDtextBox.TabIndex = 2;
			// 
			// UserPwdtextBox
			// 
			this.UserPwdtextBox.Location = new System.Drawing.Point(115, 207);
			this.UserPwdtextBox.Name = "UserPwdtextBox";
			this.UserPwdtextBox.Size = new System.Drawing.Size(152, 21);
			this.UserPwdtextBox.TabIndex = 3;
			// 
			// RegisterlinkLabel
			// 
			this.RegisterlinkLabel.Location = new System.Drawing.Point(292, 154);
			this.RegisterlinkLabel.Name = "RegisterlinkLabel";
			this.RegisterlinkLabel.Size = new System.Drawing.Size(134, 23);
			this.RegisterlinkLabel.TabIndex = 4;
			this.RegisterlinkLabel.TabStop = true;
			this.RegisterlinkLabel.Text = "还没有帐号，申请一个";
			this.RegisterlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegisterlinkLabelLinkClicked);
			// 
			// GetBacklinkLabel
			// 
			this.GetBacklinkLabel.Location = new System.Drawing.Point(292, 210);
			this.GetBacklinkLabel.Name = "GetBacklinkLabel";
			this.GetBacklinkLabel.Size = new System.Drawing.Size(134, 23);
			this.GetBacklinkLabel.TabIndex = 5;
			this.GetBacklinkLabel.TabStop = true;
			this.GetBacklinkLabel.Text = "忘了密码";
			this.GetBacklinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GetBacklinkLabelLinkClicked);
			// 
			// Loginbutton
			// 
			this.Loginbutton.Location = new System.Drawing.Point(192, 278);
			this.Loginbutton.Name = "Loginbutton";
			this.Loginbutton.Size = new System.Drawing.Size(75, 23);
			this.Loginbutton.TabIndex = 6;
			this.Loginbutton.Text = "登录";
			this.Loginbutton.UseVisualStyleBackColor = true;
			this.Loginbutton.Click += new System.EventHandler(this.LoginbuttonClick);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(67, 84);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(322, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "只需要输入帐号，密码留空 即可登录";
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(473, 360);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Loginbutton);
			this.Controls.Add(this.GetBacklinkLabel);
			this.Controls.Add(this.RegisterlinkLabel);
			this.Controls.Add(this.UserPwdtextBox);
			this.Controls.Add(this.UserIDtextBox);
			this.Controls.Add(this.UserPwdlabel);
			this.Controls.Add(this.UserIDlabel);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用户登录";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginFormFormClosed);
			this.Load += new System.EventHandler(this.LoginFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Loginbutton;
		private System.Windows.Forms.LinkLabel GetBacklinkLabel;
		private System.Windows.Forms.LinkLabel RegisterlinkLabel;
		private System.Windows.Forms.TextBox UserPwdtextBox;
		private System.Windows.Forms.TextBox UserIDtextBox;
		private System.Windows.Forms.Label UserPwdlabel;
		private System.Windows.Forms.Label UserIDlabel;
	}
}
