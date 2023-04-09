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
    public partial class login : Form

    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\dilshan\OneDrive - University of Sri Jayewardenepura Faculty of Technology\Documents\student.mdf"";Integrated Security=True;Connect Timeout=30");
        
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register r1 = new register();
            r1.ShowDialog();
            Methods.LogFile(" INFO  ", "Register Form Opened! ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = textBox1.Text;
            user_password = textBox2.Text;

            try
            {
                String querry = "SELECT TOP (1000) [Name]\r\n      ,[Surname]\r\n      ,[Address]\r\n      ,[Password]\r\n  FROM [dbo].[stable]\r\n  WHERE [Name] = '" + textBox1.Text + "' AND [Password] = '" + textBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    user_password = textBox2.Text;


                    //team t1 = new team();
                    //t1.ShowDialog();

                    //this.Hide();
                    //MessageBox.Show("Login Successfull");
                    display d1 = new display();
                    d1.ShowDialog();
                    Methods.LogFile("PROCESS", "Displayed the Row that Searched! ");
                }
                else
                {
                    MessageBox.Show("Invalid Login Details! ", "Error");
                    Methods.LogFile(" INFO  ", "Invalid Login Details! ");
                    textBox1.Clear();
                    textBox2.Clear();

                    // to focus username
                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
                Methods.LogFile(" INFO  ", "Error! ");

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
