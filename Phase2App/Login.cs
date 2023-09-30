using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phase2App
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text =="123456")
            {
                Home obj = new Home();
                obj.Show();
                this.Hide();
            }

        }
    }
}
