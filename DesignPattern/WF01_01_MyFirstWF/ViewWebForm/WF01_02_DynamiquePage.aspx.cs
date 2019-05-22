using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WF01_01_MyFirstWF.Models;
using WF01_01_MyFirstWF.ViewModels;

namespace WF01_01_MyFirstWF.ViewWebForm
{
    public partial class WF01_02_DynamiquePage : System.Web.UI.Page
    {
        private ListLivreViewModel NotreLivres;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Session["MyBook"] = new ListLivreViewModel();
            PersonneBinding();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddPersonne();
            PersonneBinding();
        }
        private void PersonneBinding()
        {
            NotreLivres = new ListLivreViewModel ();
            #region ListView
            lvBook.DataSource = NotreLivres.ListBook;
            lvBook.DataBind();
            #endregion
        }
        private void AddPersonne()
        {
            if (Session["MyBook"] != null)
                NotreLivres = (ListLivreViewModel)Session["MyBook"];
            else
                NotreLivres = new ListLivreViewModel();
        }

        protected void btnLivre_Click(object sender, EventArgs e)
        {
            Button btnLivre = (Button)sender;
            var codeISBN = btnLivre.CommandArgument;
        }
    }
}