using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WF01_01_MyFirstWF.Models;
using WF01_01_MyFirstWF.ViewModels;

namespace WF01_01_MyFirstWF
{
    public partial class WF01_01_Init : System.Web.UI.Page
    {
        //private List<Personne> ListPeople;
        private PersonneViewModel PersonneVM;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                //Session["MyPeople"] = new List<Personne>();
                Session["MyPeople"] = new PersonneViewModel();
            PersonneBinding();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddPersonne();
            //PersonneBinding();
        }
        private void PersonneBinding()
        {
            //rptEvents.DataSource = ListPeople;
            //rptEvents.DataBind();
            PersonneVM = new PersonneViewModel();
            #region dropdownlist
            ddlPersonne.DataSource = PersonneVM.ListPeople;
            ddlPersonne.DataTextField = "NomM";
            ddlPersonne.DataValueField = "PrenomM";
            ddlPersonne.DataBind();
            #endregion
            #region ListView
            lvPersonne.DataSource = PersonneVM.ListPeople;
            lvPersonne.DataBind();
            #endregion
        }

        private void AddPersonne()
        {
            if (Session["MyPeople"] != null)
                //ListPeople = (List<Personne>)Session["MyPeople"];
                PersonneVM = (PersonneViewModel)Session["MyPeople"];
            else
                //ListPeople = new List<Personne>();
                PersonneVM = new PersonneViewModel();
            //ListPeople.Add(new Personne(txbName.Text, txbFirstName.Text, cldBirthday.SelectedDate.ToShortDateString()));
            //Session["MyPeople"] = ListPeople;
            //PersonneVM.ListPeople.Add(new PersonneModel(txbName.Text, txbFirstName.Text, cldBirthday.SelectedDate.ToShortDateString()));
            PersonneVM.CreatePersonne(new PersonneModel(txbName.Text, txbFirstName.Text, cldBirthday.SelectedDate.ToShortDateString()));
        }
    }
}