using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Nemiro.OAuth;
using Nemiro.OAuth.LoginForms;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace KennenAdmin
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = String.Empty;
            webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            webBrowser1.Navigate(new Uri("https://www.youtube.com/"));
            webBrowser2.Hide();
        }
        private void browser_NavigateError(object sender, WebBrowserNavigatingEventArgs e) //WebBrowserNavigateErrorEventArgs
        {
            if (webBrowser2.ScriptErrorsSuppressed)
            {
                webBrowser2.DocumentCompleted -= browser_DocumentCompleted;
                webBrowser2.ScriptErrorsSuppressed = false;
                webBrowser2.Stop();
                webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted_Error);
            }
        }
        private void browser_DocumentCompleted_Error(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            webBrowser2.DocumentCompleted -= browser_DocumentCompleted_Error;
            webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);

            webBrowser2.Navigate(new Uri("http://www.hideoxy.com/service/page.php?u=Z80qqYl1puDoTfVeYq3pP0uzahE%3D&b=5"));

        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs args)
        {
            webBrowser2.ScriptErrorsSuppressed = true;
            
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                info.Url = textBox1.Text;
                SaveXML.SaveData(info, "Data.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XDocument doc;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            doc = XDocument.Load("Data.xml");
            doc.Save(appPath + "\\" + "Data.xml");
            FileStream upstream = new FileStream((appPath + "\\" + "Data.xml").ToString(), FileMode.Open);
            OAuthUtility.PutAsync
                         (
                         "https://api-content.dropbox.com/1/files_put/auto//",
                         new HttpParameterCollection
                {
                    {"access_token",Properties.Settings.Default.AccessToken},
                    {"path",Path.Combine(Path.GetFileName("Data.xml")).Replace("\\","/")},
                    {"overwrite","true"},
                    {"autorename","true"},
                    {upstream}
                },
                         callback: Upload_Result
                         );
            link();
        }
        private void Upload_Result(RequestResult result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<RequestResult>(Upload_Result), result);
                return;

            }
        }
        private void link()
        {

            OAuthUtility.PostAsync
            (
              "https://api.dropbox.com/1/shares/auto/",
                new HttpParameterCollection
                {
                    {"path",Path.Combine(Path.GetFileName("Data.xml")).Replace("\\","/") },
                    {"access_token",Properties.Settings.Default.AccessToken },
                    {"short_url","false"}
                },
                callback: GetShareLink_Result
             );
        }
        private void GetShareLink_Result(RequestResult result)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                webBrowser2.Show();
                webBrowser2.Navigate(new Uri("http://de.proxfree.com/permalink.php?url=s54aaHA%2FaGsaD5vHs0QZLcUclS%2FcUxrnNZwEMCiA0I8%3D&bit=1"));
            }
            if(checkBox1.Checked == false)
            {
                webBrowser1.Navigate(new Uri("https://www.youtube.com/"));
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void sendURLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                webBrowser1.Navigate(new Uri("http://de.proxfree.com/permalink.php?url=s54aaHA%2FaGsaD5vHs0QZLcUclS%2FcUxrnNZwEMCiA0I8%3D&bit=1"));
            }
            if (checkBox1.Checked == false)
            {
                webBrowser1.Navigate(new Uri("http://de.proxfree.com/permalink.php?url=s54aaHA%2FaGsaD5vHs0QZLcUclS%2FcUxrnNZwEMCiA0I8%3D&bit=1"));
            }
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                info.Url = textBox1.Text;
                SaveXML.SaveData(info, "Data.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void sendToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            XDocument doc;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            doc = XDocument.Load("Data.xml");
            doc.Save(appPath + "\\" + "Data.xml");
            FileStream upstream = new FileStream((appPath + "\\" + "Data.xml").ToString(), FileMode.Open);
            OAuthUtility.PutAsync
                         (
                         "https://api-content.dropbox.com/1/files_put/auto//",
                         new HttpParameterCollection
                {
                    {"access_token",Properties.Settings.Default.AccessToken},
                    {"path",Path.Combine(Path.GetFileName("Data.xml")).Replace("\\","/")},
                    {"overwrite","true"},
                    {"autorename","true"},
                    {upstream}
                },
                         callback: Upload_Result
                         );
            link();
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                
                webBrowser1.Hide();
                webBrowser2.Show();
                webBrowser2.ScriptErrorsSuppressed = false;
                webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
                webBrowser2.Navigate(new Uri("http://www.hideoxy.com/service/page.php?u=Z80qqYl1puDoTfVeYq3pP0uzahE%3D&b=5"));
            }
            if (checkBox1.Checked == false)
            {
                
                webBrowser2.Hide();
                webBrowser1.Show();
                webBrowser1.Navigate(new Uri("https://www.youtube.com/"));
            }
        }

        private void webBrowser2_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser2.Url.ToString();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                info.Url = textBox1.Text;
                SaveXML.SaveData(info, "Data.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void sendToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            XDocument doc;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            doc = XDocument.Load("Data.xml");
            doc.Save(appPath + "\\" + "Data.xml");
            FileStream upstream = new FileStream((appPath + "\\" + "Data.xml").ToString(), FileMode.Open);
            OAuthUtility.PutAsync
                         (
                         "https://api-content.dropbox.com/1/files_put/auto//",
                         new HttpParameterCollection
                {
                    {"access_token",Properties.Settings.Default.AccessToken},
                    {"path",Path.Combine(Path.GetFileName("Data.xml")).Replace("\\","/")},
                    {"overwrite","true"},
                    {"autorename","true"},
                    {upstream}
                },
                         callback: Upload_Result
                         );
            link();
        }

        private void webBrowser1_Navigated_1(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }
    }
}