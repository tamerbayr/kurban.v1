using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace kurbanv1
{
    public partial class hissedarTablosu : Form
    {
        DataTable hissedarTab = new DataTable();
        static string data = Application.StartupPath;
        static string connectionString = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={data}\kurbanDB.mdf;Initial Catalog=kurbanDB;Integrated Security=True;";
        SqlConnection baglanti = new SqlConnection(connectionString);
        public hissedarTablosu()
        {
            InitializeComponent();
        }

        private void hissedarTablosunuYukle()
        {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Hissedarlar", baglanti);
                hissedarTab.Clear();
                da.Fill(hissedarTab);
                dataGridView1.DataSource = hissedarTab;
                dataGridView1.Columns[0].Width = (int)(dataGridView1.Width * 0.05);
                dataGridView1.Columns[2].Width = (int)(dataGridView1.Width * 0.2);
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void hissedarTablosu_Load(object sender, EventArgs e)
        {
            hissedarTablosunuYukle();
            btnSil.Enabled = false;
            this.MaximizeBox = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            int rakamSayisi = txtTelNo.Text.Count(char.IsDigit);
            if (rakamSayisi != 0 && rakamSayisi != 10)
            {
                MessageBox.Show("Telefon numarası eksik veya hatalı.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtAdSoyad.Text.Length == 0)
            {
                MessageBox.Show("Adı soyadı boş olamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboGrup.SelectedItem == null)
            {
                MessageBox.Show("Grup seçimi boş olamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("INSERT INTO Hissedarlar (AdSoyad, Telefon, AgirlikAraligi, AtandiMi) VALUES (@AdSoyad, @Telefon, @AgirlikAraligi, @AtandiMi)", baglanti);
                    komut.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
                    komut.Parameters.AddWithValue("@Telefon", txtTelNo.Text);
                    komut.Parameters.AddWithValue("@AgirlikAraligi", comboGrup.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@AtandiMi", 0);
                    komut.ExecuteNonQuery();

                    hissedarTablosunuYukle();
                    baglanti.Close();
                }

                // sonraki girdi için textboxları boşalt
                txtAdSoyad.Text = "";
                txtTelNo.Text = "";
                comboGrup.SelectedItem = null;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Seçili hissedarı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr != DialogResult.OK)
            {
                return;
            }

            if (dataGridView1.CurrentRow != null)
            {
                object secili = dataGridView1.CurrentRow.Cells["ID"].Value;

                if (secili != null)
                {
                    using (SqlConnection baglanti = new SqlConnection(connectionString))
                    {
                        baglanti.Open();
                        int seciliID = Convert.ToInt32(secili);
                        SqlCommand komut = new SqlCommand($"DELETE FROM Hissedarlar WHERE ID = {seciliID}", baglanti);
                        komut.ExecuteNonQuery();

                        hissedarTablosunuYukle();
                        baglanti.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli bir satır seçiniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Silinecek satır bulunamadı.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            hissedarTablosunuYukle();
        }

        // gizli tuşları gösterme
        private void hissedarTablosu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                btnTamSil.Visible = false;
            }
        }

        private void hissedarTablosu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                btnTamSil.Visible = true;
            }
        }

        private void btnTamSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tüm hissedarları silmek ve ID'leri sıfırlamak istediğinize emin misiniz?",
                "Silme Onayı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection baglanti = new SqlConnection(connectionString))
                    {
                        baglanti.Open();
                        using (SqlTransaction transaction = baglanti.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand komut = new SqlCommand("DELETE FROM Hissedarlar", baglanti, transaction))
                                {
                                    komut.ExecuteNonQuery();
                                }

                                using (SqlCommand komut2 = new SqlCommand("DBCC CHECKIDENT('Hissedarlar', RESEED, 0)", baglanti, transaction))
                                {
                                    komut2.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Tüm hissedarlar başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                hissedarTablosunuYukle();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw;
                            }
                            finally {
                                baglanti.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally 
                {
                    baglanti.Close();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnSil.Enabled = true;
            }
            else
            {
                btnSil.Enabled = false;
            }
        }

        private void txtAramaKutusu_TextChanged_1(object sender, EventArgs e)
        {
            DataView dv = hissedarTab.DefaultView;

            if (string.IsNullOrWhiteSpace(txtAramaKutusu.Text))
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter = $"AdSoyad LIKE '%{txtAramaKutusu.Text.Trim()}%'";
            }

            dataGridView1.DataSource = dv;
        }
    }
}
