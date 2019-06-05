using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WF01_01_MyFirstWF.ViewModels;

namespace WF01_01_MyFirstWF.ViewWebForm
{
    public partial class WF01_05_GridViewControl_DataBinding : Page
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
            gvBook.DataSource = NotreLivres.ListBookVM;
            gvBook.DataBind();
            #endregion
            //#region textbox
            //txbTotal.Text = NotreLivres.TotalPrixVM.ToString();
            //txbTotal.DataBind();
            //#endregion
        }
        #endregion
        protected void gvBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ltError.Text = string.Empty;
            gvBook.EditIndex = e.NewEditIndex;
            LivreBinding();
        }

        protected void gvBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ltError.Text = string.Empty;
            GridViewRow gvRow = (GridViewRow)gvBook.Rows[e.RowIndex];
            HiddenField hdnBookId = (HiddenField)gvRow.FindControl("hdnBookId");
            TextBox txtNomLivre = (TextBox)gvRow.Cells[1].Controls[0];
            TextBox txtNomPrix = (TextBox)gvRow.Cells[2].Controls[0];
            //modify database

            gvBook.EditIndex = -1;
            LivreBinding();
        }

        protected void gvBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBook.EditIndex = -1;
            LivreBinding();
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            //modify database

            gvBook.EditIndex = -1;
            LivreBinding();
        }
        protected void gvBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ltError.Text = string.Empty;
            GridViewRow gvRow = (GridViewRow)gvBook.Rows[e.RowIndex];
            HiddenField hdnBookId = (HiddenField)gvRow.FindControl("hdnBookId");
            //modify database

            gvBook.EditIndex = -1;
            LivreBinding();
        }
    }
}