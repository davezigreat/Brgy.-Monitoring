using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + Application.StartupPath +@"\Database1.accdb");
            OleDbCommand cmd = new OleDbCommand();
            int i = 0;
            try 
            {
              if ((txtuser.Text == string.Empty) || txtpass.Text == string.Empty)
                {
                    MessageBox.Show("Fill up empty space");
                }

                  cmd = new OleDbCommand("Select count(*)from LogIn where Username ='" + txtuser.Text + "'AND Password ='" + txtpass.Text + "'", con);
                   if (con.State == ConnectionState.Closed)
                {
                          con.Open();
                        i = (int)cmd.ExecuteScalar();
                }
                if (i > 0)
                {
                    MessageBox.Show("Succesfully Logged In!");
                      Form2 mn = new Form2();
                    this.Hide();
                       mn.Show();
                       
                
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
