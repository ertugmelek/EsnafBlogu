using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsnafBlogu.Yazar
{
    public partial class YorumOnayla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            KategoriGetir();
        }
        private void KategoriGetir()
        {

            if (Page.User.Identity.IsAuthenticated) //kullanıcının login olup olmadığını kontrol ediyoruz.
            {
                SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
                SqlCommand cmd = new SqlCommand("UyeBazliKategoriGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UyeID", (Guid)Membership.GetUser().ProviderUserKey);


                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = dr["KategoriAdi"].ToString();
                        li.Value = dr["KategoriID"].ToString();
                        ddlKategoriler.Items.Add(li);
                    }
                }
                catch (Exception ex)
                {

                    Helper.MesajGoster(this, ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Dispose();
                }


                ddlKategoriler.Items.Insert(0, new ListItem("Bir Kategori Seçiniz", "0"));
                ddlKategoriler.Items.Add(new ListItem("Tüm Kategoriler", "null"));

            }
        }

        protected void ddlKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlKategoriler.SelectedValue == "0")
            {
                return;
            }
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("yorumTablosuDoldur", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (ddlKategoriler.SelectedValue == "null")
            {
                cmd.Parameters.AddWithValue("@CatID", DBNull.Value);

            }

            else
            {
                cmd.Parameters.Add(new SqlParameter("@CatID", Convert.ToInt32(ddlKategoriler.SelectedValue)));

            }
            cmd.Parameters.Add(new SqlParameter("@UyeID", (Guid)Membership.GetUser().ProviderUserKey));

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();


                SqlDataReader dr = cmd.ExecuteReader();

                grdYorumlar.DataSource = dr;
                grdYorumlar.DataBind();

            }
            catch (Exception ex)
            {

                Helper.MesajGoster(this, ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
        }
    }
}