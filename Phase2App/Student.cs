﻿using System;
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
            
                string query = "SELECT DepartmentName FROM Tbl_Departments";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
               
                comboBoxDepartment.DisplayMember = "DepartmentName";
                comboBoxDepartment.ValueMember = "DepartmentId";
                comboBoxDepartment.DataSource = ds.Tables[0];


           
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "sp_DBInsert";
            cmd.CommandType = CommandType.StoredProcedure;
            //input
            cmd.Parameters.AddWithValue("@StudentName", textBoxName.Text);
            cmd.Parameters.AddWithValue("@DepartmentId", comboBoxDepartment.SelectedValue);
            cmd.Parameters.AddWithValue("@Dob", dateTimePickerDob.Value);
            cmd.Parameters.AddWithValue("@Address", richTextBoxAddress.Text);
            cmd.Parameters.AddWithValue("@Phone", textBoxPhone.Text);
            cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
            cmd.Parameters.AddWithValue("@AdmissionDate", dateTimePickerAdmDate.Value);

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


        }




    }
}