using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Model
{
    public interface IUser
    {
        string FName { get; set; }
        string LName { get; set; }
        string MName { get; set; }
        string DoB { get; set; }
        string Address { get; set; }
    }
}
