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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MakaleListesiGetir();
        }
        private void MakaleListesiGetir()
        {

            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("MakaleListele", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();


                SqlDataReader dr = cmd.ExecuteReader();


                rptArticles.DataSource = dr;
                rptArticles.DataBind();



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