using System.Data.SqlClient;

namespace kurbanv1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void btnHissedarTablo_Click(object sender, EventArgs e)
        {
            hissedarTablosu hissedarTablo = new hissedarTablosu();
            hissedarTablo.Show();
        }

        private void btnHayvanEkle_Click(object sender, EventArgs e)
        {
            if (txtToplamAgirlik == null)
            {
                MessageBox.Show("Ağırlık bölümü boş olamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtRandiman == null)
            {
                MessageBox.Show("Randıman bölümü boş olamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtHisseAdet == null)
            {
                MessageBox.Show("Hisse adet bölümü boş olamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else
                    return;
            }
            else if (kisiBasiEt > 55)
            {
                DialogResult dr1 = MessageBox.Show($"Kişi başı et miktarı {kisiBasiEt}KG maksimum değerden fazla. 50-55 grubuna eklensin mi?", "Uyarı!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr1 == DialogResult.OK)
                    grupTabloAdi = "50-55";
                else
                    return;
            }
            else
            {
                MessageBox.Show("Bu ağırlıkta uygun grup yok.");
                return;
            }

            // veritabanı işlemi
            using (SqlConnection baglanti = new SqlConnection(@"Server=.\SQLEXPRESS;Database=KurbanDB;Trusted_Connection=True;"))
            {
                baglanti.Open();

                // hisse adedi kadar boş hissedar çek
                SqlCommand komut = new SqlCommand($"SELECT TOP {hisseAdet} * FROM Hissedarlar WHERE AtandiMi = 0 AND AgirlikAraligi = '{grupTabloAdi}'", baglanti);
                SqlDataReader dr = komut.ExecuteReader();

                List<int> secilenIDs = new List<int>();
                while (dr.Read())
                {
                    secilenIDs.Add(Convert.ToInt32(dr["ID"]));
                }
                dr.Close();

                // seçilenlerin AtandiMi'ni True yap
                foreach (int id in secilenIDs)
                {
                    SqlCommand guncelle = new SqlCommand($"UPDATE Hissedarlar SET AtandiMi = 1 WHERE ID = {id}", baglanti);
                    guncelle.ExecuteNonQuery();
                }

                baglanti.Close();
            }

        }
    }
}