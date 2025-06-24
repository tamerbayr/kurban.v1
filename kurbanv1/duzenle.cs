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
        static string data = Application.StartupPath;
        static string connectionString = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={data}\kurbanDB.mdf;Initial Catalog=kurbanDB;Integrated Security=True;";
        SqlConnection baglanti = new SqlConnection(connectionString);

        private int seciliHayvanID;
        //ana formda hayvanTablosunuYukle() çalıştırarak listeyi güncellemek için
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
            using (baglanti)
            {
                baglanti.Open();

                // boştakileri ve bu hayvana atanmış hissedarları getir
                SqlCommand komut = new SqlCommand($"SELECT Id, AdSoyad, Telefon, AgirlikAraligi FROM Hissedarlar WHERE AtandiMi = 0 OR Id IN (SELECT HissedarID FROM HayvanHissedar WHERE HayvanID = {seciliHayvanID})", baglanti);

                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    checkedListBox1.Items.Add(new ListItem { Text = dr["AdSoyad"].ToString() + "\tTelefon: " + dr["Telefon"].ToString() + "\tGrup: " + dr["AgirlikAraligi"].ToString(), Value = Convert.ToInt32(dr["Id"]) });
                }
                dr.Close();

                // seçili hayvana atanmışları işaretle
                SqlCommand seciliKomut = new SqlCommand($"SELECT HissedarID FROM HayvanHissedar WHERE HayvanID = {seciliHayvanID}", baglanti);
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
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("En az 1 hissedar seçilmeli.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (baglanti)
            {
                baglanti.Open();

                // ilişki ve hissedarlar tablosunda bu hayvana ait olan girdileri temizle
                SqlCommand sifirlaKomut = new SqlCommand($"UPDATE Hissedarlar SET AtandiMi = 0 WHERE Id IN (SELECT HissedarID FROM HayvanHissedar WHERE HayvanID = {seciliHayvanID})", baglanti);
                sifirlaKomut.ExecuteNonQuery();
                SqlCommand silKomut = new SqlCommand($"DELETE FROM HayvanHissedar WHERE HayvanID = {seciliHayvanID}", baglanti);
                silKomut.ExecuteNonQuery();

                // ilişki ve hissedar tablosuna tekrar yaz
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    int hissedarID = ((ListItem)item).Value;

                    SqlCommand ekleKomut = new SqlCommand($"INSERT INTO HayvanHissedar (HayvanID, HissedarID) VALUES ({seciliHayvanID}, {hissedarID})", baglanti);
                    ekleKomut.ExecuteNonQuery();

                    SqlCommand atandiKomut = new SqlCommand($"UPDATE Hissedarlar SET AtandiMi = 1 WHERE Id = {hissedarID}", baglanti);
                    atandiKomut.ExecuteNonQuery();
                }

                SqlCommand kisiBasiEtGuncelle = new SqlCommand($"UPDATE Hayvanlar SET KisiBasiEt = ToplamEt / (SELECT COUNT(*) FROM HayvanHissedar WHERE HayvanID = {seciliHayvanID}) WHERE Id = {seciliHayvanID}", baglanti);
                kisiBasiEtGuncelle.ExecuteNonQuery();

                // ana formu güncelle
                anaform.hayvanTablosunuYukle();
                baglanti.Close();
            }

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
