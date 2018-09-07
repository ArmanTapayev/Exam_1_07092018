using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL.Model;

namespace Inventory.Modul
{
    public class AdditionModel
    {
        List<User> Users;
        public List<User> Search(string fname, string lname)
        {
            return Users.Where(x => x.FName == fname && x.LName == lname).ToList();
        }
    }
}
