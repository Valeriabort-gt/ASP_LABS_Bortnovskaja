using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Building
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int floorCount { get; set; }
        public string description { get; set; }
        public List<Room> rooms { get; set; }
        public List<BuildingPhoto> buildingPhotos { get; set; }
    }
}
