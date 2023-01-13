using EmployeeDAL;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBAL
{
    public class LocationService
    {
        LocationRepository repo = new LocationRepository();

        public LocationModelViewModel GetLocationList()
        {
            return repo.GetLocationList();
        }

        public LocModel ViewLocations(int Id)
        {
            return repo.ViewLocations(Id);
        }

        public ResponseStatusModel AddLocationName(LocModel model)
        {
            return repo.AddLocation(model);
        }
        public ResponseStatusModel UpdateLocation(LocModel md)
        {
            return repo.UpdateLocation(md);
        }

        public ResponseStatusModel RemoveLoation(int Id)
        {
            return repo.RemoveLocation(Id);
        }

        public LocationModelViewModel GetLocationNameDropdownList()
        {
            return repo.GetLocationNameDropdownList();
        }
    }
}
