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
            artikAgirlik = new DataGridViewTextBoxColumn();
            randiman = new DataGridViewTextBoxColumn();
            hisseKG = new DataGridViewTextBoxColumn();
            hisseAdet = new DataGridViewTextBoxColumn();
            durum = new DataGridViewComboBoxColumn();
            hissedarlar = new DataGridViewTextBoxColumn();
            textBox1 = new TextBox();
            label1 = new Label();
            btnHissedarTablo = new Button();
            btnHayvanEkle = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtToplamAgirlik = new MaskedTextBox();
            txtRandiman = new MaskedTextBox();
            txtHisseAdet = new MaskedTextBox();
            btnHayvanSil = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TopAgirlik, etAgirlik, artikAgirlik, randiman, hisseKG, hisseAdet, durum, hissedarlar });
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
            // artikAgirlik
            // 
            artikAgirlik.Frozen = true;
            artikAgirlik.HeaderText = "Artik";
            artikAgirlik.Name = "artikAgirlik";
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
            // btnHissedarTablo
            // 
            btnHissedarTablo.Location = new Point(1153, 752);
            btnHissedarTablo.Name = "btnHissedarTablo";
            btnHissedarTablo.Size = new Size(218, 51);
            btnHissedarTablo.TabIndex = 5;
            btnHissedarTablo.Text = "Hissedar Tablosu";
            btnHissedarTablo.UseVisualStyleBackColor = true;
            btnHissedarTablo.Click += btnHissedarTablo_Click;
            // 
            // btnHayvanEkle
            // 
            btnHayvanEkle.Location = new Point(1153, 354);
            btnHayvanEkle.Name = "btnHayvanEkle";
            btnHayvanEkle.Size = new Size(218, 51);
            btnHayvanEkle.TabIndex = 6;
            btnHayvanEkle.Text = "Hayvan Ekle";
            btnHayvanEkle.UseVisualStyleBackColor = true;
            btnHayvanEkle.Click += btnHayvanEkle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1153, 138);
            label2.Name = "label2";
            label2.Size = new Size(118, 21);
            label2.TabIndex = 7;
            label2.Text = "Toplam Ağırlık:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1153, 210);
            label3.Name = "label3";
            label3.Size = new Size(130, 21);
            label3.TabIndex = 9;
            label3.Text = "Randıman Oranı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1153, 284);
            label4.Name = "label4";
            label4.Size = new Size(99, 21);
            label4.TabIndex = 11;
            label4.Text = "Hisse Adedi:";
            // 
            // txtToplamAgirlik
            // 
            txtToplamAgirlik.Location = new Point(1153, 162);
            txtToplamAgirlik.Mask = "00000";
            txtToplamAgirlik.Name = "txtToplamAgirlik";
            txtToplamAgirlik.Size = new Size(218, 26);
            txtToplamAgirlik.TabIndex = 12;
            txtToplamAgirlik.ValidatingType = typeof(int);
            // 
            // txtRandiman
            // 
            txtRandiman.Location = new Point(1153, 234);
            txtRandiman.Mask = "00000";
            txtRandiman.Name = "txtRandiman";
            txtRandiman.Size = new Size(218, 26);
            txtRandiman.TabIndex = 13;
            txtRandiman.ValidatingType = typeof(int);
            // 
            // txtHisseAdet
            // 
            txtHisseAdet.Location = new Point(1153, 308);
            txtHisseAdet.Mask = "00000";
            txtHisseAdet.Name = "txtHisseAdet";
            txtHisseAdet.Size = new Size(218, 26);
            txtHisseAdet.TabIndex = 14;
            txtHisseAdet.ValidatingType = typeof(int);
            // 
            // btnHayvanSil
            // 
            btnHayvanSil.Location = new Point(1153, 411);
            btnHayvanSil.Name = "btnHayvanSil";
            btnHayvanSil.Size = new Size(218, 51);
            btnHayvanSil.TabIndex = 15;
            btnHayvanSil.Text = "Hayvan Sil";
            btnHayvanSil.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1383, 815);
            Controls.Add(btnHayvanSil);
            Controls.Add(txtHisseAdet);
            Controls.Add(txtRandiman);
            Controls.Add(txtToplamAgirlik);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnHayvanEkle);
            Controls.Add(btnHissedarTablo);
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
        private Button btnHissedarTablo;
        private Button btnHayvanEkle;
        private DataGridViewTextBoxColumn TopAgirlik;
        private DataGridViewTextBoxColumn etAgirlik;
        private DataGridViewTextBoxColumn artikAgirlik;
        private DataGridViewTextBoxColumn randiman;
        private DataGridViewTextBoxColumn hisseKG;
        private DataGridViewTextBoxColumn hisseAdet;
        private DataGridViewComboBoxColumn durum;
        private DataGridViewTextBoxColumn hissedarlar;
        private Label label2;
        private Label label3;
        private Label label4;
        private MaskedTextBox txtToplamAgirlik;
        private MaskedTextBox txtRandiman;
        private MaskedTextBox txtHisseAdet;
        private Button btnHayvanSil;
    }
}