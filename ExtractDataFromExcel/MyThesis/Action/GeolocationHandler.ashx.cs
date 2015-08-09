using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace MyThesis.Action
{

    /// <summary>
    /// GeolocationHandler 的摘要说明
    /// </summary>
    public class GeolocationHandler : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest || context.IsWebSocketRequestUpgrading)
            {
                context.AcceptWebSocketRequest(new G_Location_Handler());
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