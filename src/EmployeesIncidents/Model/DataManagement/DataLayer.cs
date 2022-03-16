using EmployeesIncidents.Model.Objects;

namespace EmployeesIncidents.Model.DataManagement
{
    public class DataLayer
    {
        public static Dictionary<int, Company> companies = new Dictionary<int, Company>();
        public static Dictionary<string, Employee> employees = new Dictionary<string, Employee>();
        public static Dictionary<string, Assignment> assignments = new Dictionary<string, Assignment>();

        public DataLayer()
        {
            companies.Add(1, new Company(1, "Mutiny"));
            companies.Add(2, new Company(2, "TestCompany"));
            employees.Add("29419376F", new Employee("29419376F", "Pedro", "Perez", new Company(1, "Mutiny")));
            employees.Add("95812530G", new Employee("95812530G", "Alejandro", "Fernandez", new Company(2, "TestCompany")));
            employees.Add("71482303M", new Employee("71482303M", "Lucia", "Suarez", new Company(1, "Mutiny")));
            employees.Add("45956499S", new Employee("45956499S", "Joao", "Fernandes", new Company(2, "TestCompany")));
            employees.Add("74331687B", new Employee("74331687B", "Ana", "Manzana", new Company(1, "Mutiny")));
            employees.Add("32969106D", new Employee("32969106D", "Rocio", "Cardenas", new Company(2, "TestCompany")));
        }

        public static void AddCompany(string companyName)
        {
            companies.Add(companies.Count + 1, new Company(companies.Count + 1, companyName));
        }

        public static void AddEmployee(Employee employee)
        {
            if (Employee.GetEmployee(employees, employee.Dni) != null)
            {
                throw new Exception("DNI ALREADY REGISTERED");
            }

            Company company = Company.GetCompany(companies, employee.Company.Code);

            if (company == null)
            {
                throw new Exception("COMPANY DOES NOT EXIST");
            }

            employee.Company = company;

            employees.Add(employee.Dni, employee);
        }
        public static void AddAssignment(Assignment assignment)
        {
            if (Assignment.GetAssignment(assignments, assignment.Code) != null)
            {
                throw new Exception("ASSIGNMENT CODE ALREADY REGISTERED");
            }

            if (!assignment.CheckType())
            {
                throw new Exception("INVALID ASSIGNMENT TYPE. VALID TYPES: Tarea, Incidencia");
            }

            Employee employee = Employee.GetEmployee(employees, assignment.Employee.Dni);

            if (employee == null)
            {
                throw new Exception("EMPLOYEE DOES NOT EXIST");
            }

            assignment.Employee = employee;

            assignments.Add(assignment.Code, assignment);
        }
    }
}
