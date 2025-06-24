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
            txtAramaKutusu = new TextBox();
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
            btnYenile = new Button();
            btnTamSil = new Button();
            btnDuzenle = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1135, 687);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // txtAramaKutusu
            // 
            txtAramaKutusu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAramaKutusu.Location = new Point(1199, 12);
            txtAramaKutusu.Name = "txtAramaKutusu";
            txtAramaKutusu.Size = new Size(172, 26);
            txtAramaKutusu.TabIndex = 1;
            txtAramaKutusu.TextChanged += txtAramaKutusu_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(1153, 17);
            label1.Name = "label1";
            label1.Size = new Size(40, 21);
            label1.TabIndex = 2;
            label1.Text = "Ara:";
            // 
            // btnHissedarTablo
            // 
            btnHissedarTablo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            btnHayvanEkle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(1153, 138);
            label2.Name = "label2";
            label2.Size = new Size(118, 21);
            label2.TabIndex = 7;
            label2.Text = "Toplam Ağırlık:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(1153, 210);
            label3.Name = "label3";
            label3.Size = new Size(130, 21);
            label3.TabIndex = 9;
            label3.Text = "Randıman Oranı:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(1153, 284);
            label4.Name = "label4";
            label4.Size = new Size(99, 21);
            label4.TabIndex = 11;
            label4.Text = "Hisse Adedi:";
            // 
            // txtToplamAgirlik
            // 
            txtToplamAgirlik.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtToplamAgirlik.Location = new Point(1153, 162);
            txtToplamAgirlik.Mask = "00000";
            txtToplamAgirlik.Name = "txtToplamAgirlik";
            txtToplamAgirlik.Size = new Size(218, 26);
            txtToplamAgirlik.TabIndex = 12;
            txtToplamAgirlik.ValidatingType = typeof(int);
            // 
            // txtRandiman
            // 
            txtRandiman.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRandiman.Location = new Point(1153, 234);
            txtRandiman.Mask = "00000";
            txtRandiman.Name = "txtRandiman";
            txtRandiman.Size = new Size(218, 26);
            txtRandiman.TabIndex = 13;
            txtRandiman.ValidatingType = typeof(int);
            // 
            // txtHisseAdet
            // 
            txtHisseAdet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtHisseAdet.Location = new Point(1153, 308);
            txtHisseAdet.Mask = "00000";
            txtHisseAdet.Name = "txtHisseAdet";
            txtHisseAdet.Size = new Size(218, 26);
            txtHisseAdet.TabIndex = 14;
            txtHisseAdet.ValidatingType = typeof(int);
            // 
            // btnHayvanSil
            // 
            btnHayvanSil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHayvanSil.Location = new Point(1153, 411);
            btnHayvanSil.Name = "btnHayvanSil";
            btnHayvanSil.Size = new Size(218, 51);
            btnHayvanSil.TabIndex = 15;
            btnHayvanSil.Text = "Hayvan Sil";
            btnHayvanSil.UseVisualStyleBackColor = true;
            btnHayvanSil.Click += btnHayvanSil_Click;
            // 
            // btnYenile
            // 
            btnYenile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnYenile.Location = new Point(12, 705);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(113, 49);
            btnYenile.TabIndex = 16;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = true;
            btnYenile.Click += yenile_Click;
            // 
            // btnTamSil
            // 
            btnTamSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTamSil.Location = new Point(12, 760);
            btnTamSil.Name = "btnTamSil";
            btnTamSil.Size = new Size(113, 49);
            btnTamSil.TabIndex = 17;
            btnTamSil.Text = "Tam Sil";
            btnTamSil.UseVisualStyleBackColor = true;
            btnTamSil.Click += btnTamSil_Click;
            // 
            // btnDuzenle
            // 
            btnDuzenle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDuzenle.Location = new Point(1153, 468);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(218, 51);
            btnDuzenle.TabIndex = 18;
            btnDuzenle.Text = "Düzenle";
            btnDuzenle.UseVisualStyleBackColor = true;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1383, 815);
            Controls.Add(btnDuzenle);
            Controls.Add(btnTamSil);
            Controls.Add(btnYenile);
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
            Controls.Add(txtAramaKutusu);
            Controls.Add(dataGridView1);
            Font = new Font("Sitka Text", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kurban Takip";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtAramaKutusu;
        private Label label1;
        private Button btnHissedarTablo;
        private Button btnHayvanEkle;
        private Label label2;
        private Label label3;
        private Label label4;
        private MaskedTextBox txtToplamAgirlik;
        private MaskedTextBox txtRandiman;
        private MaskedTextBox txtHisseAdet;
        private Button btnHayvanSil;
        private Button btnYenile;
        private Button btnTamSil;
        private Button btnDuzenle;
    }
}