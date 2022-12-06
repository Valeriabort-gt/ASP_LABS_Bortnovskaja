using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BuildingPhoto
    {
        public int id { get; set; }
        public int photoID { get; set; }
        public Photo photo { get; set; }
        public int buildingID { get; set; }
        public Building building { get; set; }
    }
}
