using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Photo
    {
        public int id { get; set; }
        public string url { get; set; }
        public List<BuildingPhoto> buildingPhotos { get; set; }
        public List<RoomPhoto> roomPhotos { get; set; }
    }
}
