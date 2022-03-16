using EmployeesIncidents.Model.DataManagement;

namespace EmployeesIncidents.Model.Objects
{
    public class Assignment
    {
        public string Code { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public Employee? Employee { get; set; }

        public Assignment()
        {
        }

        public Assignment(string code, string header, string description, DateTime date, string type, Employee employee)
        {
            this.Code = code;
            this.Header = header;
            this.Description = description;
            this.Date = date;
            this.Type = type;
            this.Employee = employee;
        }

        public Assignment(string code, string header, string description, DateTime date, string type)
        {
            this.Code = code;
            this.Header = header;
            this.Description = description;
            this.Date = date;
            this.Type = type;
        }

        public static Assignment GetAssignment(Dictionary<string, Assignment> assignments, string code)
        {
            Assignment assignment;
            bool exist = assignments.TryGetValue(code, out assignment);
            return exist ? assignment : null;
        }

        public bool CheckType ()
        {
            List<string> types = new List<string> { "Tarea", "Incidencia"};
            if (types.Contains(this.Type))
            {
                return true;
            }
            return false;
        }

        public static List<Assignment> GetIncidentsByEmployee(string dni)
        {
            List<Assignment> assignments = new List<Assignment>();

            foreach (KeyValuePair<string, Assignment> assignment in DataLayer.assignments)
            {
                if (assignment.Value.Type == "Incidencia")
                {
                    if (assignment.Value.Employee.Dni == dni)
                    {
                        assignments.Add(assignment.Value);
                    }
                }
            }

            return assignments;
        }

        public static Dictionary<string, int> GetEmployeeWithMostIncidents(int year, int month)
        {
            Dictionary<string, int> employeesCount = new Dictionary<string, int>();

            foreach (KeyValuePair<string, Assignment> assignment in DataLayer.assignments)
            {
                if (assignment.Value.Type == "Incidencia")
                {
                    if ((assignment.Value.Date.Month == month) && (assignment.Value.Date.Year == year))
                    {
                        if (!employeesCount.ContainsKey(assignment.Value.Employee.Dni))
                        {
                            employeesCount.Add(assignment.Value.Employee.Dni, 1);
                        }
                        else
                        {
                            int total = employeesCount[assignment.Value.Employee.Dni] + 1;
                            string dni = assignment.Value.Employee.Dni;
                            employeesCount[dni] = total;
                        }
                    }
                }
            }
            int maxHits = 0;
            string employeeHits = "";
            foreach (KeyValuePair<string, int> employee in employeesCount)
            {
                if (employee.Value > maxHits)
                {
                    employeeHits = employee.Key;
                    maxHits = employee.Value;
                }
            }
            if (employeeHits != "")
            {
                Dictionary<string, int> pair = new Dictionary<string, int>();
                pair.Add(employeeHits, maxHits);
                return pair;
            }
            return null;
        }
    }
}
