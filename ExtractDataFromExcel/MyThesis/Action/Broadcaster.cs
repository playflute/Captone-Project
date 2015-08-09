using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
using System.Security.Cryptography;
namespace MyThesis.Action
{
    public class Broadcaster : WebSocketHandler
    {
        public static int count = 0;
        private static WebSocketCollection clients = new WebSocketCollection();
        //private WebSocketCollection clients;
        public override void OnOpen()
        {
            clients.Add(this);
            if (count < 1)
            {
                //clients = new WebSocketCollection();
                //实例化Timer类，设置间隔时间为3000毫秒；
                System.Timers.Timer t = new System.Timers.Timer(3000);
                //到达时间的时候执行事件；
                t.Elapsed += new System.Timers.ElapsedEventHandler(theout);
                //设置是执行一次（false）还是一直执行(true)
                t.AutoReset = true;
                //是否执行System.Timers.Timer.Elapsed事件；   
                t.Enabled = true;
                //clients.Add(this);
                count++;
            }




        }
        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {


            clients.Broadcast(Next(20).ToString());

        }
        public override void OnMessage(string message)
        {
            string msgBack = string.Format("You have sent {0} at {1}", message, DateTime.Now.ToLongTimeString());

            clients.Add(this);

            clients.Broadcast(msgBack);
            //this.Send(msgBack);
        }
        public override void OnClose()
        {
            base.OnClose();
        }
        public override void OnError()
        {
            base.OnError();
        }
        //生成真正的随机数，注意这个函数比较消耗资源
        private static RNGCryptoServiceProvider rngp = new RNGCryptoServiceProvider();
        private static byte[] rb = new byte[4];
        public static int Next(int max)
        {
            rngp.GetBytes(rb);
            int value = BitConverter.ToInt32(rb, 0);
            value = value % (max + 1);
            if (value < 0) value = -value; return value;
        } 
    }
}