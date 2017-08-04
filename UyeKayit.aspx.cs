using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsnafBlogu
{
    public partial class UyeKayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            SehirGetir();
            drpSehir_SelectedIndexChanged(null, null); // insert ile eklediğmiz değerin sayfa ilk yüklendiğinde gelmesi için yazdık.
        }

        private void SehirGetir()
        {

            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("select * from Sehirler", conn);
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
                        li.Text = dr["SehirAd"].ToString();
                        li.Value = dr["SehirID"].ToString();
                        drpSehir.Items.Add(li);
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
            drpSehir.Items.Insert(0, new ListItem("Bir Şehir Seçiniz...", "0"));

        }

        protected void drpSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpIlce.Items.Clear();  // yeni şehir seçtiğimizde eski içeriğin silinmesi gerektiği için clear la temizledik.
            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand("select * from Ilceler where SehirID=@SehirID", conn);
            cmd.Parameters.AddWithValue("@SehirID", drpSehir.SelectedValue);
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
                        // dropdownlist içerisine listitem ile veri ekliyoruz.
                        ListItem li = new ListItem();
                        li.Text = dr["IlceAdi"].ToString();
                        li.Value = dr["IlceID"].ToString();
                        drpIlce.Items.Add(li);
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

            drpIlce.Items.Insert(0, new ListItem("Bir İlçe Seçiniz...", "0"));
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (drpIlce.SelectedValue == "0" || drpSehir.SelectedValue == "0")
            {
                return; 
            }
            // Text boxlara girilen değerlerin kontrolleri için validationları kullanmak  yerine  aşağıdaki işlemleri uyguluyoruz.
            MembershipCreateStatus durum;

            Membership.CreateUser(txtKullaniciAdi.Text, txtSifre.Text, txtEmail.Text, "Kopek", "dogi", true, out durum);

            if (durum ==MembershipCreateStatus.Success)
            {
            Guid uyeID=(Guid)  Membership.GetUser(txtKullaniciAdi.Text).ProviderUserKey;
                // buradaki guid sql deki uniqidentitynin karşılığı.

            SqlConnection conn = new SqlConnection(Helper.BaglantiCumlesi);

            SqlCommand cmd = new SqlCommand("insert into UyeKisisel (UyeID,Ad,Soyad,DogumTarihi,Cinsiyet,Telefon,Adres,IlceID) values (@UyeID,@Ad,@Soyad,@DogumTarihi,@Cinsiyet,@Tel,@Adres,@IlceID)", conn);

            cmd.Parameters.AddWithValue("@UyeID", uyeID);
            cmd.Parameters.AddWithValue("@Ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@DogumTarihi", Convert.ToDateTime(txtDogumTarihi.Text));
            cmd.Parameters.AddWithValue("@Tel", txtTelefon.Text);
            cmd.Parameters.AddWithValue("@Adres", txtAdres.Text);
            cmd.Parameters.AddWithValue("@Cinsiyet", rbBay.Checked); // eğer bay seçililiği true değilse false atılacak
            cmd.Parameters.AddWithValue("@IlceID", drpIlce.SelectedValue);

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
                Helper.MesajGoster(this, "Kaydedildi.");
            }
            }
        }
        

    }
}