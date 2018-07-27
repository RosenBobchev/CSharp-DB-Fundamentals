namespace Employees.App.Core.Contracts
{
    using Employees.App.Models;
    using System;
    using System.Collections.Generic;

    public interface IEmployeeControler
    {
        void AddEmployee(EmployeeDto employeeDto);

        void SetBirthday(int employeeId, DateTime birthday);

        void SetAddress(int employeeId, string address);

        EmployeeDto GetEmployeeInfo(int employeeId);

        EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId);

        List<EmployeeWithManagerDto> GetEmployeesOlderThan(int age);
    }
}