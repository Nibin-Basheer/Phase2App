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
    public partial class Student : Form
    {

        SqlConnection con = new SqlConnection(@"server=LENOVO\SQLEXPRESS;initial catalog=ClaysysDB;Integrated security=true");
        public Student()
        {
            InitializeComponent();
            ShowStudents();
            
                string query = "SELECT * FROM Tbl_Departments";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
               
                comboBoxDepartment.DisplayMember = "DepartmentName";
                comboBoxDepartment.ValueMember = "DepartmentId";
                comboBoxDepartment.DataSource = ds.Tables[0];


           
        }
        private void ShowStudents()
        {
            string sel = "SELECT * FROM Tbl_Students";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sel, con);
            da.Fill(ds);
            dataGridViewStudentList.DataSource = ds.Tables[0];


        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_DBInsert";
            cmd.CommandType = CommandType.StoredProcedure;

            //input
            cmd.Parameters.AddWithValue("@StudentName", textBoxName.Text);
            cmd.Parameters.AddWithValue("@DepartmentId",comboBoxDepartment.SelectedValue);
            cmd.Parameters.AddWithValue("@Dob", dateTimePickerDob.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Address", richTextBoxAddress.Text);
            cmd.Parameters.AddWithValue("@Phone", textBoxPhone.Text);
            cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
            cmd.Parameters.AddWithValue("@AdmissionDate", dateTimePickerAdmDate.Value.ToString("yyyy-MM-dd"));

            //output
            SqlParameter sp = new SqlParameter();
            sp.DbType = DbType.Int32;
            sp.ParameterName = "@status";
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            int outValue = Convert.ToInt32(sp.Value);
            if (outValue == 1)
            {

                label9.Text = "Inserted";
                label9.Visible = true;
            }
            ShowStudents();



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }
    }
}
