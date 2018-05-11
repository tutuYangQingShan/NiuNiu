/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2017-5-3
 * 时间: 9:57
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Protocol
{
	/// <summary>
	/// Description of SysMsg.
	/// </summary>
	[Serializable]
	public class SysMsg
	{
		//消息类型
	    private int type=1;//0成功，1失败
	    public int Type{
			set{type=value;}
			get{return type;}
		}
	}
}
