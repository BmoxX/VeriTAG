using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Project
{
    public partial class ValidatePage : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=WatermarkDB.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        SQLiteDataReader dr;
        public ValidatePage()
        {
            InitializeComponent();
        }

        private void btn_watermark_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap watermarkedImage = (Bitmap)pic_Watermarked.Image;

                if (watermarkedImage != null)
                {
                    string extractedText = LSBAlgorithm.ExtractText(watermarkedImage);

                    txt_extractText.Text = extractedText.ToString();

                    MessageBox.Show($"Extracted watermark text: {extractedText}");

                    try
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT * FROM Users WHERE userID=@usrID AND img=@Image";

                        MemoryStream memoryStream = new MemoryStream();
                        watermarkedImage.Save(memoryStream, ImageFormat.Png);

                        cmd.Parameters.AddWithValue("@usrID", CurrentUser.UserId);
                        cmd.Parameters.AddWithValue("@Image", memoryStream.ToArray());

                        MessageBox.Show(dr["imgText"].ToString());

                        if (extractedText.ToString() == dr["imgText"].ToString())
                        {
                            MessageBox.Show("User Authentication Succussed");
                        }
                        else
                        {
                            MessageBox.Show("User Authentication Failed");
                        }
                    }
                    catch(Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please load a watermarked image in the PictureBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_selectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.png;*.gif;*.bmp|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    try
                    {
                        pic_Watermarked.Image = new Bitmap(imagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserMenu userMenu = new UserMenu();
            userMenu.Show();
            this.Hide();
        }

        private void txt_extractText_TextChanged(object sender, EventArgs e)
        {

        }

        private void ValidatePage_Load(object sender, EventArgs e)
        {

        }
    }

}
