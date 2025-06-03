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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NI2OJAE\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {

            //Toplam Personel Sayısını Getirme
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader(); //Select için ExecuteReader kullanılır.
            while (dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString(); //dr1[0] ilk sütunu temsil eder.
            }
            baglanti.Close();

            //Evli Personel Sayısını Getirme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader(); //Select için ExecuteReader kullanılır.
            while (dr2.Read())
            {
                LblEvliPersonel.Text = dr2[0].ToString(); //dr2[0] ilk sütunu temsil eder.
            }
            baglanti.Close();

            //Bekar Personel Sayısını Getirme
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader(); //Select için ExecuteReader kullanılır.
            while (dr3.Read())
            {
                LblBekarPersonel.Text = dr3[0].ToString(); //dr3[0] ilk sütunu temsil eder.
            }
            baglanti.Close();

            //Farklı şehir saysısını Getirme
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(PerSehir)) from Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader(); //Select için ExecuteReader kullanılır.
            while (dr4.Read())
            {
                LblSehirSayisi.Text = dr4[0].ToString(); //dr4[0] ilk sütunu temsil eder.
            }
            baglanti.Close();


            //Farklı şehir saysısını Getirme
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader(); //Select için ExecuteReader kullanılır.
            while (dr5.Read())
            {
                LblToplamMaas.Text = dr5[0].ToString(); //dr5[0] ilk sütunu temsil eder.
            }
            baglanti.Close();


            //Ortalama Maaşı Getirme
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader(); //Select için ExecuteReader kullanılır.
            while (dr6.Read())
            {
                LblOrtalamaMaas.Text = dr6[0].ToString(); //dr6[0] ilk sütunu temsil eder.
            }
            baglanti.Close();



        }
    }
}
