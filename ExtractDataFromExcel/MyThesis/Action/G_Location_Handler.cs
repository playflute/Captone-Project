using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
using System.Security.Cryptography;
namespace MyThesis.Action
{
    public class Coordinate
    {
        private String lat;

        public String Lat
        {
            get { return lat; }
            set { lat = value; }
        }
        private String lng;

        public String Lng
        {
            get { return lng; }
            set { lng = value; }
        }
        private String flag;

        public String Flag
        {
            get { return flag; }
            set { flag = value; }
        }
    }
    public class G_Location_Handler : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();
        private static List<Coordinate> geo_coordinates = new List<Coordinate>();
        public override void OnOpen()
        {

            clients.Add(this);

        }
        public override void OnMessage(string message)
        {
            
            Coordinate coordinate=null;
            clients.Add(this);
            if(message!=null)
            {
                if(message=="m")
                {
                    //geo_coordinates.Clear();
                    clients.Broadcast("gather_all");
                }
                else
                {
                    coordinate = Newtonsoft.Json.JsonConvert.DeserializeObject<Coordinate>(message);
                }
               
            }
            if(coordinate!=null)
            {
                if(coordinate.Flag=="n")//means new user comes
                {
                    //do something

                    geo_coordinates.Add(coordinate);
                    clients.Broadcast(Newtonsoft.Json.JsonConvert.SerializeObject(geo_coordinates));
                }


            }

            




        }
        public override void OnClose()
        {
            geo_coordinates.Clear();
            clients.Broadcast("one_guy_quit");
            base.OnClose();
        }
        public override void OnError()
        {
            base.OnError();
        }
    }
}