using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nemiro.OAuth;
using Nemiro.OAuth.LoginForms;

namespace KennenAdmin
{
    public partial class Dropbox : Form
    {
        public Dropbox()
        {
            InitializeComponent();
        }

        private void DropboxLogin_Load(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Properties.Settings.Default.AccessToken))
            {
                this.GetAccessToken();
            }
            else
            {
                this.GetFiles();
            }

        }
        private void GetAccessToken()
        {

            var login = new DropboxLogin("yxk0rl5wlff50vc", "rqcvwt7pmmqubpp");
            login.Owner = this;
            login.ShowDialog();
            if (login.IsSuccessfully)
            {
                Properties.Settings.Default.AccessToken = login.AccessToken.Value;
                Properties.Settings.Default.Save();
                this.Hide();
                Form F6 = new Bridge();
                F6.ShowDialog();
                this.Close();
            }
            else
            {

                this.Close();
            }


        }

        private void GetFiles()
        {
            
            Form F6 = new Bridge();
            F6.ShowDialog();
            this.Hide();
        }
    }
}
