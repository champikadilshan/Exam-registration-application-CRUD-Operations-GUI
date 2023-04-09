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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExamRegistration
{
    public partial class register : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\dilshan\OneDrive - University of Sri Jayewardenepura Faculty of Technology\Documents\student.mdf"";Integrated Security=True;Connect Timeout=30");
        public register()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Methods.LogFile(" INFO  ", "Register Form Started! ");
            connection.Open();
            Methods.LogFile(" INFO  ", "DataBase Connection Created Successfully! ");
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [stable] (Name,Surname, Address,Password) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            Methods.LogFile("PROCESS", "These Data '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "' Successfully Inserted Into the Table!");
            //Methods.LogFile(" INFO  ", "DataBase Connection Closed Successfully! ");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            MessageBox.Show("Data Inserted Successfully");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login l1 = new login();
            l1.ShowDialog();
            Methods.LogFile(" INFO  ", "LogIn Form Opened! ");
        }
    }
}
