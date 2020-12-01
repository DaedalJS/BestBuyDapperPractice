using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyPractices
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        void InsertDepartment(string NewDeptName);
    }
}
