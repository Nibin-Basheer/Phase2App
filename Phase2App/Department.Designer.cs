
namespace Phase2App
{
    partial class Department
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonDeleteDepartment = new System.Windows.Forms.Button();
            this.buttonUpdateDepartment = new System.Windows.Forms.Button();
            this.buttonAddDepartment = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewDepartmentList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartmentList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(27, 144);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(124, 20);
            this.textBoxName.TabIndex = 24;
            // 
            // buttonDeleteDepartment
            // 
            this.buttonDeleteDepartment.Location = new System.Drawing.Point(55, 223);
            this.buttonDeleteDepartment.Name = "buttonDeleteDepartment";
            this.buttonDeleteDepartment.Size = new System.Drawing.Size(52, 35);
            this.buttonDeleteDepartment.TabIndex = 39;
            this.buttonDeleteDepartment.Text = "Delete";
            this.buttonDeleteDepartment.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateDepartment
            // 
            this.buttonUpdateDepartment.Location = new System.Drawing.Point(85, 182);
            this.buttonUpdateDepartment.Name = "buttonUpdateDepartment";
            this.buttonUpdateDepartment.Size = new System.Drawing.Size(52, 35);
            this.buttonUpdateDepartment.TabIndex = 38;
            this.buttonUpdateDepartment.Text = "Update";
            this.buttonUpdateDepartment.UseVisualStyleBackColor = true;
            this.buttonUpdateDepartment.Click += new System.EventHandler(this.buttonUpdateDepartment_Click);
            // 
            // buttonAddDepartment
            // 
            this.buttonAddDepartment.Location = new System.Drawing.Point(28, 182);
            this.buttonAddDepartment.Name = "buttonAddDepartment";
            this.buttonAddDepartment.Size = new System.Drawing.Size(51, 35);
            this.buttonAddDepartment.TabIndex = 37;
            this.buttonAddDepartment.Text = "Add";
            this.buttonAddDepartment.UseVisualStyleBackColor = true;
            this.buttonAddDepartment.Click += new System.EventHandler(this.buttonAddDepartment_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 33);
            this.panel1.TabIndex = 41;
            // 
            // dataGridViewDepartmentList
            // 
            this.dataGridViewDepartmentList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDepartmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepartmentList.Location = new System.Drawing.Point(312, 144);
            this.dataGridViewDepartmentList.Name = "dataGridViewDepartmentList";
            this.dataGridViewDepartmentList.Size = new System.Drawing.Size(475, 315);
            this.dataGridViewDepartmentList.TabIndex = 42;
            this.dataGridViewDepartmentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDepartmentList_CellContentClick);
            // 
            // Department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(815, 505);
            this.Controls.Add(this.dataGridViewDepartmentList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonDeleteDepartment);
            this.Controls.Add(this.buttonUpdateDepartment);
            this.Controls.Add(this.buttonAddDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Department";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Department";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartmentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonDeleteDepartment;
        private System.Windows.Forms.Button buttonUpdateDepartment;
        private System.Windows.Forms.Button buttonAddDepartment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewDepartmentList;
    }
}