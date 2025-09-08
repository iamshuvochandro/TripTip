using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRIPTIP
{
    public partial class ADMIN : Form
    {
        public ADMIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //ad_Sign in Buttoon
        {
                if (string.IsNullOrEmpty(ad_us_name.Text) || string.IsNullOrEmpty(ad_pass.Text))
                {
                    MessageBox.Show(" INVALID USERNAME OR PASSWORD ");
                }
                else
                {
                    MessageBox.Show(" DATA STORED ");
                }
            
        }
    }
}
