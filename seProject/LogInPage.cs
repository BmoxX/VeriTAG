using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Net.Mime.MediaTypeNames;

namespace SE_Project
{
    public partial class LogInPage : Form
    {

        SQLiteConnection con = new SQLiteConnection("Data Source=WatermarkDB.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        SQLiteDataReader dr;
  
        public LogInPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LogInPage_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txt_usrName.Text;
            string password = txt_password.Text; 

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Users WHERE UserName=@usrName AND HashedPassword=@pass";
            cmd.Parameters.AddWithValue("@usrName", userName);
            cmd.Parameters.AddWithValue("@pass", password); 

            try
            {
                con.Open();
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read()) 
                    {
                        CurrentUser.UserName = userName;
                        CurrentUser.UserId = int.Parse(dr["userID"].ToString());

                        MessageBox.Show($"Welcome {userName}");

                        UserMenu um = new UserMenu();
                        um.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("User not found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void LogInPage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
