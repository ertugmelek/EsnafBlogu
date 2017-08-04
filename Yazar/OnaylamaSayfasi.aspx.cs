using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsnafBlogu.Yazar
{
    public partial class OnaylamaSayfasi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["yid"]))
            {
                YorumGetir(Convert.ToInt32(Request.QueryString["yid"]));
            }
            else
                Response.Redirect("/");
        }
        private void YorumGetir(int yorumID)
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("select * from Yorumlar where YorumID=@ID ", conn);
            cmd.Parameters.Add(new SqlParameter("@ID", yorumID));
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtAdSoyad.Text = dr["AdSoyad"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        txtWebSite.Text = dr["WebSitesi"].ToString();
                        txtYorum.Text = dr["YorumIcerik"].ToString();
                    }
                }
                else
                    Response.Redirect("/");
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

        protected void btnOnayla_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("update Yorumlar set Onaylandimi=1 where YorumID=@ID ", conn);


            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Request.QueryString["yid"]));


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

                MultiView1.ActiveViewIndex = 1;
            }
        }
    }
}