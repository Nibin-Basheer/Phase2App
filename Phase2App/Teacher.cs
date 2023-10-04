using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Phase2App
{
    public partial class Teacher : Form
    {
        SqlConnection con = new SqlConnection(@"server=LENOVO\SQLEXPRESS;initial catalog=ClaysysDB;Integrated security=true");

        public Teacher()
        {
            InitializeComponent();
            ShowTeachers();
            string query = "SELECT * FROM Tbl_Departments";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comboBoxDepartment.DisplayMember = "DepartmentName";
            comboBoxDepartment.ValueMember = "DepartmentId";
            comboBoxDepartment.DataSource = ds.Tables[0];
        }
        private void ShowTeachers()
        {
            string sel = "SELECT * FROM Tbl_Teachers";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sel, con);
            da.Fill(ds);
            dataGridViewTeacherList.DataSource = ds.Tables[0];


        }
        private void buttonAddTeacher_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            int department = Convert.ToInt32(comboBoxDepartment.SelectedValue.ToString());
            string dob = dateTimePickerDob.Value.ToString("yyyy-MM-dd");
            

            string address = richTextBoxAddress.Text;
            string phone = textBoxPhone.Text;
            string email = textBox3Email.Text;
            string joinDate = dateTimePickerJoinDate.Value.ToString("yyyy-MM-dd");
            string insert = "INSERT INTO Tbl_Teachers VALUES('" + name + "'," + department + ",'" + dob + "','" + address + "','" + phone + "','" + email + "','" + joinDate + "')";
            SqlCommand cmd = new SqlCommand(insert, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if(result>0)
            {
                label8.Text = "Inserted";
                label8.Visible = true;
            }
            ShowTeachers();




        }

        private void buttonUpdateTeacher_Click(object sender, EventArgs e)
        {

            string name = textBoxName.Text;
            int department = Convert.ToInt32(comboBoxDepartment.SelectedValue.ToString());
            string dob = dateTimePickerDob.Value.ToString("yyyy-MM-dd");


            string address = richTextBoxAddress.Text;
            string phone = textBoxPhone.Text;
            string email = textBox3Email.Text;
            string joinDate = dateTimePickerJoinDate.Value.ToString("yyyy-MM-dd");

            string Update = "Update Tbl_Teachers set TeacherName='" + name + "',DepartmentId=" + department + ",Dob='" + dob + "',Address='" + address + "',Phone='" + phone + "',Email='" + email + "',JoinDate='" + joinDate + "'  where TeacherId=" + key + "";
            SqlCommand cmd = new SqlCommand(Update, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ShowTeachers();
            MessageBox.Show("Updated...!");

        }
        int key = 0;
        private void dataGridViewTeacherList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = dataGridViewTeacherList.Rows[i];
            textBoxName.Text = row.Cells[1].Value.ToString();
            comboBoxDepartment.SelectedValue = row.Cells[2].Value.ToString();
            dateTimePickerDob.Text= row.Cells[3].Value.ToString();
            richTextBoxAddress.Text= row.Cells[4].Value.ToString();
            textBoxPhone.Text= row.Cells[5].Value.ToString();
            textBox3Email.Text= row.Cells[6].Value.ToString();

            key = Convert.ToInt32(row.Cells[0].Value.ToString());

        }

        private void buttonDeleteTeacher_Click(object sender, EventArgs e)
        {
            string del = "DELETE FROM Tbl_Teachers WHERE TeacherId=" + key + "";
            SqlCommand cmd = new SqlCommand(del, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ShowTeachers();
            MessageBox.Show("Deleted...!");
        }

        private void textBox3Email_Validating(object sender, CancelEventArgs e)
        {
            string email = textBox3Email.Text;
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            
            if(string.IsNullOrWhiteSpace(email))
            {
                e.Cancel = true;
                errorProviderEmail.SetError(textBox3Email, "This field is required");
            }
            else if (!Regex.IsMatch(email, pattern))
            {
                e.Cancel = true;
                errorProviderEmail.SetError(textBox3Email, "Invalid email format");
            }
            else
            {
                errorProviderEmail.SetError(textBox3Email, "");
            }

        }

        private void textBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            string phone = textBoxPhone.Text;
            string pattern = @"^\d{10}$";

            if (string.IsNullOrWhiteSpace(phone))
            {
                e.Cancel = true;
                errorProviderPhone.SetError(textBoxPhone, "This field is required");
            }
            else if (!Regex.IsMatch(phone, pattern))
            {
                e.Cancel = true;
                errorProviderPhone.SetError(textBoxPhone, "Invalid phone number format");
            }
            else
            {
                errorProviderPhone.SetError(textBoxPhone, "");
            }
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                errorProviderName.SetError(textBoxName, "Name should only contain letters.");
            }
            else
            {
                errorProviderName.SetError(textBoxName, ""); 
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void richTextBoxAddress_Validating(object sender, CancelEventArgs e)
        {
            string address = richTextBoxAddress.Text;

            if (string.IsNullOrWhiteSpace(address))
            {
                e.Cancel = true;
                errorProviderAddress.SetError(richTextBoxAddress, "This field is required");
            }
            else
            {
                errorProviderAddress.SetError(richTextBoxAddress, "");
            }
        }

        private void dateTimePickerDob_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePickerDob.Value;
            DateTime maxDate = DateTime.Now.AddYears(-100);
            if (selectedDate > DateTime.Now || selectedDate < maxDate)
            {
                MessageBox.Show("Please select a valid date.");
                
            }
           

        }
    }
}
