namespace Employees.App.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class ManagerDto
    {
        public ManagerDto()
        {
            this.EmployeeDto = new HashSet<EmployeeDto>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> EmployeeDto { get; set; }

        public int ManagerEmployeesCount => EmployeeDto.Count;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{FirstName} {LastName} | Employees: {ManagerEmployeesCount}");
            foreach (var emp in EmployeeDto)
            {
                sb.AppendLine($"    - {emp.FirstName} {emp.LastName} - ${emp.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}