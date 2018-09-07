using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Model
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees;

        static int count = 3;
        int id = 0;

        public Branch() : this("")
        {
            id = count++;
            BranchId = id;
        }
        public Branch(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }
    }
}
