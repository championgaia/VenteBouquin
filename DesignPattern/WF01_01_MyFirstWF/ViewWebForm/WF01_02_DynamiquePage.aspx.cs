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
            {
                Session["MyBook"] = new ListLivreViewModel();
            }
            LivreBinding();
        }
        #region LivreBinding
        private void LivreBinding()
        {
            NotreLivres = new ListLivreViewModel();
            #region ListView
            lvBook.DataSource = NotreLivres.ListBookVM;
            lvBook.DataBind();
            #endregion
            #region textbox
            txbTotal.Text = NotreLivres.TotalPrixVM.ToString();
            txbTotal.DataBind();
            #endregion
        }
        #endregion
        #region AddLivre
        private void AddLivre()
        {
            if (Session["MyBook"] != null)
                NotreLivres = (ListLivreViewModel)Session["MyBook"];
            else
                NotreLivres = new ListLivreViewModel();
        }
        #endregion
        #region btnLivre_Click
        protected void btnLivre_Click(object sender, EventArgs e)
        {
            Button btnLivre = (Button)sender;
            var codeISBN = btnLivre.CommandArgument;
        }
        #endregion
        #region btnSubmit_Click
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddLivre();
            LivreBinding();
        }
        #endregion
        #region btnPanier_Click
        protected void btnPanier_Click(object sender, EventArgs e)
        {
            Button btnPanier = (Button)sender;
            //btnPanier.Attributes.Add("AutoPostback", "true");
            var prix = btnPanier.CommandArgument;
            NotreLivres.TotalPrixVM += double.Parse(prix);
            AddPanier(NotreLivres.TotalPrixVM);
            LivreBinding();
        }

        private void AddPanier(double totalPrixVM)
        {
            if (Session["MyBook"] != null)
                NotreLivres = (ListLivreViewModel)Session["MyBook"];
            else
                NotreLivres = new ListLivreViewModel(totalPrixVM);
        }
        #endregion

    }
}