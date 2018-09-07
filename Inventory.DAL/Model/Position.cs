using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Model
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; }

        List<Employee> Employees;

        static int count = 6;
        int id = 0;
        public Position() : this("")
        {
            id = count++;
            PositionId = id;
        }
        public Position(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }
    }
}
