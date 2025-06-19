namespace kurbanv1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            TopAgirlik = new DataGridViewTextBoxColumn();
            etAgirlik = new DataGridViewTextBoxColumn();
            karkasAgirlik = new DataGridViewTextBoxColumn();
            randiman = new DataGridViewTextBoxColumn();
            hisseKG = new DataGridViewTextBoxColumn();
            hisseAdet = new DataGridViewTextBoxColumn();
            durum = new DataGridViewComboBoxColumn();
            hissedarlar = new DataGridViewTextBoxColumn();
            textBox1 = new TextBox();
            label1 = new Label();
            btnKaydet = new Button();
            btnYukle = new Button();
            btnHissedarTablo = new Button();
            btnHayvanEkle = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TopAgirlik, etAgirlik, karkasAgirlik, randiman, hisseKG, hisseAdet, durum, hissedarlar });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1135, 687);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // TopAgirlik
            // 
            TopAgirlik.Frozen = true;
            TopAgirlik.HeaderText = "Toplam Ağırlık";
            TopAgirlik.Name = "TopAgirlik";
            // 
            // etAgirlik
            // 
            etAgirlik.Frozen = true;
            etAgirlik.HeaderText = "Et";
            etAgirlik.Name = "etAgirlik";
            // 
            // karkasAgirlik
            // 
            karkasAgirlik.Frozen = true;
            karkasAgirlik.HeaderText = "Karkas";
            karkasAgirlik.Name = "karkasAgirlik";
            // 
            // randiman
            // 
            randiman.Frozen = true;
            randiman.HeaderText = "Randıman";
            randiman.Name = "randiman";
            randiman.Width = 120;
            // 
            // hisseKG
            // 
            hisseKG.Frozen = true;
            hisseKG.HeaderText = "Hisse Kg";
            hisseKG.Name = "hisseKG";
            // 
            // hisseAdet
            // 
            hisseAdet.Frozen = true;
            hisseAdet.HeaderText = "Hisse Adet";
            hisseAdet.Name = "hisseAdet";
            // 
            // durum
            // 
            durum.FlatStyle = FlatStyle.Flat;
            durum.HeaderText = "Durum";
            durum.Items.AddRange(new object[] { "Bekliyor", "Bitti", "Kesildi" });
            durum.Name = "durum";
            durum.Sorted = true;
            durum.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // hissedarlar
            // 
            hissedarlar.HeaderText = "Hissedarlar";
            hissedarlar.Name = "hissedarlar";
            hissedarlar.Width = 400;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1199, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(172, 26);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1153, 17);
            label1.Name = "label1";
            label1.Size = new Size(40, 21);
            label1.TabIndex = 2;
            label1.Text = "Ara:";
            label1.Click += label1_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(1288, 776);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(83, 36);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnYukle
            // 
            btnYukle.Location = new Point(1199, 776);
            btnYukle.Name = "btnYukle";
            btnYukle.Size = new Size(83, 36);
            btnYukle.TabIndex = 4;
            btnYukle.Text = "Yükle";
            btnYukle.UseVisualStyleBackColor = true;
            // 
            // btnHissedarTablo
            // 
            btnHissedarTablo.Location = new Point(1199, 735);
            btnHissedarTablo.Name = "btnHissedarTablo";
            btnHissedarTablo.Size = new Size(172, 35);
            btnHissedarTablo.TabIndex = 5;
            btnHissedarTablo.Text = "Hissedar Tablosu";
            btnHissedarTablo.UseVisualStyleBackColor = true;
            btnHissedarTablo.Click += btnHissedarTablo_Click;
            // 
            // btnHayvanEkle
            // 
            btnHayvanEkle.Location = new Point(1199, 694);
            btnHayvanEkle.Name = "btnHayvanEkle";
            btnHayvanEkle.Size = new Size(172, 35);
            btnHayvanEkle.TabIndex = 6;
            btnHayvanEkle.Text = "Hayvan Ekle";
            btnHayvanEkle.UseVisualStyleBackColor = true;
            btnHayvanEkle.Click += btnHayvanEkle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1383, 815);
            Controls.Add(btnHayvanEkle);
            Controls.Add(btnHissedarTablo);
            Controls.Add(btnYukle);
            Controls.Add(btnKaydet);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Font = new Font("Sitka Text", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kurban Takip";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Label label1;
        private Button btnKaydet;
        private Button btnYukle;
        private DataGridViewTextBoxColumn TopAgirlik;
        private DataGridViewTextBoxColumn etAgirlik;
        private DataGridViewTextBoxColumn karkasAgirlik;
        private DataGridViewTextBoxColumn randiman;
        private DataGridViewTextBoxColumn hisseKG;
        private DataGridViewTextBoxColumn hisseAdet;
        private DataGridViewComboBoxColumn durum;
        private DataGridViewTextBoxColumn hissedarlar;
        private Button btnHissedarTablo;
        private Button btnHayvanEkle;
    }
}