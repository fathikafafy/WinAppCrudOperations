using CrudTest.DataAccess;
using CrudTest.Models;
using System.Data;
using System.ComponentModel;
using static CrudTest.Models.AppConst;

namespace CrudTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView.DataSource = SQLDAL.ReturnDataTableByProcedure(Search.ProcName);
            ComboDeptList.DataSource = SQLDAL.ReturnDataTableByProcedure(Dept.ProcName);
            ComboDeptList.DisplayMember= nameof(LookUps.Name);
            ComboDeptList.ValueMember= nameof(LookUps.Id);

            SearchByCobmo.DataSource = new List<LookUps>()
            {
                new (){ Id=null,Name = Search.Default },
                new (){ Id=1,Name = Search.SearchByEmpId },
                new (){ Id=2,Name = Search.SearchByDeptId },
                new (){ Id=3,Name = Search.SearchBySalary },
                new (){ Id=4,Name = Search.SearchByEmpName },
                new (){ Id=5,Name = Search.SearchByDeptName },
            };
            SearchByCobmo.DisplayMember = nameof(LookUps.Name);
            SearchByCobmo.ValueMember = nameof(LookUps.Id);
        }

        private bool ValidateWithMessage(params (string value, string textMessage)[] dataParam)
        {
            foreach (var item in dataParam)
            {
                if (string.IsNullOrWhiteSpace(item.value =="0" ? null: item.value))
                {
                    MessageBox.Show($"Please enter {item.textMessage}", "Worring", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
        private void ClearEmp()
        {
            EmpId.Text=string.Empty;
            EmpId.Value = 0;
            EmpName.Text=string.Empty;
            EmpSalary.Text=string.Empty;
        }
        private void ClearDept()
        {
            DeptName.Text = string.Empty;
        }
        private void RefreshDataGridView(DataRow? newDataRow, RefreshAction action)
        {

            var dt = dataGridView.DataSource as DataTable;

            if (action is RefreshAction.Update or RefreshAction.Delete)
            {
                var dataRow = dt?.Select($"Id = {EmpId.Value}").FirstOrDefault();

                dt?.Rows.Remove(dataRow!);
            }

            if (action is RefreshAction.Add or RefreshAction.Update && newDataRow is not null)
                dt?.Rows.Add(new object[] { newDataRow[0], newDataRow[1], newDataRow[2], newDataRow[3], newDataRow[4], newDataRow[5] });

            dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Descending);

            ClearEmp();
        }

        private void AddDeptBtn_Click(object sender, EventArgs e)
        {
            var isvalid = ValidateWithMessage((DeptName.Text, Dept.NameMessage));
            if (!isvalid) return;

            var param = SQLDAL.CreateSqlParams((Dept.Name, DeptName.Text), (Dept.IsDeleted, false));

            ComboDeptList.DataSource = SQLDAL.ReturnDataTableByProcedure(Dept.ProcName, param);

            ClearDept();
        }
        private void DeleteDeptBtn_Click(object sender, EventArgs e)
        {
            var isvalid = ValidateWithMessage((DeptName.Text, Dept.NameMessage));
            if (!isvalid) return;

            var param = SQLDAL.CreateSqlParams((Dept.Name, DeptName.Text), (Dept.IsDeleted, true));

            ComboDeptList.DataSource = SQLDAL.ReturnDataTableByProcedure(Dept.ProcName, param);

            ClearDept();
        }

        private void AddEmpBtn_Click(object sender, EventArgs e)
        {
            var isvalid = ValidateWithMessage((EmpName.Text, Emp.NameMessage), (EmpName.Text, Emp.NameMessage));
            if (!isvalid) return;

            var param = SQLDAL.CreateSqlParams((Emp.isDeleted, false),
                            (Emp.DeptId,(int?)ComboDeptList.SelectedValue),
                            (Emp.Name, EmpName.Text),
                            (Emp.Salary, Convert.ToDecimal(EmpSalary.Text == string.Empty ? null : EmpSalary.Text)));

            var newDataRow = SQLDAL.ReturnDataTableByProcedure(Emp.ProcName, param).Select().Last();
          
            RefreshDataGridView(newDataRow, RefreshAction.Add);

            ClearEmp();
        }
        private void UpdateEmpBtn_Click(object sender, EventArgs e)
        {
            var isvalid = ValidateWithMessage((EmpId.Value.ToString(), Emp.EmpIdMessage), (EmpName.Text, Emp.NameMessage));
            if (!isvalid) return;

            var param = SQLDAL.CreateSqlParams(
                 (Emp.isDeleted, false), 
                 (Emp.Id, (int?)EmpId.Value),
                 (Emp.DeptId, (int)ComboDeptList.SelectedValue),
                 (Emp.Name, EmpName.Text),
                 (Emp.Salary, Convert.ToDecimal(EmpSalary.Text == string.Empty ? null : EmpSalary.Text)));

            var newDataRow = SQLDAL.ReturnDataTableByProcedure(Emp.ProcName, param).Select().Last();

             RefreshDataGridView(newDataRow, RefreshAction.Update);
        }
        private void DeleteEmpbtn_Click(object sender, EventArgs e)
        {
            var isvalid = ValidateWithMessage((EmpId.Value.ToString(), Emp.EmpIdMessage));
            if (!isvalid) return;

            var param = SQLDAL.CreateSqlParams(
                 (Emp.isDeleted, true),
                 (Emp.Id, (int?)EmpId.Value));

            SQLDAL.ReturnDataTableByProcedure(Emp.ProcName, param);

            RefreshDataGridView(null,RefreshAction.Delete);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var param = SQLDAL.CreateSqlParams(
                  (Search.SearchBy, SearchByCobmo.SelectedValue),
                  (Search.Value, SearchValue.Text));

            dataGridView.DataSource = SQLDAL.ReturnDataTableByProcedure(Search.ProcName, param);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            EmpId.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            EmpName.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            DeptName.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            EmpSalary.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString()?.Replace(" $", "");
            ComboDeptList.Text = ComboDeptList.DisplayMember = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}