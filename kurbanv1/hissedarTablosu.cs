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
        DataTable dataGridViewHissedar = new DataTable();
        SqlConnection baglanti = new SqlConnection(@"Server=.\SQLEXPRESS;Database=KurbanDB;Trusted_Connection=True;");
        public hissedarTablosu()
        {
            InitializeComponent();
            hissedarTablosunuYukle();
        }

        private void hissedarTablosunuYukle()
        {
            using (SqlConnection baglanti = new SqlConnection(@"Server=.\SQLEXPRESS;Database=KurbanDB;Trusted_Connection=True;"))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Hayvanlar", baglanti);

                da.Fill(dataGridViewHissedar);
                dataGridView1.DataSource = dataGridViewHissedar;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 200;
            }
        }

        private void refreshTable()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Hissedarlar", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void hissedarTablosu_Load(object sender, EventArgs e)
        {
            refreshTable();
            btnSil.Enabled = false;
            this.MaximizeBox = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                MessageBox.Show("Grup seçimi boş olamaz", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand($"INSERT INTO Hissedarlar (AdSoyad, Telefon, AgirlikAraligi, AtandiMi) VALUES ('{txtAdSoyad.Text}', '{txtTelNo.Text}', '{comboGrup.SelectedItem.ToString()}', 0)",baglanti);
                komut.ExecuteNonQuery();

                refreshTable();
                baglanti.Close();

                // sonraki girdi için textboxları boşalt
                txtAdSoyad.Text = "";
                txtTelNo.Text = "";
                comboGrup.SelectedItem = null;
            }


        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                object secili = dataGridView1.CurrentRow.Cells["ID"].Value;

                if (secili != null)
                {

                    baglanti.Open();
                    int seciliID = Convert.ToInt32(secili);
                    SqlCommand komut = new SqlCommand($"DELETE FROM Hissedarlar WHERE ID = {seciliID}", baglanti);
                    komut.ExecuteNonQuery();

                    refreshTable();
                    baglanti.Close();
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
            refreshTable();
        }

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
            DialogResult dr = MessageBox.Show("Tüm hissedarları silmek ve ID'leri sıfırlamak istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.OK)
            {
                string connectionString = @"Server=.\SQLEXPRESS;Database=KurbanDB;Trusted_Connection=True;";
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    baglanti.Open();
                    SqlTransaction transaction = baglanti.BeginTransaction();

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

                        using (SqlCommand guncelle = new SqlCommand($"UPDATE Hissedarlar SET AtandiMi = 1", baglanti))
                        {
                            guncelle.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        refreshTable();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

    }
}
