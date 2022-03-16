using EmployeesIncidents.Model.DataManagement;
using EmployeesIncidents.Model.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesIncidents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public Dictionary<string, Employee> Get()
        {
            return DataLayer.employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(string id)
        {
            return Employee.GetEmployee(DataLayer.employees, id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                DataLayer.AddEmployee(employee);
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

        // PUT api/<EmployeeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EmployeeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
