namespace FinalUAS_FK
{
    partial class Form1
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
            this.btnSuplier = new System.Windows.Forms.Button();
            this.btnPenjual = new System.Windows.Forms.Button();
            this.btnProduk = new System.Windows.Forms.Button();
            this.btnPelanggan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSuplier
            // 
            this.btnSuplier.Location = new System.Drawing.Point(65, 197);
            this.btnSuplier.Name = "btnSuplier";
            this.btnSuplier.Size = new System.Drawing.Size(113, 59);
            this.btnSuplier.TabIndex = 0;
            this.btnSuplier.Text = "Suplier";
            this.btnSuplier.UseVisualStyleBackColor = true;
            this.btnSuplier.Click += new System.EventHandler(this.btnSuplier_Click);
            // 
            // btnPenjual
            // 
            this.btnPenjual.Location = new System.Drawing.Point(235, 197);
            this.btnPenjual.Name = "btnPenjual";
            this.btnPenjual.Size = new System.Drawing.Size(113, 59);
            this.btnPenjual.TabIndex = 1;
            this.btnPenjual.Text = "Penjual";
            this.btnPenjual.UseVisualStyleBackColor = true;
            this.btnPenjual.Click += new System.EventHandler(this.btnPenjual_Click);
            // 
            // btnProduk
            // 
            this.btnProduk.Location = new System.Drawing.Point(420, 197);
            this.btnProduk.Name = "btnProduk";
            this.btnProduk.Size = new System.Drawing.Size(113, 59);
            this.btnProduk.TabIndex = 2;
            this.btnProduk.Text = "Produk";
            this.btnProduk.UseVisualStyleBackColor = true;
            this.btnProduk.Click += new System.EventHandler(this.btnProduk_Click);
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.Location = new System.Drawing.Point(595, 197);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Size = new System.Drawing.Size(113, 59);
            this.btnPelanggan.TabIndex = 3;
            this.btnPelanggan.Text = "Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
            this.btnPelanggan.Click += new System.EventHandler(this.btnPelanggan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 75);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pemesanan Baju";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPelanggan);
            this.Controls.Add(this.btnProduk);
            this.Controls.Add(this.btnPenjual);
            this.Controls.Add(this.btnSuplier);
            this.Name = "Form1";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSuplier;
        private System.Windows.Forms.Button btnPenjual;
        private System.Windows.Forms.Button btnProduk;
        private System.Windows.Forms.Button btnPelanggan;
        private System.Windows.Forms.Label label1;
    }
}

