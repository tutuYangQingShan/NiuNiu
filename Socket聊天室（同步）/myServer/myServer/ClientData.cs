/*
 * 由SharpDevelop创建。
 * 用户： aico
 * 日期: 2017-5-3
 * 时间: 10:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Net.Sockets;

namespace myServer
{
	/// <summary>
	/// Description of ClientData.用来储存在线用户数据
	/// </summary>
	public class ClientData
	{
        //客户端数据
        public Socket Client;
        //用户ID
        public string id;
        //用户名
        public string name;  
		
	}
}
