using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace KennenAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string ConnectionString = ConfigurationManager.ConnectionStrings["KennenAdmin"].ToString();
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox3.Hide();
            butonu.FlatAppearance.BorderSize = 0;
            butonu.FlatAppearance.MouseOverBackColor = BackColor;
            butonu.FlatAppearance.MouseDownBackColor = BackColor;
            butonu.FlatAppearance.BorderColor = Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
                  {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlDataAdapter adapt = new SqlDataAdapter("Select Count(*) From Admin Where Username = '" + textBox1.Text + "' And Password = '" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Form F7 = new Dropbox();
                F7.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
                  }
            catch
            {
                MessageBox.Show("A error has ocured");
            }
        }  
            

        private void textBox1_Enter(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
            else if (textBox1.Text != "Username")
            {

            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Username")
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Username";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
            else if (textBox2.Text != "Password")
            {

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.Text == "Password")
            {
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "Password";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butonu_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Show();
            pictureBox2.Hide();
        }

        private void butonu_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Show();
            pictureBox3.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            butonu.PerformClick();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
        }

    }
}
