/*
 * 由SharpDevelop创建。
 * 用户： kvqing
 * 日期: 2017/4/24
 * 时间: 21:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;

namespace Protocol
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	[Serializable]
	public class ProtocolChat
	{
		//模块
		public int model;
		//操作
		public int ope;
		//数据
		public object data;
		
	}
}