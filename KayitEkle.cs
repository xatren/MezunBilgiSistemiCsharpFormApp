using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace _224Proje
{
    public partial class KayitEkle : Form
    {
        public KayitEkle()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=internetproje;user=root");

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
        public DateTime DateMezuniyet
        {
            get { return dateMezuniyet.Value; }
            set { dateMezuniyet.Value = value; }
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

        private void btnKayitEkle_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("INSERT INTO ogrenciler (Ogrenci_NO, AD, Soyad, Mezuniyet_Tarihi, CepTel, Eposta, EvTel, EvUlke, EvSehir, EvAdress) VALUES (@pOgrenci_No, @pOgrenciAd, @pOgrenciSoyad, @pOgrenciMezuniyet, @pOgrenciCepTel, @pOgrenciEPosta, @pOgrenciEvTel, @pOgrenciEvUlke, @pOgrenciEvSehir, @pOgrenciEvAdress)", baglanti);

                komut.Parameters.AddWithValue("@pOgrenci_No", txtOgrNo.Text);
                komut.Parameters.AddWithValue("@pOgrenciAd", txtOgrAd.Text);
                komut.Parameters.AddWithValue("@pOgrenciSoyad", txtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@pOgrenciMezuniyet", dateMezuniyet.Value);
                komut.Parameters.AddWithValue("@pOgrenciCepTel", txtCepTel.Text);
                komut.Parameters.AddWithValue("@pOgrenciEPosta", txtEPosta.Text);
                komut.Parameters.AddWithValue("@pOgrenciEvTel", txtEvTel.Text);
                komut.Parameters.AddWithValue("@pOgrenciEvUlke", txtEvUlke.Text);
                komut.Parameters.AddWithValue("@pOgrenciEvSehir", txtEvSehir.Text);
                komut.Parameters.AddWithValue("@pOgrenciEvAdress", txtEvAdres.Text);

                int satir = komut.ExecuteNonQuery();
                MessageBox.Show(satir + " yeni kayıt eklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }

            // Kayıt ekledikten sonra ana formu yenileme
            MezunBilgiEkran anaForm = (MezunBilgiEkran)Application.OpenForms["MezunBilgiEkran"];
            anaForm.YenileDataGridView();
            this.Close();
        }
    }
}
