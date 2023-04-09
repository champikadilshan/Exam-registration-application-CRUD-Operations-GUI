using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamRegistration
{
    public partial class display : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\dilshan\OneDrive - University of Sri Jayewardenepura Faculty of Technology\Documents\student.mdf"";Integrated Security=True;Connect Timeout=30");
        public display()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Methods.LogFile(" INFO  ", "Display Form Started! ");
            connection.Open();
            Methods.LogFile(" INFO  ", "DataBase Connection Created Successfully! ");
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [dbo].[stable] (Name,Surname, Address,Password) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cmd.ExecuteNonQuery();
            Methods.LogFile("PROCESS", "These Data '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "' Successfully Inserted Into Table!");
            connection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            display_data();
            MessageBox.Show("Data Inserted Successfully");
            //Methods.LogFile(" INFO  ", "DataBase Connection Closed Successfully! ");
        }
        public void display_data()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [dbo].[stable]";
            cmd.ExecuteNonQuery();
            Methods.LogFile("PROCESS", "All Data Displayed! ");
            DataTable data = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(data);
            dataGridView1.DataSource = data;
            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [dbo].[stable] where Name = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            Methods.LogFile("PROCESS", "Best Row of Student '" + textBox1.Text + "' Deleted! ");
            connection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            display_data();
            MessageBox.Show("Data deleted Successfully");
            Methods.LogFile(" INFO  ", "Data deleted Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [dbo].[stable] set Name = '" + textBox2.Text + "' where Name = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            Methods.LogFile("PROCESS", "Updated [dbo].[stable] Set Name = '" + textBox2.Text + "' Where Name = '" + textBox1.Text + "'");
            connection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            display_data();
            MessageBox.Show("Data updated Successfully");
            Methods.LogFile(" INFO  ", "Data updated Successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [dbo].[stable] where Name = '" + textBox5.Text + "'";
            cmd.ExecuteNonQuery();
            Methods.LogFile("PROCESS", "Selected All Data of Student Named '" + textBox5.Text + "'");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            connection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
