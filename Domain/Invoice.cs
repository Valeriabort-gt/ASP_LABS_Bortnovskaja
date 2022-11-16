using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public string number { get; set; }
        public int organizationID { get; set; }
        public int roomID { get; set; }
        public decimal puySum { get; set; }
        public DateTime payDate { get; set; }
        public int employeeID { get; set; }
    }
}
