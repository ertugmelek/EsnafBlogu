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
    public partial class MakaleEkle : System.Web.UI.Page
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
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("select * from Kategoriler", conn);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = dr["KategoriAdi"].ToString();
                        li.Value = dr["KategoriID"].ToString();
                        drpKategoriler.Items.Add(li);
                    }
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
            drpKategoriler.Items.Insert(0, new ListItem("Bir Kategori Seçiniz...", "0"));
        }

        protected void btnMakaleKaydet_Click(object sender, EventArgs e)
        {
            if (drpKategoriler.SelectedValue != "0") 
            {
                SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
                SqlCommand cmd = new SqlCommand("insert into Makaleler (Baslik,Icerik,CategoryID,YazarID) values (@Baslik,@Icerik,@CategoryID,@YazarID) ",conn);

                cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text);
                cmd.Parameters.AddWithValue("@Icerik", editor1.Value);
                cmd.Parameters.AddWithValue("@CategoryID", drpKategoriler.SelectedValue);
                cmd.Parameters.AddWithValue("@YazarID", (Guid)Membership.GetUser().ProviderUserKey);

int  ess=0;
try
{
    if (conn.State == ConnectionState.Closed)
    {
        conn.Open();
    }
    ess = cmd.ExecuteNonQuery();
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
if (ess > 0) 
{
    Helper.MesajGoster(this, "Kaydedildi");
}
            }
        }
    }
}