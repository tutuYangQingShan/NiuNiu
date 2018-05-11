/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2017-5-5
 * 时间: 15:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Protocol
{
	/// <summary>
	/// Description of UserData.
	/// </summary>
	[Serializable]
	public class UserData
	{
		private string id;  //用户ID
		private string name;//用户昵称
		
		public string Id{
			set{id=value;}
			get{return id;}
		}
		public string Name{
			set{name=value;}
			get{return name;}
		}
	}
}
