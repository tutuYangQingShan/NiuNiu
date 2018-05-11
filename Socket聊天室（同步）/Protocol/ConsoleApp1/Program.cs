using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public delegate void Dele(object sender, System.EventArgs e);
       
        public class DeleClass
        {
            public void deleMain(object sender, System.EventArgs e)
            {
                Console.WriteLine("你好明天,我的envet整合delegate成功了！");

            }
            public void DeleMain1(object sender, System.EventArgs e)
            {
                for (int i=0;i<100; i++) {
                    Console.WriteLine("你好，这是列对里面的第二个事件！");
                }
              
            }
        }

        //声明DeleClass类
        public DeleClass DeleClassMain;
        //使用event定义事件对象

        public event Dele DeleEvent;

        public Program()
        {
            DeleClassMain = new DeleClass();
            //操作+=向事件列队里面添加事件
            this.DeleEvent += new Dele(DeleClassMain.deleMain);
            this.DeleEvent += new Dele(DeleClassMain.DeleMain1);
        }
        //以调用delegate的方式触发函数
        protected void deleTest(System.EventArgs e)
        {
            if (DeleEvent != null)
            {
                DeleEvent(this, e);
            }
        }
        public void chufa()
        {
            EventArgs e = new EventArgs();
            //触发事件
            deleTest(e);
        }
        static void Main(string[] args)
        {

            Program ev = new Program();
            ev.chufa();

        }

    } }

