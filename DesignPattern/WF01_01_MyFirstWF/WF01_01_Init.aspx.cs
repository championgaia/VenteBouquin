using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WF01_01_MyFirstWF
{
    public partial class WF01_01_Init : System.Web.UI.Page
    {
        private List<Personne> ListPeople;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Session["MyPeople"] = new List<Personne>();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddPersonne();
            PersonneBinding();
        }

        private void PersonneBinding()
        {
            rptEvents.DataSource = ListPeople;
            rptEvents.DataBind();
        }

        private void AddPersonne()
        {
            if (Session["MyPeople"] != null)
                ListPeople = (List<Personne>)Session["MyPeople"];
            else
                ListPeople = new List<Personne>();
            ListPeople.Add(new Personne(txbName.Text, txbFirstName.Text, cldBirthday.SelectedDate.ToShortDateString()));
            Session["MyPeople"] = ListPeople;
        }
    }
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateNaissance { get; set; }
        public Personne(string nom, string prenom, string dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }
    }
}