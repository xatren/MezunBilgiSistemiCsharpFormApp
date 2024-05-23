using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _224Proje
{
    public partial class RaporAlmacs : Form
    {
        public RaporAlmacs()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=internetproje;user=root");
        private void RaporAlmacs_Load(object sender, EventArgs e)
        {

        }

        private void btnDoktora_Click(object sender, EventArgs e)
        {
            try
            {

                baglanti.Open();


                string sql = "SELECT Ogrenci_NO, AkademikEgitim, Baslangic, Bitis, Ulke, Sehir, Universite\r\nFROM egitimbilgileri\r\nWHERE AkademikEgitim = 'Doktora'";



                MySqlCommand komut = new MySqlCommand(sql, baglanti);


                MySqlDataReader okuyucu = komut.ExecuteReader();


                Form popupForm = new Form();
                DataGridView dataGridViewPopup = new DataGridView();
                dataGridViewPopup.Dock = DockStyle.Fill;
                popupForm.Controls.Add(dataGridViewPopup);

                DataTable dt = new DataTable();
                dt.Load(okuyucu);
                dataGridViewPopup.DataSource = dt;


                popupForm.ShowDialog();


                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void btnTrDoktora_Click(object sender, EventArgs e)
        {
            try
            {

                baglanti.Open();


                string sql = "SELECT AkademikEgitim, Ogrenci_NO, Baslangic, Bitis, Ulke, Sehir, Universite\r\nFROM egitimbilgileri\r\nWHERE AkademikEgitim = 'Doktora' AND Ulke = 'Türkiye'";



                MySqlCommand komut = new MySqlCommand(sql, baglanti);


                MySqlDataReader okuyucu = komut.ExecuteReader();


                Form popupForm = new Form();
                DataGridView dataGridViewPopup = new DataGridView();
                dataGridViewPopup.Dock = DockStyle.Fill;
                popupForm.Controls.Add(dataGridViewPopup);


                DataTable dt = new DataTable();
                dt.Load(okuyucu);
                dataGridViewPopup.DataSource = dt;


                popupForm.ShowDialog();


                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void btnYurtDisi_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "SELECT Ogrenci_NO, Baslangic, Bitis, Ulke, Sehir, Universite\r\nFROM egitimbilgileri\r\nWHERE AkademikEgitim = 'Doktora' AND Ulke != 'Türkiye'";
                MySqlCommand komut = new MySqlCommand(sql, baglanti);
                MySqlDataReader okuyucu = komut.ExecuteReader();

                Form popupForm = new Form();
                DataGridView dataGridViewPopUp = new DataGridView();
                dataGridViewPopUp.Dock = DockStyle.Fill;
                popupForm.Controls.Add(dataGridViewPopUp);

                DataTable dt = new DataTable();
                dt.Load(okuyucu);
                dataGridViewPopUp.DataSource = dt;

                popupForm.ShowDialog();

                baglanti.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void btnYuksekLis_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                string sorgu = "SELECT Ogrenci_NO, Baslangic, Bitis, Ulke, Sehir, Universite\r\nFROM egitimbilgileri\r\nWHERE AkademikEgitim = 'Yüksek Lisans'";

                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);

                MySqlDataReader okuyucu = komut.ExecuteReader();

                Form popupForm = new Form();
                DataGridView dataGridViewPopUp = new DataGridView();
                dataGridViewPopUp.Dock = DockStyle.Fill;
                popupForm.Controls.Add(dataGridViewPopUp);

                DataTable dt = new DataTable();
                dt.Load(okuyucu);
                dataGridViewPopUp.DataSource = dt;

                popupForm.ShowDialog();
                baglanti.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştur: " + ex.Message);
            }
        }

        private void btnTrYuksekLis_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                string sorgu = "SELECT Ogrenci_NO, Baslangic, Bitis, Ulke, Sehir, Universite\r\nFROM egitimbilgileri\r\nWHERE AkademikEgitim = 'Yüksek Lisans' AND Ulke = 'Türkiye';";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                MySqlDataReader okuyucu = komut.ExecuteReader();

                Form popUpForm = new Form();
                DataGridView dataGridViewPopUp = new DataGridView();
                dataGridViewPopUp.Dock = DockStyle.Fill;
                popUpForm.Controls.Add(dataGridViewPopUp);

                DataTable dt = new DataTable();
                dt.Load(okuyucu);
                dataGridViewPopUp.DataSource = dt;

                popUpForm.ShowDialog();

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void btnYurdDisiYuksekLis_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                string sorgu = "SELECT Ogrenci_NO, Baslangic, Bitis, Ulke, Sehir, Universite\r\nFROM egitimbilgileri\r\nWHERE AkademikEgitim = 'Yüksek Lisans' AND Ulke != 'Türkiye'";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);

                MySqlDataReader okuyucu = komut.ExecuteReader();

                Form popUpForm = new Form();
                DataGridView dataGridViewPopUp = new DataGridView();
                dataGridViewPopUp.Dock = DockStyle.Fill;
                popUpForm.Controls.Add(dataGridViewPopUp);

                DataTable dt = new DataTable();
                dt.Load(okuyucu);
                dataGridViewPopUp.DataSource = dt;

                popUpForm.ShowDialog();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştur: " + ex.Message);
            }
        }

        private void btnMezSonrası3_5_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();


                string sorgu = "SELECT Ogrenci_NO, AkademikEgitim, Baslangic, Bitis, Ulke, Sehir, Universite FROM egitimbilgileri WHERE TIMESTAMPDIFF(YEAR, Bitis, CURDATE()) BETWEEN 3 AND 5";

                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                MySqlDataReader okuyucu = komut.ExecuteReader();

                Form popUpForm = new Form();
                DataGridView dataGridViewPopUp = new DataGridView();
                dataGridViewPopUp.Dock = DockStyle.Fill;
                popUpForm.Controls.Add(dataGridViewPopUp);

                DataTable dt = new DataTable();
                dt.Load(okuyucu);
                dataGridViewPopUp.DataSource = dt;

                popUpForm.ShowDialog();

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void btnMeznSonras10_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                string sql = @"SELECT Ogrenci_NO, AkademikEgitim, Baslangic, Bitis, Ulke, Sehir, Universite, Bolum, Pozisyon
                                FROM egitimbilgileri
                                WHERE (Pozisyon LIKE '%Yönetici%' OR Pozisyon LIKE '%Müdür%')
                                AND TIMESTAMPDIFF(YEAR, Bitis, IseGirisTarihi) <= 10;
                                ";

                MySqlCommand komut = new MySqlCommand(sql, baglanti);
                MySqlDataReader okuyucu = komut.ExecuteReader();

                Form popupForm = new Form();
                DataGridView dataGridViewPopUp = new DataGridView();
                dataGridViewPopUp.Dock = DockStyle.Fill;
                popupForm.Controls.Add(dataGridViewPopUp);

                DataTable dt = new DataTable();
                dt.Load(okuyucu);
                dataGridViewPopUp.DataSource = dt;

                popupForm.ShowDialog();

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
    
    
}
    

