using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Rent
    {
        public int id { get; set; }
        public int roomID { get; set; }
        public Room room { get; set; }
        public int organizationID { get; set; }
        public Organization organization { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime exitDate { get; set; }
    }
}
