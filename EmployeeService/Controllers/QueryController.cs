using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeService.Controllers
{
    public class QueryController : ApiController
    {
        public HttpResponseMessage Get(string gender = "All")
        {
            using (EmployeeDbEntities entities = new EmployeeDbEntities())
            {
                switch (gender.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "value for gender must be all, male or female" + gender + " is valid");
                }
            }
        }
    }
}
