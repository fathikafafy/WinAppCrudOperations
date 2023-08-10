namespace CrudTest.Models
{
    public static class AppConst
    {

        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CurdTest;Integrated Security=True;Connect Timeout=9999";

        public static class Dept
        {
            public const string ProcName = "[dbo].[crudDept]";
            public const string IsDeleted = "@isDeleted";
            public const string Name = "@Name";
            
            public const string NameMessage = "Dept Name";
        }
        public static class Emp
        {
            public const string ProcName = "[dbo].[crudEmp]";
            public const string Id = "@Id";
            public const string Name = "@Name";
            public const string DeptId = "@DeptId";
            public const string Salary = "@Salary";
            public const string isDeleted = "@isDeleted";

            public const string NameMessage = "Emp Name";
            public const string EmpIdMessage = "Emp Id";
        }
    
        public static class Search
        {
            public const string ProcName = "[dbo].[SearchBy_Prc]";
            public const string SearchBy = "@SearchBy";
            public const string Value = "@Value";

            public const string Default = "Search By";
            public const string SearchByEmpId = "Emp Id";
            public const string SearchByEmpName = "Emp Name";
            public const string SearchByDeptId = "Dept Id";
            public const string SearchByDeptName = "Dept Name";
            public const string SearchBySalary = "Salary";

        }
    }
}
