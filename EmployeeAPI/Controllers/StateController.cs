using EmployeeBAL;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class StateController : ApiController
    {
        StateService service = new StateService();
        [HttpGet]
        [Route("api/cmn/GetContryList")]
        public HttpResponseMessage GetContryList()
        {
            StateCityViewModel list = new StateCityViewModel();
            list.ContryModelList = service.GetContryList();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpGet]
        [Route("api/cmn/GetStateList")]
        public HttpResponseMessage GetStateList(int ContryId)
        {
            StateCityViewModel list = new StateCityViewModel();
            list.StateModelList = service.GetStateList(ContryId);

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpGet]
        [Route("api/cmn/GetCityList")]
        public HttpResponseMessage GetCityList(int StateId)
        {
            StateCityViewModel list = new StateCityViewModel();
            list.CityModelList = service.GetCityList(StateId);

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
    }
}
