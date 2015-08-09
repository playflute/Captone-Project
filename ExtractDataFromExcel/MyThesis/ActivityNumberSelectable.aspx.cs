using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
namespace MyThesis
{
    public partial class ActivityNumberSelectable : System.Web.UI.Page
    {
        protected String start_str;
        protected String end_str;
        protected String start_str_for_easyui;
        protected String end_str_for_easyui;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Context.Session["User_Info"] == null) && (Context.Request.Cookies["User_Info"] == null) && (Context.Session["access_token"] == null))
            {
                Response.Write("You haven't log in yet");
                Response.End();
            }
            DataTable dt1= SQLHelper.ExecuteDt("select top 1  * from EmbeddedSet order by TimeStamp Asc");
            DateTime initial_start_date = Convert.ToDateTime(dt1.Rows[0]["TimeStamp"]);
            start_str = initial_start_date.Year.ToString() + "," + (initial_start_date.Month - 1).ToString() + "," + initial_start_date.Day.ToString() + "," + initial_start_date.Hour.ToString() + "," + initial_start_date.Minute.ToString() + "," + initial_start_date.Second.ToString();
            //5/1/2014 23:59:59
            start_str_for_easyui = (initial_start_date.Month).ToString()+"/"+initial_start_date.Day.ToString()+"/"+initial_start_date.Year.ToString()+ " "+initial_start_date.Hour.ToString() + ":" + initial_start_date.Minute.ToString() + ":" + initial_start_date.Second.ToString();
            //start_str = initial_start_date.ToString("yyyy,MM,dd,HH,mm,ss");
            //int real_month=Convert.ToInt32(start_str.Split(new char[]{','})[1]);
            //int js_month = real_month - 1;
            
            
            DataTable dt2 = SQLHelper.ExecuteDt("select top 1  * from EmbeddedSet order by TimeStamp DESC");
            DateTime initial_end_date = Convert.ToDateTime(dt2.Rows[0]["TimeStamp"]);
            end_str = initial_end_date.Year.ToString() + "," + (initial_end_date.Month - 1).ToString() + "," + initial_end_date.Day.ToString() + "," + initial_end_date.Hour.ToString() + "," + initial_end_date.Minute.ToString() + "," + initial_end_date.Second.ToString();
            end_str_for_easyui =(initial_end_date.Month).ToString()+"/"+initial_end_date.Day.ToString()+"/"+initial_end_date.Year.ToString() + " " + initial_end_date.Hour.ToString() + ":" + initial_end_date.Minute.ToString() + ":" + initial_end_date.Second.ToString();

        }
    }
}