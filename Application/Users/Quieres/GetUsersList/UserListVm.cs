using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Quieres.GetUsersList
{
    public class UserListVm
    {
        public IList<UserLookupDto> users { get; set; }
        public string next { get; set; }
        public string back { get; set; }
        public int pagesCount { get; set; }
    }
}
