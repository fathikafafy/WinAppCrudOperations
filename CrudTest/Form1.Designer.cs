namespace CrudTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.DetptPanel = new System.Windows.Forms.Panel();
            this.SearchByCobmo = new System.Windows.Forms.ComboBox();
            this.SearchValue = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ComboDeptList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UpdateEmpBtn = new System.Windows.Forms.Button();
            this.DeleteEmpbtn = new System.Windows.Forms.Button();
            this.AddEmpBtn = new System.Windows.Forms.Button();
            this.EmpSalary = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.EmpId = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmpName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteDeptBtn = new System.Windows.Forms.Button();
            this.AddDeptBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DeptName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.DetptPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmpSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpId)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 279);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1253, 269);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // DetptPanel
            // 
            this.DetptPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetptPanel.Controls.Add(this.SearchByCobmo);
            this.DetptPanel.Controls.Add(this.SearchValue);
            this.DetptPanel.Controls.Add(this.SearchBtn);
            this.DetptPanel.Controls.Add(this.label7);
            this.DetptPanel.Controls.Add(this.groupBox2);
            this.DetptPanel.Controls.Add(this.groupBox1);
            this.DetptPanel.Location = new System.Drawing.Point(12, 22);
            this.DetptPanel.Name = "DetptPanel";
            this.DetptPanel.Size = new System.Drawing.Size(1253, 239);
            this.DetptPanel.TabIndex = 1;
            // 
            // SearchByCobmo
            // 
            this.SearchByCobmo.DisplayMember = "Name";
            this.SearchByCobmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchByCobmo.FormattingEnabled = true;
            this.SearchByCobmo.Location = new System.Drawing.Point(112, 205);
            this.SearchByCobmo.Name = "SearchByCobmo";
            this.SearchByCobmo.Size = new System.Drawing.Size(177, 28);
            this.SearchByCobmo.TabIndex = 9;
            this.SearchByCobmo.ValueMember = "Id";
            // 
            // SearchValue
            // 
            this.SearchValue.Location = new System.Drawing.Point(295, 205);
            this.SearchValue.Name = "SearchValue";
            this.SearchValue.PlaceholderText = "                 Search Value";
            this.SearchValue.Size = new System.Drawing.Size(270, 27);
            this.SearchValue.TabIndex = 11;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(571, 205);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(235, 29);
            this.SearchBtn.TabIndex = 5;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Search By";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComboDeptList);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.UpdateEmpBtn);
            this.groupBox2.Controls.Add(this.DeleteEmpbtn);
            this.groupBox2.Controls.Add(this.AddEmpBtn);
            this.groupBox2.Controls.Add(this.EmpSalary);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.EmpId);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.EmpName);
            this.groupBox2.Location = new System.Drawing.Point(25, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 178);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee";
            // 
            // ComboDeptList
            // 
            this.ComboDeptList.DisplayMember = "Name";
            this.ComboDeptList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboDeptList.FormattingEnabled = true;
            this.ComboDeptList.Location = new System.Drawing.Point(481, 87);
            this.ComboDeptList.Name = "ComboDeptList";
            this.ComboDeptList.Size = new System.Drawing.Size(276, 28);
            this.ComboDeptList.TabIndex = 8;
            this.ComboDeptList.ValueMember = "Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Department";
            // 
            // UpdateEmpBtn
            // 
            this.UpdateEmpBtn.Location = new System.Drawing.Point(579, 134);
            this.UpdateEmpBtn.Name = "UpdateEmpBtn";
            this.UpdateEmpBtn.Size = new System.Drawing.Size(78, 29);
            this.UpdateEmpBtn.TabIndex = 5;
            this.UpdateEmpBtn.Text = "Update";
            this.UpdateEmpBtn.UseVisualStyleBackColor = true;
            this.UpdateEmpBtn.Click += new System.EventHandler(this.UpdateEmpBtn_Click);
            // 
            // DeleteEmpbtn
            // 
            this.DeleteEmpbtn.Location = new System.Drawing.Point(676, 134);
            this.DeleteEmpbtn.Name = "DeleteEmpbtn";
            this.DeleteEmpbtn.Size = new System.Drawing.Size(81, 29);
            this.DeleteEmpbtn.TabIndex = 5;
            this.DeleteEmpbtn.Text = "Delete";
            this.DeleteEmpbtn.UseVisualStyleBackColor = true;
            this.DeleteEmpbtn.Click += new System.EventHandler(this.DeleteEmpbtn_Click);
            // 
            // AddEmpBtn
            // 
            this.AddEmpBtn.Location = new System.Drawing.Point(479, 134);
            this.AddEmpBtn.Name = "AddEmpBtn";
            this.AddEmpBtn.Size = new System.Drawing.Size(78, 29);
            this.AddEmpBtn.TabIndex = 5;
            this.AddEmpBtn.Text = "Add";
            this.AddEmpBtn.UseVisualStyleBackColor = true;
            this.AddEmpBtn.Click += new System.EventHandler(this.AddEmpBtn_Click);
            // 
            // EmpSalary
            // 
            this.EmpSalary.Location = new System.Drawing.Point(481, 47);
            this.EmpSalary.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.EmpSalary.Name = "EmpSalary";
            this.EmpSalary.Size = new System.Drawing.Size(278, 27);
            this.EmpSalary.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Salary";
            // 
            // EmpId
            // 
            this.EmpId.Location = new System.Drawing.Point(83, 47);
            this.EmpId.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.EmpId.Name = "EmpId";
            this.EmpId.Size = new System.Drawing.Size(278, 27);
            this.EmpId.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // EmpName
            // 
            this.EmpName.Location = new System.Drawing.Point(83, 84);
            this.EmpName.Name = "EmpName";
            this.EmpName.Size = new System.Drawing.Size(278, 27);
            this.EmpName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteDeptBtn);
            this.groupBox1.Controls.Add(this.AddDeptBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DeptName);
            this.groupBox1.Location = new System.Drawing.Point(823, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Derpartments";
            // 
            // DeleteDeptBtn
            // 
            this.DeleteDeptBtn.Location = new System.Drawing.Point(280, 134);
            this.DeleteDeptBtn.Name = "DeleteDeptBtn";
            this.DeleteDeptBtn.Size = new System.Drawing.Size(81, 29);
            this.DeleteDeptBtn.TabIndex = 5;
            this.DeleteDeptBtn.Text = "Delete";
            this.DeleteDeptBtn.UseVisualStyleBackColor = true;
            this.DeleteDeptBtn.Click += new System.EventHandler(this.DeleteDeptBtn_Click);
            // 
            // AddDeptBtn
            // 
            this.AddDeptBtn.Location = new System.Drawing.Point(173, 134);
            this.AddDeptBtn.Name = "AddDeptBtn";
            this.AddDeptBtn.Size = new System.Drawing.Size(78, 29);
            this.AddDeptBtn.TabIndex = 5;
            this.AddDeptBtn.Text = "Add";
            this.AddDeptBtn.UseVisualStyleBackColor = true;
            this.AddDeptBtn.Click += new System.EventHandler(this.AddDeptBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // DeptName
            // 
            this.DeptName.Location = new System.Drawing.Point(83, 47);
            this.DeptName.Name = "DeptName";
            this.DeptName.Size = new System.Drawing.Size(278, 27);
            this.DeptName.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1277, 560);
            this.Controls.Add(this.DetptPanel);
            this.Controls.Add(this.dataGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximumSize = new System.Drawing.Size(1295, 607);
            this.MinimumSize = new System.Drawing.Size(1295, 607);
            this.Name = "Form1";
            this.Text = "CrudApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.DetptPanel.ResumeLayout(false);
            this.DetptPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmpSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpId)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView;
        private Panel DetptPanel;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox DeptName;
        private Button DeleteDeptBtn;
        private Button AddDeptBtn;
        private GroupBox groupBox2;
        private Label label5;
        private Button UpdateEmpBtn;
        private Button DeleteEmpbtn;
        private Button AddEmpBtn;
        private NumericUpDown EmpSalary;
        private Label label6;
        private NumericUpDown EmpId;
        private Label label1;
        private Label label2;
        private TextBox EmpName;
        private TextBox SearchValue;
        private Button SearchBtn;
        private Label label7;
        private ComboBox ComboDeptList;
        private ComboBox SearchByCobmo;
    }
}