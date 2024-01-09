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

namespace SE_Project
{
    public partial class SignUpPage : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=WatermarkDB.db;Version=3;");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        SQLiteDataReader dr;
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_usrName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            cmd.Connection = con;
            string userName = txt_usrName.Text;
            string password = txt_password.Text;
            string confPassword = txt_confPass.Text;
            if (userName!= "" && password!="" && password==confPassword )
            {
                    try
                    {
                    con.Open();
                    cmd.CommandText = "Insert Into Users (UserName, HashedPassword) values (@usrName, @pass)";

                    cmd.Parameters.AddWithValue("@usrName", userName);
                    cmd.Parameters.AddWithValue("@pass", password);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    MessageBox.Show("Welcome to our community");



                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User registered successfully.");

                        cmd.CommandText = "SELECT userID FROM Users WHERE UserName=@usrName";
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                CurrentUser.UserName = userName;
                                CurrentUser.UserId = Convert.ToInt32(dr["userID"]);
                            }
                        }

                        UserMenu um = new UserMenu();
                        um.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("User registration failed.");
                    }
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

               
        }

        private void SignUpPage_Load(object sender, EventArgs e)
        {
        }
    }
}
