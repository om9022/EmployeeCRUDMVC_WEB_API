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

    public class LocationController : ApiController
    {
        readonly LocationService service = new LocationService();

        [HttpGet]
        [Route("api/cmn/GetLocationList")] 
        public HttpResponseMessage GetLocationList()
        {
            LocationModelViewModel view = new LocationModelViewModel();
            view = service.GetLocationList();

            return Request.CreateResponse(HttpStatusCode.OK, view);
        }

        [HttpGet]
        [Route("api/cmn/ViewLocationName")]
        public HttpResponseMessage ViewLocationName( int Id )
        {
            LocationModelViewModel view = new LocationModelViewModel();
            view.LocationModels = service.ViewLocations(Id);

            return Request.CreateResponse(HttpStatusCode.OK, view);
        }
        [HttpPost]
        [Route("api/cmn/AddLocationName")]
        public HttpResponseMessage AddLocationName(LocModel user)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            response = service.AddLocationName(user);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/cmn/UpdateLocationName")]
        public HttpResponseMessage UpdateLocationName(LocModel user)
        {
            ResponseStatusModel response = new ResponseStatusModel();

            response = service.UpdateLocation(user);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("api/cmn/RemoveLocationName")]
        public HttpResponseMessage RemoveLocationName(int Id)
        {
            ResponseStatusModel res = new ResponseStatusModel();
           res = service.RemoveLoation(Id);

            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
        [HttpGet]
        [Route("api/cmn/GetLocationDropDown")]
        public HttpResponseMessage GetLocationDropDown()
        {
            LocationModelViewModel view = new LocationModelViewModel();
            view = service.GetLocationNameDropdownList();
            return Request.CreateResponse(HttpStatusCode.OK, view);
        }
    }
}
