namespace EmployeesIncidents.Model.Objects
{
    public class Company
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public Company()
        {
        }

        public Company(int code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public static Company GetCompany(Dictionary<int, Company> companies, int code)
        {
            Company company;
            bool exist = companies.TryGetValue(code, out company);
            return exist ? company : null;
        }
    }
}
