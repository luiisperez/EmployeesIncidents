using EmployeesIncidents.Model.DataManagement;
using EmployeesIncidents.Model.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesIncidents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        // GET: api/<AssignmentController>
        [HttpGet]
        public Dictionary<string, Assignment> Get()
        {
            return DataLayer.assignments;
        }

        // GET api/<AssignmentController>/5
        [HttpGet("{id}")]
        public Assignment Get(string id)
        {
            return Assignment.GetAssignment(DataLayer.assignments, id);
        }

        // GET api/<AssignmentController>/GetIncidentsByEmployee/5
        [HttpGet("GetIncidentsByEmployee/{id}")]
        public List<Assignment> GetIncidentsByEmployee(string id)
        {
            return Assignment.GetIncidentsByEmployee(id);
        }

        // POST api/<AssignmentController>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Assignment assignment)
        {
            try
            {
                DataLayer.AddAssignment(assignment);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.ReasonPhrase = ex.Message;
                return response;
            }
        }

        // GET api/<AssignmentController>/GetIncidentsByEmployee/5
        [HttpGet("GetEmployeeWithMostIncidents/{year}/{month}")]
        public Dictionary<string, int> GetEmployeeWithMostIncidents(int year, int month)
        {
            return Assignment.GetEmployeeWithMostIncidents(year, month);
        }



        // PUT api/<AssignmentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AssignmentController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
