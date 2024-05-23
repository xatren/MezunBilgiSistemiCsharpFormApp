using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _224Proje
{
    public partial class MezunBilgiEkran : Form
    {
        public MezunBilgiEkran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KayitEkle test = new KayitEkle();
            test.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RaporAlmacs raporAlmacs = new RaporAlmacs();
            raporAlmacs.Show();
        }

        private void MezunBilgiEkran_Load(object sender, EventArgs e)
        {
            YenileDataGridView();
        }

        public void YenileDataGridView()
        {
            using (MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=internetproje;user=root"))
            {
                try
                {
                    baglanti.Open();
                    MySqlDataAdapter adaptor = new MySqlDataAdapter("SELECT * FROM ogrenciler ORDER BY Ogrenci_NO", baglanti);
                    DataTable dt = new DataTable();
                    adaptor.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void kayit_Sil_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int ogrenciNo = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Ogrenci_NO"].Value);

                    using (MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=internetproje;user=root"))
                    {
                        try
                        {
                            baglanti.Open();
                            MySqlCommand komut = new MySqlCommand("DELETE FROM ogrenciler WHERE Ogrenci_NO = @pOgrenci_NO", baglanti);
                            komut.Parameters.AddWithValue("@pOgrenci_NO", ogrenciNo);
                            komut.ExecuteNonQuery();

                            MessageBox.Show("Kayıt silindi.");
                            YenileDataGridView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek için bir kayıt seçin.");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_ogr_Click(object sender, EventArgs e)
        {
            ogrenciGoruntule ogrenciGoruntuleForm = new ogrenciGoruntule();
            ogrenciGoruntuleForm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("e");
            if (e.RowIndex != -1)
            {
                int ogrenciNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Ogrenci_NO"].Value);
                


                ogrenciGoruntule ogrenciGoruntuleForm = new ogrenciGoruntule(ogrenciNo);
                ogrenciGoruntuleForm.Show();

            }
        }
    }
}
