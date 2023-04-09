using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamRegistration
{

    
    public partial class Form1 : Form
    {   

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            register r1 = new register();
            r1.ShowDialog();
            Methods.LogFile(" INFO  ", "Register Form Started! ");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login l1 = new login();
            l1.ShowDialog();
            Methods.LogFile(" INFO  ", "LogIn Form Started! ");
        }
    }
}
