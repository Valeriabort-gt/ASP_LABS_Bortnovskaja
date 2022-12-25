using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BuildingsPhotos.Quieres.GetBuildingPhotoList
{
    public class BuildingPhotoListVm
    {
        public IList<BuildingPhotoLookupDto> buildingPhotos { get; set; }
    }
}
