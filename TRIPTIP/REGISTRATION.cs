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
    public partial class REGISTRATION : Form
    {
        public int ID { get; set; }
        public String us_name { get; set; }
        public String pass { get; set; }
        public String gender { get; set; }
        public String email { get; set; }
        public String address { get; set; }
        public String dob { get; set; }
        public String con_pass { get; set; }
        public String Ph_number { get; set; }
        
        public REGISTRATION()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QH85R68\\SQLEXPRESS;Initial Catalog=TripTip;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)//Submit Button
        {
            try
            {
                string query = "INSERT INTO registration (USERNAME,PASSWORD,CONFIRM PASSWORD, E-mail, DOB, ADDRESS, GENDER, PHONE NUMBER)" +
               " VALUES (@USERNAME, @PASSWORD, @CONFIRM PASSWORD, @E-mail, @DOB, @ADDRESS, @GENDER, @PHONE NUMBER)";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with their values
                    cmd.Parameters.AddWithValue("@USERNAME", reg_us_name.Text);
                    cmd.Parameters.AddWithValue("@PASSWORD", reg_pass.Text);
                    cmd.Parameters.AddWithValue("@CONFIRM PASSWORD", reg_con_pass.Text);
                    cmd.Parameters.AddWithValue("@E-mail", reg_email.Text);
                    cmd.Parameters.AddWithValue("@DOB", reg_date.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@ADDRESS", reg_address.Text);
                    cmd.Parameters.AddWithValue("@GENDER", reg_gender.Text);
                    cmd.Parameters.AddWithValue("@PHONE NUMBER", reg_ph_number.Text);

                    con.Open();
                    // Use ExecuteNonQuery for INSERT, UPDATE, DELETE queries
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Registration successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void REGISTRATION_Load(object sender, EventArgs e)
        {
            regdata();
        }
        private void regdata()
       {
            SqlCommand cmd = new SqlCommand("Select from registration",con);
            DataTable dt = new DataTable();
            con.Open();
            con.Close();
            
        }

        
    }
        
}

