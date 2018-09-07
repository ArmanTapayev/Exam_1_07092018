using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Model
{
    public class Employee:IUser
    {
        public int EmployeeId { get; set; }
        public string IIN { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string DoB { get; set; }
        public Position Position { get; set; }
        public Branch Branch { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; } // статус сотрудника: hired - работает, fired - уволен

        public Employee() { }

        public Employee(string dob)
        {
            DoB = dob;
        }

        //public Employee(string iin)
        //{
        //    IIN = iin;
        //}
        public Employee(string fname, string lname) : this(fname, lname, "") { }
        public Employee(string fname, string lname, string mname)
        {
            FName = fname;
            LName = lname;
            MName = mname;
        }
    }
}
