using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

        public static string CaesarCipherEncrypt(string text, int shift)
        {
            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    letter = (char)(letter + shift);

                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }
                }
                buffer[i] = letter;
            }
            return new string(buffer);
        }


        public static byte[] CalculateImageHash(byte[] imageData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(imageData);
                return hashBytes;
            }
        }

        private void btn_watermark_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap watermarkedImage = (Bitmap)pic_Watermarked.Image;

                if (watermarkedImage != null)
                {
                    string extractedText = LSBAlgorithm.ExtractText(watermarkedImage);

                    string decryptedText = CaesarCipherEncrypt(extractedText, -10);

                    lbl_extractText.Text = decryptedText.ToString();

                    try
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT * FROM UserData WHERE userID=@usrID AND imgHash=@userImageHash";

                        MemoryStream memoryStream = new MemoryStream();
                        watermarkedImage.Save(memoryStream, ImageFormat.Png);
                        byte[] userImageHash = CalculateImageHash(memoryStream.ToArray());

                        cmd.Parameters.AddWithValue("@usrID", CurrentUser.UserId);
                        cmd.Parameters.AddWithValue("@userImageHash", userImageHash);

                        using (dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string imgText = dr["imgText"].ToString();

                                if (decryptedText == imgText)
                                {
                                    MessageBox.Show("User Authentication Succeeded");
                                }
                                else
                                {
                                    MessageBox.Show("User Authentication Failed");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No matching record found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
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

        private void lbl_extractText_Click(object sender, EventArgs e)
        {

        }
    }

}
