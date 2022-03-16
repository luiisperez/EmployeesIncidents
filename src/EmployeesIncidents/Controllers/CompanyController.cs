using EmployeesIncidents.Model.DataManagement;
using EmployeesIncidents.Model.Objects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesIncidents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        // GET: api/<CompanyController>
        [HttpGet]
        public Dictionary<int, Company> Get()
        {
            return DataLayer.companies;
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            return Company.GetCompany(DataLayer.companies, id);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            DataLayer.AddCompany(value);
        }

        //// PUT api/<CompanyController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CompanyController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
