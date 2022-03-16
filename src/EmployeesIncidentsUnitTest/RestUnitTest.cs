using EmployeesIncidents.Controllers;
using EmployeesIncidents.Model.DataManagement;
using EmployeesIncidents.Model.Objects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace EmployeesIncidentsUnitTest
{
    public class Tests
    {
        DataLayer dataLayer;
        [SetUp]
        public void Setup()
        {
            if (dataLayer == null)
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

        [Test]
        public void TestIncidenceByEmployee()
        {
            var controller = new AssignmentController();
            controller.Post(new EmployeesIncidents.Model.Objects.Assignment("RTR-8151", "TEST", "TEST", DateTime.Now,
                "Incidencia", new EmployeesIncidents.Model.Objects.Employee("29419376F", "TEST", "TEST")));
            controller.Post(new EmployeesIncidents.Model.Objects.Assignment("RTR-8152", "TEST", "TEST", DateTime.Now,
                "Incidencia", new EmployeesIncidents.Model.Objects.Employee("29419376F", "TEST", "TEST")));
            controller.Post(new EmployeesIncidents.Model.Objects.Assignment("RTR-8153", "TEST", "TEST", DateTime.Now,
                "Incidencia", new EmployeesIncidents.Model.Objects.Employee("29419376F", "TEST", "TEST")));


            List<Assignment> list = controller.GetIncidentsByEmployee("29419376F");

            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("RTR-8151", list[0].Code);
            Assert.AreEqual("RTR-8152", list[1].Code);
            Assert.AreEqual("RTR-8153", list[2].Code);
        }
    }
}