using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtCourse.Text = "";
        }

        public void focusOnStuentID()
        {
            txtID.Enabled = true;
            txtID.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            focusOnStuentID();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            focusOnStuentID();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            focusOnStuentID();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            focusOnStuentID();
        }
    }
}
