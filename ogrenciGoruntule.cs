using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _224Proje
{
    public partial class ogrenciGoruntule : Form
    {
        private int? ogrenciNo;
        //private string? ogrenciAd;
        //private string? ogrenciSoyad;
       // private int ogrenciMez;
        private MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=internetproje;user=root");

        public ogrenciGoruntule()
        {
            InitializeComponent();
        }

        public ogrenciGoruntule(int ogrenciNo ) : this()
        {
            this.ogrenciNo = ogrenciNo;
            //
        }

        public TextBox textBoxOgrenciNo
        {
            get { return txtOgrNo; }
            set { txtOgrNo = value; }
        }
        public TextBox textBoxOgrenciAdi
        {
            get { return txtOgrAd; }
            set { txtOgrAd = value; }
        }
        public TextBox textBoxOgrenciSoyad
        {
            get { return txtOgrSoyad; }
            set { txtOgrSoyad = value; }
        }
        public TextBox textBoxOgrenciMezuniyet
        {
            get { return txtMezuniyetTarihi; }
            set { txtMezuniyetTarihi = value; }
        }
        public TextBox textBoxOgrenciCepTel
        {
            get { return txtCepTel; }
            set { txtCepTel = value; }
        }
        public TextBox textBoxOgrenciEPosta
        {
            get { return txtEPosta; }
            set { txtEPosta = value; }
        }
        public TextBox textBoxOgrenciEvTel
        {
            get { return txtEvTel; }
            set { txtEvTel = value; }
        }
        public TextBox textBoxOgrenciEvUlke
        {
            get { return txtEvUlke; }
            set { txtEvUlke = value; }
        }
        public TextBox textBoxOgrenciEvSehir
        {
            get { return txtEvSehir; }
            set { txtEvSehir = value; }
        }
        public TextBox textBoxOgrenciEvAdres
        {
            get { return txtEvAdres; }
            set { txtEvAdres = value; }
        }

        public DataGridView DataIsBilgi
        {
            get { return dgIsBilgileri; }
            set { dgIsBilgileri = value; }
        }

        public DataGridView DataEgitimBilgi
        {
            get { return dgEgitimBilgileri; }
            set { dgEgitimBilgileri = value; }
        }

        private void ogrenciGoruntule_Load(object sender, EventArgs e)
        {
            if (ogrenciNo.HasValue)
            {
                LoadOgrenciBilgileri();
                LoadEgitimBilgileri();
                LoadIsBilgileri();
            }
        }

        private void LoadOgrenciBilgileri()
        {
            try
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("SELECT Ogrenci_NO, AD, Soyad, Mezuniyet_Tarihi, CepTel, Eposta, EvTel, EvUlke, EvSehir, EvAdres FROM ogrenciler WHERE Ogrenci_NO = @ogrenciNo", baglanti);
                komut.Parameters.AddWithValue("@ogrenci_No", ogrenciNo);

                MySqlDataReader reader = komut.ExecuteReader();

                if (reader.Read())
                {
                    textBoxOgrenciNo.Text = reader["Ogrenci_NO"].ToString();
                    textBoxOgrenciAdi.Text = reader["AD"].ToString();
                    textBoxOgrenciSoyad.Text = reader["Soyad"].ToString();
                    textBoxOgrenciMezuniyet.Text = reader["Mezuniyet_Tarihi"].ToString();
                    textBoxOgrenciCepTel.Text = reader["CepTel"].ToString();
                    textBoxOgrenciEPosta.Text = reader["Eposta"].ToString();
                    textBoxOgrenciEvTel.Text = reader["EvTel"].ToString();
                    textBoxOgrenciEvUlke.Text = reader["EvUlke"].ToString();
                    textBoxOgrenciEvSehir.Text = reader["EvSehir"].ToString();
                    textBoxOgrenciEvAdres.Text = reader["EvAdres"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void LoadEgitimBilgileri()
        {
            try
            {
                baglanti.Open();
                MySqlDataAdapter adaptor = new MySqlDataAdapter("SELECT AkademikEgitim, Baslangic, Bitis, Ulke, Sehir, Universite FROM egitimbilgileri WHERE Ogrenci_NO = @ogrenciNo", baglanti);
                adaptor.SelectCommand.Parameters.AddWithValue("@ogrenci_No", ogrenciNo);
                DataTable dt = new DataTable();
                adaptor.Fill(dt);
                DataEgitimBilgi.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void LoadIsBilgileri()
        {
            try
            {
                baglanti.Open();
                MySqlDataAdapter adaptor = new MySqlDataAdapter("SELECT IseGirisTarihi, IstenAyrilisTarihi, KamuOzel, Sektor, Unvan, Pozisyon FROM isbilgileri WHERE Ogrenci_NO = @ogrenciNo", baglanti);
                adaptor.SelectCommand.Parameters.AddWithValue("@ogrenci_No", ogrenciNo);
                DataTable dt = new DataTable();
                adaptor.Fill(dt);
                DataIsBilgi.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

    }
}
