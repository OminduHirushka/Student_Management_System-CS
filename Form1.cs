using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Management_System
{
    public partial class Form1 : Form
    {
        private string mode = "NOT SET";
        private DBconnection dbconnection;

        public Form1()
        {
            InitializeComponent();

            enableButton();
            disableText();
            clear();

            dbconnection = new DBconnection();

            loadAllRecords();
        }

        public bool validate()
        {
            bool flag = false;

            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show(this, "Student ID Is Required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Focus();
            }
            else if (txtName.Text.Trim() == "")
            {
                MessageBox.Show(this, "Student Name Is Required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else if (txtAge.Text.Trim() == "")
            {
                MessageBox.Show(this, "Student Age Is Required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAge.Focus();
            }
            else if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show(this, "Student Address Is Required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
            }
            else if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show(this, "Student Email Is Required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
            else if (txtContact.Text.Trim() == "")
            {
                MessageBox.Show(this, "Student Contact Number Is Required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContact.Focus();
            }
            else if (txtCourse.Text.Trim() == "")
            {
                MessageBox.Show(this, "Student Course Name Is Required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCourse.Focus();
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public void disableButton()
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnExit.Enabled = true;
            btnCancel.Enabled = true;
            btnClear.Enabled = true;
        }

        public void enableButton()
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnExit.Enabled = true;
            btnCancel.Enabled = true;
            btnClear.Enabled = true;
        }

        public void disableText()
        {
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtAge.Enabled = false;
            txtAddress.Enabled = false;
            txtEmail.Enabled = false;
            txtContact.Enabled = false;
            txtCourse.Enabled = false;
        }

        public void enableText()
        {
            txtID.Enabled = true;
            txtName.Enabled = true;
            txtAge.Enabled = true;
            txtAddress.Enabled = true;
            txtEmail.Enabled = true;
            txtContact.Enabled = true;
            txtCourse.Enabled = true;
        }

        public void clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtCourse.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "ADD";

            enableText();
            txtID.Text = "000";
            txtName.Focus();
            disableButton();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            mode = "UPDATE";
            focusOnStuentID();
            disableButton();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mode = "DELETE";
            focusOnStuentID();
            disableButton();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(this, "Do You Want To Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            disableText();
            enableButton();
        }

        public void focusOnStuentID()
        {
            txtID.Enabled = true;
            txtID.Focus();
        }

        private void txtCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (validate())
                {
                    btnSave.Enabled = true;
                    btnSave.Focus();
                }
                else
                {

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode == "ADD")
            {
                string sql = "INSERT INTO student (name, age, address, email, contact, course) VALUES (";
                sql += "'" + txtName.Text.Trim() + "',";
                sql += "'" + txtAge.Text.Trim() + "',";
                sql += "'" + txtAddress.Text.Trim() + "',";
                sql += "'" + txtEmail.Text.Trim() + "',";
                sql += "'" + txtContact.Text.Trim() + "',";
                sql += "'" + txtCourse.Text.Trim() + "')";

                dbconnection.openConnection();

                int x = dbconnection.executeUpdate(sql);

                if (x > 0)
                {
                    MessageBox.Show(this, "Student Added Successfully", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Failed to Add Student", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dbconnection.closeConnection();
            }
            else
            {
                string sql = "UPDATE student SET ";
                sql += "name='" + txtName.Text.Trim() + "', ";
                sql += "age='" + txtAge.Text.Trim() + "', ";
                sql += "address='" + txtAddress.Text.Trim() + "', ";
                sql += "email='" + txtEmail.Text.Trim() + "', ";
                sql += "contact='" + txtContact.Text.Trim() + "', ";
                sql += "course='" + txtCourse.Text.Trim() + "' ";
                sql += "WHERE id='" + txtID.Text.Trim() + "'";


                dbconnection.openConnection();

                int x = dbconnection.executeUpdate(sql);

                if (x > 0)
                {
                    MessageBox.Show(this, "Student Updated Successfully", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(this, "Failed to Update Student", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dbconnection.closeConnection();
            }

            clear();
            disableText();
            enableButton();
            loadAllRecords();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (mode == "ADD")
                {
                    txtID.Text = "000";
                    txtName.Focus();
                }
                else
                {
                    string sql = "SELECT * FROM student WHERE id=" + txtID.Text.Trim();

                    dbconnection.openConnection();

                    MySqlDataReader reader = dbconnection.executeQuery(sql);

                    if (reader.Read())
                    {
                        txtName.Text = reader["name"].ToString();
                        txtAge.Text = reader["age"].ToString();
                        txtAddress.Text = reader["address"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtContact.Text = reader["contact"].ToString();
                        txtCourse.Text = reader["course"].ToString();

                        enableText();

                        if (mode == "DELETE")
                        {
                            DialogResult res = MessageBox.Show(this, "Do You Eant To Delete This Student Data?", "Delete Confiramtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (res == DialogResult.Yes)
                            {
                                dbconnection.closeConnection();
                                dbconnection.openConnection();

                                string query = "DELETE FROM student WHERE id=" + txtID.Text.Trim();

                                int record = dbconnection.executeUpdate(query);
                                if (record > 0)
                                {
                                    MessageBox.Show(this, "Successfully Deleted", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            clear();
                            disableText();
                            enableButton();
                            loadAllRecords();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Sorry no matching record were found", "status", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        clear();
                        disableText();
                        enableButton();
                    }

                    dbconnection.closeConnection();
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearch.Text.Trim();


            string sql = "SELECT * FROM student WHERE name LIKE '%" + name + "%'";
            Console.WriteLine(sql);

            dbconnection.openConnection();

            MySqlDataReader reader = dbconnection.executeQuery(sql);

            DataTable dt = new DataTable();
            dt.Load(reader);
            table.DataSource = dt;

            dbconnection.closeConnection();
        }

        public void loadAllRecords()
        {
            string sql = "SELECT * FROM student ORDER BY id DESC";

            dbconnection.openConnection();

            MySqlDataReader reader = dbconnection.executeQuery(sql);

            DataTable dt = new DataTable();
            dt.Load(reader);
            table.DataSource = dt;

            dbconnection.closeConnection();
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mode = "UPDATE";

            enableText();
            disableButton();

            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            string id = table.Rows[rowIndex].Cells[0].Value.ToString();
            string name = table.Rows[rowIndex].Cells[1].Value.ToString();
            string age = table.Rows[rowIndex].Cells[2].Value.ToString();
            string address = table.Rows[rowIndex].Cells[3].Value.ToString();
            string email = table.Rows[rowIndex].Cells[4].Value.ToString();
            string contact = table.Rows[rowIndex].Cells[5].Value.ToString();
            string course = table.Rows[rowIndex].Cells[6].Value.ToString();

            txtID.Text = id;
            txtName.Text = name;
            txtAge.Text = age;
            txtAddress.Text = address;
            txtEmail.Text = email;
            txtContact.Text = contact;
            txtCourse.Text = course;
        }
    }
}
