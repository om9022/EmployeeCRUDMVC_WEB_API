using EmployeeDAL;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBAL
{
    public class StateService
    {
        StateRepository repo = new StateRepository();

        public List<ContryModel> GetContryList()
        {
            return repo.GetContryList();
        }

        public List<StateModel> GetStateList(int ContryId)
        {
            return repo.GetStateList(ContryId);
        }
        public List<CityModel> GetCityList(int StateId)
        {
            return repo.GetCityList(StateId);
        }
    }
}
