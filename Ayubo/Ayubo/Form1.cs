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

namespace Ayubo
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAB01-PC27;Initial Catalog=Ayubo;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                con.Open();
                string sqlst;
                sqlst = "Select * From Vehicle Where reg_no = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlst, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr["vehic_type"].ToString();
                    textBox3.Text = dr["make"].ToString();
                    textBox4.Text = dr["day_rate"].ToString();
                    textBox5.Text = dr["week_rate"].ToString();
                    textBox6.Text = dr["Month_rate"].ToString();
                    textBox7.Text = dr["driver_rate"].ToString();
                }
                else
                {
                    MessageBox.Show("Details not found");
                }
            con.Close();
          

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string sqlst;
                sqlst = " Insert Into Vehicle Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlst, con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Records added successfully");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Database");
            }
            finally
            {
                con.Close();
                textBox1.Focus();
            }
            

           

        }
    }
}
