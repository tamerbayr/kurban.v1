using Microsoft.VisualBasic;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace kurbanv1
{
    public partial class duzenle : Form
    {
        private int seciliHayvanID;
        Form1 anaform;

        public duzenle(Form1 form, int ID)
        {
            InitializeComponent();
            seciliHayvanID = ID;
            anaform = form;
        }


        public class ListItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        private void duzenle_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            string connectionString = @"Server=.\SQLEXPRESS;Database=KurbanDB;Trusted_Connection=True;";
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                // Boştakileri ve bu hayvana atanmış hissedarları getir
                SqlCommand komut = new SqlCommand(
                    "SELECT Id, AdSoyad FROM Hissedarlar WHERE AtandiMi = 0 OR Id IN (SELECT HissedarID FROM HayvanHissedar WHERE HayvanID = @hayvanID)",
                    baglanti);
                komut.Parameters.AddWithValue("@hayvanID", seciliHayvanID);

                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(new ListItem { Text = dr["AdSoyad"].ToString(), Value = Convert.ToInt32(dr["Id"]) });
                }
                dr.Close();

                // Seçili hayvana atanmışları işaretle
                SqlCommand seciliKomut = new SqlCommand("SELECT HissedarID FROM HayvanHissedar WHERE HayvanID = @hayvanID", baglanti);
                seciliKomut.Parameters.AddWithValue("@hayvanID", seciliHayvanID);
                SqlDataReader dr2 = seciliKomut.ExecuteReader();
                while (dr2.Read())
                {
                    int hissedarID = Convert.ToInt32(dr2["HissedarID"]);
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (((ListItem)checkedListBox1.Items[i]).Value == hissedarID)
                            checkedListBox1.SetItemChecked(i, true);
                    }
                }
                dr2.Close();
                baglanti.Close();
            }
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Boş seçim kontrolü
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("En az 1 hissedar seçilmeli.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = @"Server=.\SQLEXPRESS;Database=KurbanDB;Trusted_Connection=True;";
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                // Bu hayvana ait tüm hissedarları ve atama bilgilerini temizle
                SqlCommand silKomut = new SqlCommand("DELETE FROM HayvanHissedar WHERE HayvanID = @hayvanID", baglanti);
                silKomut.Parameters.AddWithValue("@hayvanID", seciliHayvanID);
                silKomut.ExecuteNonQuery();

                SqlCommand sifirlaKomut = new SqlCommand("UPDATE Hissedarlar SET AtandiMi = 0 WHERE Id IN (SELECT HissedarID FROM HayvanHissedar WHERE HayvanID = @hayvanID)", baglanti);
                sifirlaKomut.Parameters.AddWithValue("@hayvanID", seciliHayvanID);
                sifirlaKomut.ExecuteNonQuery();

                // Yeni seçimleri ekle
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    int hissedarID = ((ListItem)item).Value;

                    // HayvanHissedar tablosuna ekle
                    SqlCommand ekleKomut = new SqlCommand("INSERT INTO HayvanHissedar (HayvanID, HissedarID) VALUES (@hayvanID, @hissedarID)", baglanti);
                    ekleKomut.Parameters.AddWithValue("@hayvanID", seciliHayvanID);
                    ekleKomut.Parameters.AddWithValue("@hissedarID", hissedarID);
                    ekleKomut.ExecuteNonQuery();

                    // AtandiMi güncelle
                    SqlCommand atandiKomut = new SqlCommand("UPDATE Hissedarlar SET AtandiMi = 1 WHERE Id = @id", baglanti);
                    atandiKomut.Parameters.AddWithValue("@id", hissedarID);
                    atandiKomut.ExecuteNonQuery();
                }

                // Kişi başı et güncelle
                SqlCommand kisiBasiEtGuncelle = new SqlCommand("UPDATE Hayvanlar SET KisiBasiEt = ToplamEt / (SELECT COUNT(*) FROM HayvanHissedar WHERE HayvanID = @hayvanID) WHERE Id = @hayvanID", baglanti);
                kisiBasiEtGuncelle.Parameters.AddWithValue("@hayvanID", seciliHayvanID);
                kisiBasiEtGuncelle.ExecuteNonQuery();

                // Ana formu güncelle
                anaform.hayvanTablosunuYukle();

                baglanti.Close();
            }

        }
    }
}
