using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{


    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NI2OJAE\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where kullanici_ad=@p1 and sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader(); //Bu satır komut nesnesini çalıştırır ve veritabanından veri okur.
            if (dr.Read()) //dr.Read() metodu, veritabanından okunan verilerin olup olmadığını kontrol eder. Eğer veri varsa true döner.
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide(); //Giriş formunu gizle
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            baglanti.Close();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
