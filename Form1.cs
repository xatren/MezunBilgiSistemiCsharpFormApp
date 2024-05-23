using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace _224Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtKullanici.Text;
            string password = txtSifre.Text;

            if (ValidateUser(username, password))
            {
                MezunBilgiEkran mezunBilgi = new MezunBilgiEkran();
                mezunBilgi.Show();
                this.Hide(); // Giriş başarılıysa mevcut formu gizle
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlıştır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUser(string username, string password)
        {
            bool isValid = false;

            using (MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=internetproje;user=root"))
            {
                try
                {
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @username AND password = @password", baglanti);
                    komut.Parameters.AddWithValue("@username", username);
                    komut.Parameters.AddWithValue("@password", password); // Parola düz metin olarak saklanmışsa

                    int userCount = Convert.ToInt32(komut.ExecuteScalar());
                    isValid = userCount > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
            }

            return isValid;
        }
    }
}
