using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Model
{
    class AcceptForEmployment
    {
        public int AcceptForEmploymentId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime StatusDate { get; set; }
        public Employee Employee { get; set; }
        public Position Position { get; set; }
        public Branch Branch { get; set; }
        public Status Status { get; set; }
    }
}
