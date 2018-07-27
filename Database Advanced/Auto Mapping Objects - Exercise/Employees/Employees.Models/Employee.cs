namespace Employees.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Employee()
        {
            this.ManagerEmployees = new HashSet<Employee>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> ManagerEmployees { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - {FirstName} {LastName} - ${Salary:f2}{Environment.NewLine}" +
                $"Birthday: {Birthday.Value.ToString("dd-MM-yyyy")}{Environment.NewLine}" +
                $"Address: {Address}";
        }
    }
}