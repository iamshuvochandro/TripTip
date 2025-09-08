using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TRIPTIP
{
    public partial class Form1 : Form
    {
        public String us_name { get; set; }
        public String pass { get; set; }
        public String gender { get; set; }
        public String email { get; set; }
        public String address { get; set; }
        public String dob { get; set; }
        public String con_pass { get; set; }
        public String Ph_number { get; set; }
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QH85R68\SQLEXPRESS;Initial Catalog=TripTip;Integrated Security=True");
        public void clean()
        {
            login_pass = null;
            login_us_name = null;

        }
        private void button1_Click(object sender, EventArgs e) //exit button
        {
            if (MessageBox.Show("Do you really want to exit the application?", "Exit Window",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void button3_Click(object sender, EventArgs e) //clear button
        {
            login_us_name.Clear();
            login_pass.Clear();
            login_us_name.Focus();
            clean();
        }

        private void button2_Click(object sender, EventArgs e) //sign in button
        {
            
            String USERNAME = login_us_name.Text;
            String PASSWORD = login_pass.Text;
            try
            {
                String que = "SELECT * FROM logIn WHERE USERNAME = '" + login_us_name.Text + "'AND PASSWORD = '"+login_pass.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(que,con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    USERNAME = login_us_name.Text;
                    PASSWORD = login_pass.Text;
                
                    new TripTip().Show();
                    this.Hide();                   
                }
                else
                {
                    MessageBox.Show(" INVALID LOGIN ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    login_us_name.Clear();
                    login_pass.Clear();
                    
                }    
            }
            catch
            {
                MessageBox.Show(" Error ");
              
            }
            finally
            {
                con.Close();
            }
           // if (string.IsNullOrEmpty() || string.IsNullOrEmpty(login_pass.Text))
           //{
           //     MessageBox.Show(" INVALID USERNAME OR PASSWORD ");
           // }
           // else
           // {
           //     MessageBox.Show(" DATA STORED ");
           // }
        }
       

        private void button5_Click(object sender, EventArgs e) //registration button
        {
            REGISTRATION r = new REGISTRATION();
            r.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e) //Admin button
        {
            ADMIN a = new ADMIN();
            a.Show();
        }
    }
}
