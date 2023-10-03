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
    }
}
