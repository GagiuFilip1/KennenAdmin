using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KennenAdmin
{
    public partial class Bridge : Form
    {
        public Bridge()
        {
            InitializeComponent();
        }

        private void Bridge_Load(object sender, EventArgs e)
        {
            Form F1 = new Admin();
            F1.ShowDialog();
            this.Hide();
        }
    }
}
