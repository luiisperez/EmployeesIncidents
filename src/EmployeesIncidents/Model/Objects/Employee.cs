namespace EmployeesIncidents.Model.Objects
{
    public class Employee
    {
        public string Dni { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Company? Company { get; set; }

        public Employee()
        {
        }

        public Employee(string dni, string firstname, string lastname)
        {
            this.Dni = dni;
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        public Employee(string dni, string firstname, string lastname, Company company)
        {
            this.Dni = dni;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Company = company;
        }

        public static Employee GetEmployee(Dictionary<string, Employee> employees, string dni)
        {
            Employee employee;
            bool exist = employees.TryGetValue(dni, out employee);
            return exist ? employee : null;
        }
    }
}
