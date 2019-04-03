using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WF01_01_MyFirstWF
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<MyEvent> ListEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Session["MyEvents"] = new List<MyEvent>();
        }

        protected void btnEvent_Click(object sender, EventArgs e)
        {
            UpdateEvents();
            BindEvents();
        }
        private void UpdateEvents()
        {
            if (Session["MyEvents"] != null)
                ListEvent = (List<MyEvent>)Session["MyEvents"];
            else
                ListEvent = new List<MyEvent>();
            ListEvent.Add(new MyEvent(txtEvent.Text, calendarEvents.SelectedDate));
            Session["MyEvents"] = ListEvent;
        }
        private void BindEvents()
        {
            rptEvents.DataSource = ListEvent;
            rptEvents.DataBind();
        }
        public class MyEvent
        {
            public string EventName
            {
                get;
                private set;
            }
            public string EventDate
            {
                get;
                private set;
            }
            public MyEvent(string eventName, DateTime eventDate)
            {
                EventName = eventName;
                EventDate = eventDate.ToShortDateString();
            }
        }
    }
}