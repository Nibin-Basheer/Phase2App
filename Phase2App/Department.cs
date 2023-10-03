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
    public partial class Department : Form
    {
        SqlConnection con = new SqlConnection(@"server=LENOVO\SQLEXPRESS;initial catalog=ClaysysDB;Integrated security=true");

        public Department()
        {
            InitializeComponent();
            ShowDepartmets();
        }
        private void ShowDepartmets()
        {
            string sel = "SELECT * FROM Tbl_Departments";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sel, con);
            da.Fill(ds);
            dataGridViewDepartmentList.DataSource = ds.Tables[0];


        }

        private void buttonAddDepartment_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string insert = "INSERT INTO Tbl_Departments VALUES('" + name + "')";
            SqlCommand cmd = new SqlCommand(insert, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {
                MessageBox.Show("Inserted...!");
            }
            ShowDepartmets();
        }
        int key = 0;
        private void dataGridViewDepartmentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = dataGridViewDepartmentList.Rows[i];
            textBoxName.Text = row.Cells[1].Value.ToString();
            key = Convert.ToInt32(row.Cells[0].Value.ToString());
        }

        private void buttonUpdateDepartment_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string Update = "Update Tbl_Departments set DepartmentName='" + name + "' where DepartmentId=" + key + "";
            SqlCommand cmd = new SqlCommand(Update, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ShowDepartmets();
            MessageBox.Show("Updated...!");
        }
    }
}
