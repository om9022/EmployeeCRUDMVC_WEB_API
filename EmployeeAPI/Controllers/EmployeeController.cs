using EmployeeBAL;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeService service = new EmployeeService();

        [HttpGet]
        [Route("api/cmn/GetEmployeeList")]
        public HttpResponseMessage GetEmployeeList()
        {
            EmployeeViewModelView view = new EmployeeViewModelView();
            view.EmplModelList = service.GetEmployeeList();
            for (int i = 0; i < view.EmplModelList.Count; i++)
            {
                string[] fileArray = view.EmplModelList[i].FileName.Split(',');
                var images = new List<string>();
                for (int j = 0; j < fileArray.Count(); j++)
                {
                    string appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
                    string MainPath = appPath.Replace("repos\\EmployeeAPI\\EmployeeAPI\\", "repos\\Employee\\Employee\\");

                    string path = (MainPath +"/Models/" + fileArray[j]);
                    byte[] imageByte = System.IO.File.ReadAllBytes(path);
                    string imgBase64 = Convert.ToBase64String(imageByte);
                    imgBase64 = "data:Models/png;base64," + imgBase64;
                    images.Add(imgBase64);
                }
                view.EmplModelList[i].UploadedFiles = images;
                //result.EmplModelList[i].UploadedFiles = new List<string>();
                //images = result.EmplModelList[i].FilePath.Split(',').ToList();
                //string imgDataURL = ("data:Models/png,jpg,jpeg;base64,{0}"+imgBase64);
            }
            // return PartialView("EmployeePartial", view);
        return Request.CreateResponse(HttpStatusCode.OK, view);
        }
        [HttpGet]
        [Route("api/cmn/ViewEmployee")]
        public HttpResponseMessage ViewEmployee(int Id)
        {
            EmployeeViewModelView view = new EmployeeViewModelView();
            view.EmpModels = service.ViewemployeeName(Id);
            return Request.CreateResponse(HttpStatusCode.OK, view);
        }
        [HttpPost]
        [Route("api/cmn/AddEmployee")]
        public HttpResponseMessage AddEmployee(EmpModel user)
        {
            ResponseStatusModel res = new ResponseStatusModel();
            res = service.AddEmployee(user);
            return Request.CreateResponse(HttpStatusCode.OK, res);

            //var files = user.multiFiles;
            //foreach (var file in files)
            //{
            //    //var ext = Path.GetExtension(user.FilePath);
            //    if (file.ContentLength > 0)
            //    {
            //        string path = HttpContext.Current.Server.MapPath("~/Models/");
            //        if (!Directory.Exists(path))
            //        {
            //            Directory.CreateDirectory(path);
            //        }
            //        HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];
            //        byte[] bytes;  
            //        string fileName = Path.GetFileName(postedFile.FileName);
            //        bytes = System.IO.File.ReadAllBytes(path + fileName);
            //        string imgBase64 = Convert.ToBase64String(bytes);
            //        string imgDataURL = ("data:Models/png,jpg,jpeg;base64,{0}" + imgBase64);
            //        using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            //        {
            //            bytes = br.ReadBytes(postedFile.ContentLength);
            //        }
            //        postedFile.SaveAs(path + fileName);
            //        return Request.CreateResponse(HttpStatusCode.OK, res, fileName);
            //    }
            //}
        }

        [HttpPost]
        [Route("api/cmn/UpdateEmployee")]
        public HttpResponseMessage UpdateEmployee(EmpModel user)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            response = service.UpdateEmployee(user);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("api/cmn/RemoveEmployee")]
        public HttpResponseMessage RemoveEmployee(int Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            response = service.RemoveEmployee(Id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
