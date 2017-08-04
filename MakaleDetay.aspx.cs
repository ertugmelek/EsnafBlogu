using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsnafBlogu
{
    public partial class MakaleDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Helper.MesajGoster(this, Request.ServerVariables["Http_Referer"]);
            if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
            {
                ViewState["MakaleID"] = Convert.ToInt32(Request.QueryString["mid"]); // view sitate makale ıd yi atadık 
                OkunmaSayisiArttir();
                MakaleGetirByID(Convert.ToInt32(Request.QueryString["mid"]));

                YorumGetir(Convert.ToInt32(Request.QueryString["mid"]));
            }
        }
        private void MakaleGetirByID(int makaleID)
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("select m.Icerik,m.Baslik,m.KayitTarihi,a.UserName ,m.OkunmaSayisi from Makaleler as m join aspnet_Users as a on a.UserId=m.YazarID where m.MakaleID=@mid", conn);
            cmd.Parameters.Add("@mid", SqlDbType.Int).Value = makaleID;

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ltrBaslik.Text = dr["Baslik"].ToString();
                    ltrGonderen.Text = dr["UserName"].ToString();
                    ltrIcerik.Text = dr["Icerik"].ToString();
                    ltrTarih.Text = Convert.ToDateTime(dr["KayitTarihi"]).ToString();
                    ltrOkunmaSayisi.Text = dr["OkunmaSayisi"].ToString();
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
        }
        // Yapılan Yorumları göstermek için yapılan metot .
        private void YorumGetir(int MakaleID)
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("select AdSoyad,YorumIcerik,YorumTarihi from Yorumlar where MakaleID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", MakaleID);

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                rptYorumlar.DataSource = dr;
                rptYorumlar.DataBind();


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

        // okunma sayısı için  metot
        private void OkunmaSayisiArttir()
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("update Makaleler set OkunmaSayisi=Isnull(OkunmaSayisi,0)+1 where MakaleID=@MAkaleID", conn);

            cmd.Parameters.AddWithValue("@MAkaleID", Convert.ToInt32(ViewState["MakaleID"]));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("insert into Yorumlar (AdSoyad,YorumIcerik,Email,MakaleID,WebSitesi,Onaylandimi) values(@adSoyad,@Icerik,@Email,@MakaleID,@site,@Onaylandimi)  ", conn);

            cmd.Parameters.Add("@adSoyad", SqlDbType.NVarChar, 100).Value = txtAdSoyad.Text;
            cmd.Parameters.Add("@Icerik", SqlDbType.NVarChar, 1000).Value = txtYorum.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = txtEmail.Text;
            cmd.Parameters.Add("@Site", SqlDbType.NVarChar, 100).Value = txtWebSite.Text; ;
            cmd.Parameters.Add("@Onaylandimi", SqlDbType.Bit).Value = false;
            cmd.Parameters.Add("@MakaleID", SqlDbType.Int).Value = Convert.ToInt32(ViewState["MakaleID"]);


            int ess = 0;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
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
                Helper.MesajGoster(this, "Yorumunuz Kaydedilmiştir.");
                YorumGetir(Convert.ToInt32(ViewState["MakaleID"]));
            }
        }
    }
}