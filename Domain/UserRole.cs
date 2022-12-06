using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRole
    {
        public int id { get; set; }
        public string Role { get; set; }
        public List<User> users { get; set; }
    }
}
