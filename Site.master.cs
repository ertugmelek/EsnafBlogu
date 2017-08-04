using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsnafBlogu
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }
        private void KategoriGetir() 
        {
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("KategoriGetir", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                rptCategories.DataSource = dr;
                rptCategories.DataBind();

            }
            catch (Exception ex)
            {
                Helper.MesajGoster((Page)HttpContext.Current.CurrentHandler, ex.Message);

            }
            finally 
            {
                cmd.Dispose();
                conn.Dispose();
            }
        }
    }
}