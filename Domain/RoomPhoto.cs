using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RoomPhoto
    {
        public int id { get; set; }
        public int photoID { get; set; }
        public Photo photo { get; set; }
        public int roomID { get; set; }
        public Room room { get; set; }
    }
}
