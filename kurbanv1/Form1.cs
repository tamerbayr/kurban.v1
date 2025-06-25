using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.SqlClient;

namespace kurbanv1
{
    public partial class Form1 : Form
    {

        private DataTable hayvanTablosu = new DataTable();
        static string data = Application.StartupPath;
        static string connectionString = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={data}\kurbanDB.mdf;Initial Catalog=kurbanDB;Integrated Security=True;";
        SqlConnection baglanti = new SqlConnection(connectionString);


        public Form1()
        {
            InitializeComponent();
            hayvanTablosunuYukle();
            btnYenile.Visible = false;
            btnTamSil.Visible = false;
        }

        public void hayvanTablosunuYukle()
        {
            string dbPath =  @$"{AppDomain.CurrentDomain.BaseDirectory}\kurbanDB.mdf";
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                SqlCommand sqlcommand = new SqlCommand(@"SELECT 
                                     H.Id AS HayvanID, 
                                     H.Agirlik, 
                                     H.RandimanOrani, 
                                     H.ToplamEt,
                                     H.KisiBasiEt,
                                     H.HissedarAdedi AS BeklenenHissedarSayisi,
                                     COUNT(DISTINCT HH.HissedarID) AS AtananHissedarSayisi,
                                     ISNULL(STRING_AGG(Hs.AdSoyad + ' (' + Hs.Telefon + ')', ', '), 'Atama Yok') AS Hissedarlar
                                     FROM Hayvanlar H
                                     LEFT JOIN HayvanHissedar HH ON H.Id = HH.HayvanID
                                     LEFT JOIN Hissedarlar Hs ON Hs.Id = HH.HissedarID
                                     GROUP BY H.Id, H.Agirlik, H.RandimanOrani, H.ToplamEt, H.KisiBasiEt, H.HissedarAdedi
                                     ORDER BY H.Id", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(sqlcommand);
                hayvanTablosu.Clear();
                da.Fill(hayvanTablosu);
                dataGridView1.DataSource = hayvanTablosu;

                // nedense boyutları düzenlemiyor
                dataGridView1.Columns[0].Width = (int)(dataGridView1.Width * 0.05);
                dataGridView1.Columns[1].Width = (int)(dataGridView1.Width * 0.1);
                dataGridView1.Columns[2].Width = (int)(dataGridView1.Width * 0.1);
                dataGridView1.Columns[3].Width = (int)(dataGridView1.Width * 0.1);
                dataGridView1.Columns[4].Width = (int)(dataGridView1.Width * 0.1);
                dataGridView1.Columns[5].Width = (int)(dataGridView1.Width * 0.05);
                dataGridView1.Columns[6].Width = (int)(dataGridView1.Width * 0.05);
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                baglanti.Close();
            }
        }


        private void btnHissedarTablo_Click(object sender, EventArgs e)
        {
            hissedarTablosu hissedarTablo = new hissedarTablosu();
            hissedarTablo.Show();
        }

        private void btnHayvanEkle_Click(object sender, EventArgs e)
        {
            if (txtToplamAgirlik == null) { MessageBox.Show("Ağırlık bölümü boş olamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtToplamAgirlik.Text.Trim() == "" || txtToplamAgirlik.Text.Trim() == "_____")
            {
                MessageBox.Show("Ağırlık bölümü boş olamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int agirlikDegeri = Convert.ToInt32(txtToplamAgirlik.Text.Trim());
            if (agirlikDegeri <= 0)
            {
                MessageBox.Show("Hatalı ağırlık girildi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int randimanRakamSayisi = txtRandiman.Text.Count(char.IsDigit);
            if (randimanRakamSayisi <= 1 || randimanRakamSayisi > 3)
            {
                MessageBox.Show("Randıman bölümü hatalı girildi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int randimanDegeri = Convert.ToInt32(txtRandiman.Text.Trim());
            if (randimanDegeri < 0 || randimanDegeri > 100)
            {
                MessageBox.Show("Randıman hatalı girildi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int hisseDegeri = Convert.ToInt32(txtHisseAdet.Text.Trim());
            if (hisseDegeri < 1 || hisseDegeri > 20)
            {
                MessageBox.Show("Hisse adet bölümü hatalı.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // girdileri al
            int toplamAgirlik = Convert.ToInt32(txtToplamAgirlik.Text);
            decimal randimanOran = Convert.ToDecimal(txtRandiman.Text);
            int hisseAdet = Convert.ToInt32(txtHisseAdet.Text);
            string grupTabloAdi = "";

            // hesaplamalar
            decimal toplamEt = toplamAgirlik * randimanOran / 100;
            decimal atik = toplamAgirlik - toplamEt;
            decimal kisiBasiEt = toplamEt / hisseAdet;

            // gruplandırma
            if (kisiBasiEt >= 40 && kisiBasiEt < 45)
                grupTabloAdi = "40-45";
            else if (kisiBasiEt >= 45 && kisiBasiEt < 50)
                grupTabloAdi = "45-50";
            else if (kisiBasiEt >= 50 && kisiBasiEt <= 55)
                grupTabloAdi = "50-55";
            else if (kisiBasiEt < 40)
            {
                DialogResult dr1 = MessageBox.Show($"Kişi başı et miktarı {kisiBasiEt}KG minimum değerden az. 40-45 grubuna eklensin mi?", "Uyarı!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr1 == DialogResult.OK)
                    grupTabloAdi = "40-45";
                else { return; }
            }
            else if (kisiBasiEt > 55)
            {
                DialogResult dr1 = MessageBox.Show($"Kişi başı et miktarı {kisiBasiEt}KG maksimum değerden fazla. 50-55 grubuna eklensin mi?", "Uyarı!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr1 == DialogResult.OK)
                    grupTabloAdi = "50-55";
                else { return; }
            }
            else
            {
                MessageBox.Show("Bu ağırlıkta uygun grup yok.");
                return;
            }

            // veritabanı işlemi
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kurbanDB.mdf");
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                SqlCommand hisseKomut = new SqlCommand($"SELECT TOP {hisseAdet} * FROM Hissedarlar WHERE AtandiMi = 0 AND AgirlikAraligi = '{grupTabloAdi}'", baglanti);
                SqlDataReader dr = hisseKomut.ExecuteReader();

                // hisse adedi kadar boş hissedar çek
                List<int> hissedarIDs = new List<int>();
                while (dr.Read())
                {
                    hissedarIDs.Add(Convert.ToInt32(dr["ID"]));
                }
                dr.Close();

                // hissedar tablosu boş ise
                if (hissedarIDs.Count == 0) { MessageBox.Show("Hissedar sayısı 0. Atama yapılamadı", "Hata!"); baglanti.Close(); return; }

                // hissedar sayısı yetersiz ise uyarı (evet dendiğinde devam ediyor)
                if (hissedarIDs.Count < hisseAdet)
                {
                    DialogResult dr1 = MessageBox.Show($"İstenen hissedar sayısı ({hisseAdet}), kalan hissedar sayısından ({hissedarIDs.Count}) fazla.\nDevam edilsin mi?", "Eksik Hissedar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr1 == DialogResult.No) { baglanti.Close(); return; }
                }
                
                // hissedar sayısı yetersiz olabileceğinden kişibaşıet değerini güncelle
                kisiBasiEt = toplamEt / hissedarIDs.Count;

                // hayvan tablosuna ekle
                SqlCommand hayvanKomut = new SqlCommand($"INSERT INTO Hayvanlar (Agirlik, RandimanOrani, HissedarAdedi, ToplamEt, KisiBasiEt) VALUES ({toplamAgirlik}, {randimanOran}, {hisseAdet}, {toplamEt}, {kisiBasiEt}); SELECT SCOPE_IDENTITY();", baglanti);

                // hayvanhissedar ilişki tablosuna ekle
                int yeniHayvanID = Convert.ToInt32(hayvanKomut.ExecuteScalar());
                foreach (int id in hissedarIDs)
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO HayvanHissedar (HayvanID, HissedarID) VALUES (@hayvanID, @hissedarID)", baglanti);
                    ekle.Parameters.AddWithValue("@hayvanID", yeniHayvanID);
                    ekle.Parameters.AddWithValue("@hissedarID", id);
                    ekle.ExecuteNonQuery();

                    // AtandiMi güncelle
                    SqlCommand guncelle = new SqlCommand("UPDATE Hissedarlar SET AtandiMi = 1 WHERE Id = @id", baglanti);
                    guncelle.Parameters.AddWithValue("@id", id);
                    guncelle.ExecuteNonQuery();
                }
                txtHisseAdet.Text = "";
                txtToplamAgirlik.Text = "";
                txtRandiman.Text = "";
                hayvanTablosunuYukle();
                baglanti.Close();
            }
        }

        private void txtAramaKutusu_TextChanged(object sender, EventArgs e)
        {
            DataView dv = hayvanTablosu.DefaultView;

            if (txtAramaKutusu.Text.Trim() == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter = $"Hissedarlar LIKE '%{txtAramaKutusu.Text.Trim()}%'";
            }
            dataGridView1.DataSource = dv;
        }

        private void btnHayvanSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmek için bir hayvan seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            DialogResult dr = MessageBox.Show("Seçili hayvanı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) { return; }
            int hayvanID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["HayvanID"].Value);
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kurbanDB.mdf");

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                // atanan hissedar atandimi 0 yap
                SqlCommand updateAtandi = new SqlCommand($"UPDATE Hissedarlar SET AtandiMi = 0 WHERE Id IN (SELECT HissedarID FROM HayvanHissedar WHERE HayvanID = {hayvanID})", baglanti);
                updateAtandi.ExecuteNonQuery();

                // hayvanhissedar ilişki tablosundan sil
                SqlCommand silHissedarlar = new SqlCommand($"DELETE FROM HayvanHissedar WHERE HayvanID = {hayvanID}", baglanti);
                silHissedarlar.ExecuteNonQuery();

                // hayvanlar tablosundan sil
                SqlCommand silHayvan = new SqlCommand($"DELETE FROM Hayvanlar WHERE Id = {hayvanID}", baglanti);
                silHayvan.ExecuteNonQuery();

                baglanti.Close();
            }

            hayvanTablosunuYukle();
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            hayvanTablosunuYukle();
        }

        // gizli butonlar gösterme
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                btnYenile.Visible = false;
                btnTamSil.Visible = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                btnYenile.Visible = true;
                btnTamSil.Visible = true;
            }
        }

        private void btnTamSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tüm hayvanları ve ilişkileri silmek ve ID'leri sıfırlamak istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.OK)
            {
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kurbanDB.mdf");
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    baglanti.Open();
                SqlTransaction transaction = baglanti.BeginTransaction();

                    try
                    {
                        using (SqlCommand hayvanHissedarKomut = new SqlCommand("DELETE FROM HayvanHissedar", baglanti, transaction))
                        {
                            hayvanHissedarKomut.ExecuteNonQuery();
                        }

                        using (SqlCommand hayvanKomut = new SqlCommand("DELETE FROM Hayvanlar", baglanti, transaction))
                        {
                            hayvanKomut.ExecuteNonQuery();
                        }

                        using (SqlCommand hayvanKomut2 = new SqlCommand("DBCC CHECKIDENT('Hayvanlar', RESEED, 0)", baglanti, transaction))
                        {
                            hayvanKomut2.ExecuteNonQuery();
                        }

                        using (SqlCommand hayvanHissedarKomut2 = new SqlCommand("DBCC CHECKIDENT('HayvanHissedar', RESEED, 0)", baglanti, transaction))
                        {
                            hayvanHissedarKomut2.ExecuteNonQuery();
                        }

                        using (SqlCommand guncelle = new SqlCommand($"UPDATE Hissedarlar SET AtandiMi = 0", baglanti, transaction))
                        {
                            guncelle.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        hayvanTablosunuYukle();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        baglanti.Close();
                        MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        baglanti.Close();
                    }
                }

            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir hayvan seçiniz.");
                baglanti.Close();
                return;
            }

            int seciliHayvanID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["HayvanID"].Value);
            duzenle duzenleForm = new duzenle(this, seciliHayvanID);
            duzenleForm.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            hayvanTablosunuYukle();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnDuzenle.Enabled = dataGridView1.SelectedRows.Count > 0;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns.Count >= 5 && e.RowIndex >= 0)
            {
                // Hissedar sayısı olan hücreden değerleri al
                int hissedarAdedi = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["BeklenenHissedarSayisi"].Value);
                int atananHissedar = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["AtananHissedarSayisi"].Value);

                // Eğer atama eksikse hücreyi renklendir
                if (atananHissedar < hissedarAdedi)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
