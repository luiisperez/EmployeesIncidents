using EmployeesIncidents.Controllers;
using EmployeesIncidents.Model.DataManagement;
using NUnit.Framework;
using System;
using System.Net.Http;

namespace EmployeesIncidentsUnitTest
{
    public class Tests
    {
        DataLayer dataLayer;
        [SetUp]
        public void Setup()
        {
            dataLayer = new DataLayer();
        }

        [Test]
        public void TestAddIncidence()
        {
            var controller = new AssignmentController();
            controller.Post(new EmployeesIncidents.Model.Objects.Assignment("RTR-8151", "TEST", "TEST", DateTime.Now,
                "Incidencia", new EmployeesIncidents.Model.Objects.Employee("29419376F", "TEST", "TEST")));
            Assert.IsTrue(DataLayer.assignments.ContainsKey("RTR-8151"));


            HttpResponseMessage messageTypeError = controller.Post(new EmployeesIncidents.Model.Objects.Assignment("RTR-8152", "TEST", "TEST", DateTime.Now,
                "Prueba", new EmployeesIncidents.Model.Objects.Employee("29419376F", "TEST", "TEST")));

            Assert.AreEqual("INVALID ASSIGNMENT TYPE. VALID TYPES: Tarea, Incidencia", messageTypeError.ReasonPhrase);

            HttpResponseMessage messageIdError = controller.Post(new EmployeesIncidents.Model.Objects.Assignment("RTR-8151", "TEST", "TEST", DateTime.Now,
                "Incidencia", new EmployeesIncidents.Model.Objects.Employee("29419376F", "TEST", "TEST")));

            Assert.AreEqual("ASSIGNMENT CODE ALREADY REGISTERED", messageIdError.ReasonPhrase);

            HttpResponseMessage messageEmployeeError = controller.Post(new EmployeesIncidents.Model.Objects.Assignment("RTR-8152", "TEST", "TEST", DateTime.Now,
                "Incidencia", new EmployeesIncidents.Model.Objects.Employee("TEST", "TEST", "TEST")));

            Assert.AreEqual("EMPLOYEE DOES NOT EXIST", messageEmployeeError.ReasonPhrase);
        }
    }
}