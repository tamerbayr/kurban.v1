namespace kurbanv1
{
    partial class hissedarTablosu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            comboGrup = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtAdSoyad = new TextBox();
            txtTelNo = new MaskedTextBox();
            btnEkle = new Button();
            btnSil = new Button();
            btnYenile = new Button();
            btnTamSil = new Button();
            label4 = new Label();
            txtAramaKutusu = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 17);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(723, 505);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // comboGrup
            // 
            comboGrup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboGrup.FormattingEnabled = true;
            comboGrup.Items.AddRange(new object[] { "40-45", "45-50", "50-55" });
            comboGrup.Location = new Point(743, 240);
            comboGrup.Margin = new Padding(4);
            comboGrup.Name = "comboGrup";
            comboGrup.Size = new Size(266, 29);
            comboGrup.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(743, 86);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 21);
            label1.TabIndex = 4;
            label1.Text = "Adı Soyadı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(743, 151);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 5;
            label2.Text = "Telefon No";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(742, 215);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 21);
            label3.TabIndex = 6;
            label3.Text = "Grup";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(743, 111);
            txtAdSoyad.Margin = new Padding(4);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(266, 26);
            txtAdSoyad.TabIndex = 1;
            // 
            // txtTelNo
            // 
            txtTelNo.Location = new Point(745, 175);
            txtTelNo.Mask = "(999) 000-0000";
            txtTelNo.Name = "txtTelNo";
            txtTelNo.Size = new Size(264, 26);
            txtTelNo.TabIndex = 7;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(745, 291);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(264, 50);
            btnEkle.TabIndex = 8;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(743, 347);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(132, 50);
            btnSil.TabIndex = 9;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnYenile
            // 
            btnYenile.Location = new Point(882, 347);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(132, 50);
            btnYenile.TabIndex = 10;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = true;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnTamSil
            // 
            btnTamSil.Location = new Point(15, 558);
            btnTamSil.Name = "btnTamSil";
            btnTamSil.Size = new Size(132, 50);
            btnTamSil.TabIndex = 11;
            btnTamSil.Text = "Tam Sil";
            btnTamSil.UseVisualStyleBackColor = true;
            btnTamSil.Visible = false;
            btnTamSil.Click += btnTamSil_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(747, 22);
            label4.Name = "label4";
            label4.Size = new Size(40, 21);
            label4.TabIndex = 13;
            label4.Text = "Ara:";
            // 
            // txtAramaKutusu
            // 
            txtAramaKutusu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAramaKutusu.Location = new Point(793, 17);
            txtAramaKutusu.Name = "txtAramaKutusu";
            txtAramaKutusu.Size = new Size(172, 26);
            txtAramaKutusu.TabIndex = 12;
            txtAramaKutusu.TextChanged += txtAramaKutusu_TextChanged_1;
            // 
            // hissedarTablosu
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1029, 630);
            Controls.Add(label4);
            Controls.Add(txtAramaKutusu);
            Controls.Add(btnTamSil);
            Controls.Add(btnYenile);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(txtTelNo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboGrup);
            Controls.Add(txtAdSoyad);
            Controls.Add(dataGridView1);
            Font = new Font("Sitka Text", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "hissedarTablosu";
            ShowIcon = false;
            Text = "hissedarTablosu";
            Load += hissedarTablosu_Load;
            KeyDown += hissedarTablosu_KeyDown;
            KeyUp += hissedarTablosu_KeyUp;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboGrup;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtAdSoyad;
        private MaskedTextBox txtTelNo;
        private Button btnEkle;
        private Button btnSil;
        private Button btnYenile;
        private Button btnTamSil;
        private Label label4;
        private TextBox txtAramaKutusu;
    }
}