using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WF01_01_MyFirstWF.ViewWebForm
{
    public partial class WF01_03_LifeCycle : System.Web.UI.Page
    {
        
        public void Page_PreInit(object sender, EventArgs e)
        {
            
        }
        public void Page_Init(object sender, EventArgs e)
        {
            
        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            
        }
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            txtPreInit.Text = "Enter PreInit State";
            txtInit.Text = "Enter PageInit State";
            txtInitComplet.Text = "Complete Init State";
            txtPreLoad.Text = "Enter PreILoad State";
            txtPageLoad.Text = "Enter PageLoad State";
            txtLoadComplet.Text = "Complete Load State";
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            txtRendering.Text = "Enter rendering page";
        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            txtUnLoad.Text = "Enter UnLoad Page";
        }
        protected void btnEvent_Click(object sender, EventArgs e)
        {
            txtBtn.Text = "button Click";
        }
    }
}