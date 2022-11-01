using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidLabExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string discription = textBox2.Text;
            string deadline = dateTimePicker1.Text;
            string type = " ";
            string level = " ";

            if(radioButton1.Checked == true)
            {
                type = "Home Task";
            }
            else if (radioButton2.Checked == true)
            {
                type = "University Task";
            }

            if (radioButton3.Checked == true)
            {
                level = "Important";
            }
            else if (radioButton4.Checked == true)
            {
                level = "Normal";
            }

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fatim\source\repos\MidLabExam\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            string query = "INSERT INTO myData(taskTitle, taskDiscription, taskType, taskLevel, taskDeadline) VALUES('"+title+"','"+discription+"','"+type+"','"+level+"','"+deadline+"')";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            int i= cmd.ExecuteNonQuery();

            if (i > 0)
            {
                MessageBox.Show("Data Inserted","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (i == 0)
            {
                MessageBox.Show("Data Not Inserted","INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //For all data Showing 

            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\fatim\source\repos\MidLabExam\Database1.mdf; Integrated Security = True");

            SqlCommand cmd = new SqlCommand("select * from myData", con);

            con.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\fatim\source\repos\MidLabExam\Database1.mdf; Integrated Security = True");

            SqlCommand cmd = new SqlCommand("select * from myData WHERE taskType = 'University Task'", con);

            con.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //delete all record
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fatim\source\repos\MidLabExam\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            int ID;
            ID = int.Parse(textBox3.Text);

            string query = "delete from myData WHERE id = ID";
          
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {

                textBox4.Text = " DATA DELETED SUCCESSFULLY...!!";
            }
            else if (i == 0)
            {
                textBox4.Text = " DATA DELETED SUCCESSFULLY...!!";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //data show for home task
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\fatim\source\repos\MidLabExam\Database1.mdf; Integrated Security = True");

            SqlCommand cmd = new SqlCommand("select * from myData WHERE taskType = 'Home Task'", con);

            con.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // important work 

            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\fatim\source\repos\MidLabExam\Database1.mdf; Integrated Security = True");

            SqlCommand cmd = new SqlCommand("select * from myData WHERE taskLevel = 'Important'", con);

            con.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\fatim\source\repos\MidLabExam\Database1.mdf; Integrated Security = True");

            SqlCommand cmd = new SqlCommand("select * from myData WHERE taskLevel = 'Normal'", con);

            con.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }
    }
}
