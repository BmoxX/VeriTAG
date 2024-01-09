namespace SE_Project
{
    partial class ValidatePage
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
            this.btn_watermark = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_extractText = new System.Windows.Forms.TextBox();
            this.btn_selectImage = new System.Windows.Forms.Button();
            this.pic_Watermarked = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Watermarked)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_watermark
            // 
            this.btn_watermark.Location = new System.Drawing.Point(372, 265);
            this.btn_watermark.Name = "btn_watermark";
            this.btn_watermark.Size = new System.Drawing.Size(148, 51);
            this.btn_watermark.TabIndex = 12;
            this.btn_watermark.Text = "Extract Watermark";
            this.btn_watermark.UseVisualStyleBackColor = true;
            this.btn_watermark.Click += new System.EventHandler(this.btn_watermark_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Extracted Text";
            // 
            // txt_extractText
            // 
            this.txt_extractText.Location = new System.Drawing.Point(268, 337);
            this.txt_extractText.Multiline = true;
            this.txt_extractText.Name = "txt_extractText";
            this.txt_extractText.Size = new System.Drawing.Size(356, 73);
            this.txt_extractText.TabIndex = 10;
            this.txt_extractText.TextChanged += new System.EventHandler(this.txt_extractText_TextChanged);
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Location = new System.Drawing.Point(105, 122);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(148, 35);
            this.btn_selectImage.TabIndex = 9;
            this.btn_selectImage.Text = "Select Image";
            this.btn_selectImage.UseVisualStyleBackColor = true;
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
            // 
            // pic_Watermarked
            // 
            this.pic_Watermarked.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pic_Watermarked.Location = new System.Drawing.Point(268, 42);
            this.pic_Watermarked.Name = "pic_Watermarked";
            this.pic_Watermarked.Size = new System.Drawing.Size(356, 194);
            this.pic_Watermarked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Watermarked.TabIndex = 8;
            this.pic_Watermarked.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 45);
            this.button1.TabIndex = 13;
            this.button1.Text = "<-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ValidatePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_watermark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_extractText);
            this.Controls.Add(this.btn_selectImage);
            this.Controls.Add(this.pic_Watermarked);
            this.Name = "ValidatePage";
            this.Text = "ValidatePage";
            this.Load += new System.EventHandler(this.ValidatePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Watermarked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_watermark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_extractText;
        private System.Windows.Forms.Button btn_selectImage;
        private System.Windows.Forms.PictureBox pic_Watermarked;
        private System.Windows.Forms.Button button1;
    }
}