namespace SE_Project
{
    partial class WatermarkPage
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
            this.pic_ImageToWatermark = new System.Windows.Forms.PictureBox();
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.txt_embedText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pic_watermarkedImg = new System.Windows.Forms.PictureBox();
            this.btn_downloadImage = new System.Windows.Forms.Button();
            this.btn_watermark = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ImageToWatermark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_watermarkedImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_ImageToWatermark
            // 
            this.pic_ImageToWatermark.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pic_ImageToWatermark.Location = new System.Drawing.Point(220, 69);
            this.pic_ImageToWatermark.Name = "pic_ImageToWatermark";
            this.pic_ImageToWatermark.Size = new System.Drawing.Size(356, 194);
            this.pic_ImageToWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ImageToWatermark.TabIndex = 0;
            this.pic_ImageToWatermark.TabStop = false;
            this.pic_ImageToWatermark.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Location = new System.Drawing.Point(46, 149);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(148, 35);
            this.btn_selectImage.TabIndex = 1;
            this.btn_selectImage.Text = "Select Image";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_embedText
            // 
            this.txt_embedText.Location = new System.Drawing.Point(220, 292);
            this.txt_embedText.Multiline = true;
            this.txt_embedText.Name = "txt_embedText";
            this.txt_embedText.Size = new System.Drawing.Size(356, 73);
            this.txt_embedText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Text";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(637, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 449);
            this.label2.TabIndex = 4;
            // 
            // pic_watermarkedImg
            // 
            this.pic_watermarkedImg.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pic_watermarkedImg.Location = new System.Drawing.Point(686, 69);
            this.pic_watermarkedImg.Name = "pic_watermarkedImg";
            this.pic_watermarkedImg.Size = new System.Drawing.Size(356, 194);
            this.pic_watermarkedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_watermarkedImg.TabIndex = 5;
            this.pic_watermarkedImg.TabStop = false;
            // 
            // btn_downloadImage
            // 
            this.btn_downloadImage.Location = new System.Drawing.Point(794, 303);
            this.btn_downloadImage.Name = "btn_downloadImage";
            this.btn_downloadImage.Size = new System.Drawing.Size(148, 35);
            this.btn_downloadImage.TabIndex = 6;
            this.btn_downloadImage.Text = "Download Image";
            this.btn_downloadImage.UseVisualStyleBackColor = true;
            this.btn_downloadImage.Click += new System.EventHandler(this.btn_downloadImage_Click);
            // 
            // btn_watermark
            // 
            this.btn_watermark.Location = new System.Drawing.Point(329, 396);
            this.btn_watermark.Name = "btn_watermark";
            this.btn_watermark.Size = new System.Drawing.Size(148, 35);
            this.btn_watermark.TabIndex = 7;
            this.btn_watermark.Text = "Watermark";
            this.btn_watermark.UseVisualStyleBackColor = true;
            this.btn_watermark.Click += new System.EventHandler(this.btn_watermark_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 45);
            this.button1.TabIndex = 14;
            this.button1.Text = "<-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // WatermarkPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 466);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_watermark);
            this.Controls.Add(this.btn_downloadImage);
            this.Controls.Add(this.pic_watermarkedImg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_embedText);
            this.Controls.Add(this.btn_selectImage);
            this.Controls.Add(this.pic_ImageToWatermark);
            this.Name = "WatermarkPage";
            this.Text = "WatermarkPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WatermarkPage_FormClosing);
            this.Load += new System.EventHandler(this.WatermarkPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_ImageToWatermark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_watermarkedImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_ImageToWatermark;
        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.TextBox txt_embedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pic_watermarkedImg;
        private System.Windows.Forms.Button btn_downloadImage;
        private System.Windows.Forms.Button btn_watermark;
        private System.Windows.Forms.Button button1;
    }
}