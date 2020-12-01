using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;

namespace BestBuyPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            var depos = _connection.Query<Department>("SELECT * FROM departments");
            return depos;

        }

        public void InsertDepartment(string NewDeptName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);", new { departmentName = NewDeptName });
        }
    }
}
