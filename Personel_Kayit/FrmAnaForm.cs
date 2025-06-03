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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NI2OJAE\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");






        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

            
        }


        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }


        private void BtnKaydet_Click(object sender, EventArgs e) //Kaydet butonuna tıklandığında çalışacak kod bloğu
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek, PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaas.Text); 
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text); //RadioButton değerini label üzerinden alıyoruz.
            komut.ExecuteNonQuery(); //Sorguyu çalıştır. Ekleme, silme, güncelleme işlemleri için kullanılır.
            baglanti.Close();
            MessageBox.Show("Personel Eklendi.");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                label8.Text = "True"; //RadioButton1 seçildiğinde label8'in değeri "True" olarak ayarlanır.
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False"; //RadioButton2 seçildiğinde label8'in değeri "False" olarak ayarlanır.
            }
        }

        void temizle() //Formdaki tüm alanları temizleyen bir metot
        {
            Txtid.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            CmbSehir.Text = "";
            MskMaas.Text = "";
            TxtMeslek.Text = "";
            radioButton1.Checked = false; 
            radioButton2.Checked = false;
            TxtAd.Focus(); //Form yüklendiğinde ilk kutucuğa odaklanır.
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //DataGridView'de bir hücreye çift tıklandığında çalışacak kod bloğu
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; //Seçilen satırın indeksini alır.
            
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString(); //Seçilen satırın ilk hücresindeki değeri alır.
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString(); //Seçilen satırın ikinci hücresindeki değeri alır.
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString(); //Seçilen satırın üçüncü hücresindeki değeri alır.
            CmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString(); //Seçilen satırın dördüncü hücresindeki değeri alır.
            MskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString(); //Seçilen satırın beşinci hücresindeki değeri alır.
           label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString(); //Seçilen satırın altıncı hücresindeki değeri alır.
            TxtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString(); //Seçilen satırın altıncı hücresindeki değeri alır.

        }

        private void label8_TextChanged(object sender, EventArgs e) //label8'in metni değiştiğinde çalışacak kod bloğu
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true; //Eğer label8'in değeri "True" ise radioButton1 seçilir.
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true; //Eğer label8'in değeri "False" ise radioButton2 seçilir.
            }
        }

        private void BtnSil_Click(object sender, EventArgs e) //Silme butonuna tıklandığında çalışacak kod bloğu
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from tbl_Personel where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", Txtid.Text); //Silinecek personelin ID'sini alır.
            komutsil.ExecuteNonQuery(); //Sorguyu çalıştırır.
            baglanti.Close();
            MessageBox.Show("Personel Silindi.");

        }

        private void BtnGuncelle_Click(object sender, EventArgs e) //Güncelleme butonuna tıklandığında çalışacak kod bloğu
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update tbl_Personel set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerMeslek=@a5,PerDurum=@a6 where Perid = @a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", TxtAd.Text); //Güncellenecek personelin adı
            komutguncelle.Parameters.AddWithValue("@a2", TxtSoyad.Text); //Güncellenecek personelin soyadı
            komutguncelle.Parameters.AddWithValue("@a3", CmbSehir.Text); //Güncellenecek personelin şehri
            komutguncelle.Parameters.AddWithValue("@a4", MskMaas.Text); //Güncellenecek personelin maaşı
            komutguncelle.Parameters.AddWithValue("@a5", TxtMeslek.Text); //Güncellenecek personelin mesleği
            komutguncelle.Parameters.AddWithValue("@a6", label8.Text); //Güncellenecek personelin durumu (True/False)
            komutguncelle.Parameters.AddWithValue("@a7", Txtid.Text); //Güncellenecek personelin ID'si
            komutguncelle.ExecuteNonQuery(); //Sorguyu çalıştırır.

            baglanti.Close();

            MessageBox.Show("Personel Bilgileri Güncellendi.");
        }

        private void Btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik(); //Frmistatistik formunu oluşturur.
            fr.Show(); //Frmistatistik formunu gösterir.
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler(); //FrmGrafikler formunu oluşturur.
            frg.Show(); //FrmGrafikler formunu gösterir.
        }
    }
}
