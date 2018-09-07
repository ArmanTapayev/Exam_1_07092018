using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Model
{
    public enum Role { Admin, User };
    public class User:IUser
    {
        public int UserId { get; private set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string DoB { get; set; }
        public Position Position { get; set; }
        public Branch Branch { get; set; }
        public Status Status { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        private static int counter = 16;
        public User()
        {
            UserId = ++counter;
        }

        public User(string login, string password, Role role,
            Position position, Branch branch, int salary, string address, Status status)
        {
            Login = login;
            Password = password;
            Role = role;
            Position = position;
            Branch = branch;
            Salary = salary;
            Address = address;
            Status = status;

        }
        public User(string fname, string lname) : this(fname, lname, "") { }
        public User(string fname, string lname, string mname)
        {
            FName = fname;
            LName = lname;
            MName = mname;
        }
    }
}
