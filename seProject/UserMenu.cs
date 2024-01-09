using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SE_Project
{
    public partial class UserMenu : Form
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WatermarkPage wp = new WatermarkPage();
            wp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ValidatePage vp = new ValidatePage();
            vp.Show();
            this.Hide();
        }

        private void UserMenu_Load(object sender, EventArgs e)
        {
            label2.Text = "Hello: " + CurrentUser.UserName.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    public static class LSBAlgorithm
    {
        public static void EmbedText(Bitmap imagePath, string textToEmbed)
        {
            string outputImagePath = "watermarked_image.png"; 

            try
            {
                Bitmap image = new Bitmap(imagePath);
                int textIndex = 0;

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        if (textIndex < textToEmbed.Length)
                        {
                            char charToEmbed = textToEmbed[textIndex];
                            int charValue = (int)charToEmbed;

                            int newRed = EmbedLSB(image.GetPixel(x, y).R, (charValue >> 7) & 0x01);
                            int newGreen = EmbedLSB(image.GetPixel(x, y).G, (charValue >> 6) & 0x01);
                            int newBlue = EmbedLSB(image.GetPixel(x, y).B, (charValue >> 5) & 0x01);

                            Color newPixel = Color.FromArgb(image.GetPixel(x, y).A, newRed, newGreen, newBlue);

                            image.SetPixel(x, y, newPixel);

                            charValue <<= 1;

                            if ((charValue & 0x0100) == 0x0100)
                            {
                                textIndex++; 
                            }
                        }
                        else
                        {
                            break; 
                        }
                    }

                    if (textIndex >= textToEmbed.Length)
                    {
                        break; 
                    }
                }

                image.Save(outputImagePath);
                image.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error embedding text: {ex.Message}");
            }
        }


        private static int EmbedLSB(int pixelValue, int bitToEmbed)
        {
            return (pixelValue & 0xFE) | (bitToEmbed & 0x01);
        }


        public static string ExtractText(Bitmap imagePath)
        {
            try
            {
                Bitmap image = new Bitmap(imagePath);
                int charValue = 0;
                int bitIndex = 0;
                StringBuilder extractedText = new StringBuilder();
                bool messageEnd = false;

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        if (!messageEnd)
                        {
                            int redLSB = ExtractLSB(image.GetPixel(x, y).R);
                            int greenLSB = ExtractLSB(image.GetPixel(x, y).G);
                            int blueLSB = ExtractLSB(image.GetPixel(x, y).B);

                            charValue = (charValue << 1) | redLSB;
                            charValue = (charValue << 1) | greenLSB;
                            charValue = (charValue << 1) | blueLSB;

                            bitIndex += 3; 

                            if (bitIndex >= 8)
                            {
                                char extractedChar = (char)charValue;

                                if (extractedChar == '\0')
                                {
                                    messageEnd = true;
                                    break;
                                }

                                extractedText.Append(extractedChar);

                                charValue = 0;
                                bitIndex = 0;
                            }
                        }
                        else
                        {
                            break; 
                        }
                    }

                    if (messageEnd)
                    {
                        break; 
                    }
                }

                return extractedText.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting text: {ex.Message}");
                return string.Empty;
            }
        }
        private static int ExtractLSB(int pixelValue)
        {
            return pixelValue & 0x01;
        }
    }
 }