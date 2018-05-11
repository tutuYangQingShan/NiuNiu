/*
 * 由SharpDevelop创建。
 * 用户： kvqing
 * 日期: 2017/4/24
 * 时间: 22:04
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Protocol
{
	/// <summary>
	/// Description of UserInfo.
	/// </summary>
	[Serializable]
	public class UserInfo
	{
		private string name;
		private string pwd;
		
		public string Name{
			set{name=value;}
			get{return name;}
		}
		public string Pwd{
			set{pwd=value;}
			get{return pwd;}
		}
	}
}
