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
    public partial class Form2 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath +@"\Database21.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        string _lname, _fname, _mname, _houseno, _purokno, _gender, _age, _religion, _cpno, _occupation, _telno, _businessadd, _civilstatus;
       string _bdate;
        public Form2()
        {
            InitializeComponent();
            con.Open();
        }

        private void LoadRecords()
        {
            
            dataGridView1.Rows.Clear();
            cmd = new OleDbCommand("Select * from TABLE2", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(5), dr.GetValue(6), dr.GetValue(7), dr.GetValue(8), dr.GetValue(9), dr.GetValue(10), dr.GetValue(11), dr.GetValue(12), dr.GetValue(13));
            }
            dr.Close();
            con.Close();
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from table2 where LastName='" + txtlname.Text + "'";
            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Successfully Deleted!");
            LoadRecords();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string _date = dateTimePicker1.Value.ToString("MM/dd/yy");
            con.Open();
           cmd = new OleDbCommand("insert into Table2 values('" + txtlname.Text + "','" + txtfname.Text + "','" + txtmname.Text + "','" + txthbox.Text + "','" + cmbox1.Text + "','" + cmbox2.Text + "','" + txtboxage.Text + "','" + txtboxrlgn.Text + "','" + txtboxcp.Text + "','"+ _date.ToString() + "','" + txtboxocptn.Text + "','" + txtboxtel.Text + "','" + txtboxba.Text + "','" + cmbox3.Text + "')", con);
           cmd.ExecuteNonQuery();
           MessageBox.Show("Successfully Added!");
            LoadRecords();
            con.Close();

        }
       
        private void btnview_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            
            

        }


        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtlname.Text = _lname;
            txtfname.Text = _fname;
            txtmname.Text = _mname;
            txthbox.Text = _houseno;
            cmbox1.Text = _purokno;
            cmbox2.Text = _gender;
            txtboxage.Text = _age;
            txtboxrlgn.Text = _religion;
            txtboxcp.Text = _cpno;
            //dateTimePicker1. = _bdate;
            txtboxocptn.Text = _occupation;
            txtboxtel.Text = _telno;
            txtboxba.Text = _businessadd;
            cmbox3.Text = _civilstatus;

        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index ;
            _lname = dataGridView1[0, i].Value.ToString();
            _fname = dataGridView1[1, i].Value.ToString();
            _mname = dataGridView1[2, i].Value.ToString();
            _houseno = dataGridView1[3, i].Value.ToString();
            _purokno = dataGridView1[4, i].Value.ToString();
            _gender = dataGridView1[5, i].Value.ToString();
            _age = dataGridView1[6, i].Value.ToString();
            _religion = dataGridView1[7, i].Value.ToString();
            _cpno = dataGridView1[8, i].Value.ToString();
            _bdate = dataGridView1[9, i].Value.ToString();
            _occupation = dataGridView1[10, i].Value.ToString();
            _telno = dataGridView1[11, i].Value.ToString();
            _businessadd = dataGridView1[12, i].Value.ToString();
            _civilstatus = dataGridView1[13,i].Value.ToString();

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            con.Open();
            LoadRecords();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image image = Image.FromFile(ofd.FileName);
                pictureBox2.ImageLocation = ofd.FileName;

            }

        }
    }
}
