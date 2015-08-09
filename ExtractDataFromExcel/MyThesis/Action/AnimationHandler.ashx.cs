using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
namespace MyThesis.Action
{
    /// <summary>
    /// AnimationHandler 的摘要说明
    /// </summary>
    public class AnimationHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           if (context.IsWebSocketRequest || context.IsWebSocketRequestUpgrading)
            {
                context.AcceptWebSocketRequest(new Broadcaster());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}