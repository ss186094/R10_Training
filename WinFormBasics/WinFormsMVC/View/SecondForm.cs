using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMVC.View
{
    public partial class SecondForm : Form
    {
        public SecondForm()
        {
            InitializeComponent();
        }

        public UserInfo UserInfo { get; set; }
        private void FirstName_TextChanged(object sender, EventArgs e)
        {
            UserInfo.FirstName = FirstName.Text;

        }

        private void LastName_TextChanged(object sender, EventArgs e)
        {
            UserInfo.LastName = LastName.Text;
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            UserInfo.Email = Email.Text;
        }

        private void SecondForm_Load(object sender, EventArgs e)
        {
            FirstName.Text = UserInfo.FirstName;
            LastName.Text = UserInfo.LastName;  
            Email.Text = UserInfo.Email;
        }
    }
}
