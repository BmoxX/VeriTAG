using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Project
{

    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SignUpPage sgUp = new SignUpPage();
            sgUp.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LogInPage lgIn = new LogInPage();
            lgIn.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static string UserName { get; set; } = "User";
    }
}
