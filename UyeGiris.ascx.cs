using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsnafBlogu
{
    public partial class UyeGiris : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = ((TextBox)LoginView1.FindControl("txtKullaniciAdi")).Text;
            string sifre = ((TextBox)LoginView1.FindControl("txtSifre")).Text;
            bool beniHatirla = ((CheckBox)LoginView1.FindControl("chbBeniHatirla")).Checked;

            bool cevap = Membership.ValidateUser(kullaniciAdi, sifre);
            if (cevap == true)
            {
                FormsAuthentication.RedirectFromLoginPage(kullaniciAdi, beniHatirla);
            }
            else 
            {
                Helper.MesajGoster((Page)HttpContext.Current.CurrentHandler, "KullanıcıAdı/Şifre Hatalı");
            }
        }

        protected void lnkCikis_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }
    }
}