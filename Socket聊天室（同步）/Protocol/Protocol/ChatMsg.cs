/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2017-5-4
 * 时间: 13:57
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Protocol
{
	/// <summary>
	/// Description of ChatMsg.
	/// </summary>
	[Serializable]
	public class ChatMsg
	{
		private string sendName;    //发送者
		private string receiveName; //接受者
		private string content;     //内容
		
		public string SendName{
			set{sendName=value;}
			get{return sendName;}
		}
		
		public string ReceiveName{
			set{receiveName=value;}
			get{return receiveName;}
		}
		
		public string Content{
			set{content=value;}
			get{return content;}
		}
	}
}
