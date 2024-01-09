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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace SE_Project
{

    public partial class WatermarkPage : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=WatermarkDB.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        SQLiteDataReader dr;
        public WatermarkPage()
        {
            InitializeComponent();
        }

        private bool IsSupportedImageFormat(string filePath)
        {
            string[] supportedExtensions = { ".png", ".gif", ".bmp" };
            string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();
            return supportedExtensions.Contains(fileExtension);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.png;*.gif;*.bmp|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    if (!IsSupportedImageFormat(imagePath))
                    {
                        MessageBox.Show("The selected file is not in a supported image format. Please select a PNG, GIF, or BMP file.", "Unsupported Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        pic_ImageToWatermark.Image = new System.Drawing.Bitmap(imagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void btn_downloadImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|GIF Image|*.gif|Bitmap Image|*.bmp";
                saveFileDialog.FileName = "watermarked_image"; 

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                        ImageFormat format = GetImageFormat(extension);

                        pic_watermarkedImg.Image.Save(saveFileDialog.FileName, format);
                        MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private ImageFormat GetImageFormat(string extension)
        {
            switch (extension)
            {
                case ".png":
                    return ImageFormat.Png;
                case ".gif":
                    return ImageFormat.Gif;
                case ".bmp":
                    return ImageFormat.Bmp;
                default:
                    return ImageFormat.Png;
            }
        }

        private void btn_watermark_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap imageToWatermark = (Bitmap)pic_ImageToWatermark.Image;

                if (imageToWatermark != null)
                {
                    string textToEmbed = txt_embedText.Text;

                    if (!string.IsNullOrEmpty(textToEmbed))
                    {

                        LSBAlgorithm.EmbedText(imageToWatermark, textToEmbed);

                        pic_watermarkedImg.Image = imageToWatermark;

                        MessageBox.Show("Text successfully embedded.");
                        try
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "INSERT INTO UserData (userID, imgText, img) VALUES (@usrID, @Text, @Image)";

                            MemoryStream memoryStream = new MemoryStream();
                            imageToWatermark.Save(memoryStream, ImageFormat.Png);
                            cmd.Parameters.AddWithValue("@usrID", CurrentUser.UserId);
                            cmd.Parameters.AddWithValue("@Text", textToEmbed.ToString());
                            cmd.Parameters.AddWithValue("@Image", memoryStream.ToArray());

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Your data has been added to the database");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter text to embed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please load an image in the PictureBox to watermark.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UserMenu userMenu = new UserMenu();
            userMenu.Show();
            this.Hide();
        }

        private void WatermarkPage_Load(object sender, EventArgs e)
        {

        }

        private void WatermarkPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }

}



