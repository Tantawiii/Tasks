using System;
using System.Collections.Generic;

namespace Day5Task
{
    public class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        private List<Employee> Staff = new List<Employee>();

        public void AddStaff(Employee e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            Staff.Add(e);
            e.EmployeeLayOff += RemoveStaff;
        }

        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee employee)
            {
                Staff.Remove(employee);
                Console.WriteLine($"Employee {employee.EmployeeID} removed from department {DeptName} due to {e.Cause}.");
                PrintStaff();
            }
        }

        public void PrintStaff()
        {
            Console.WriteLine($"Current staff in department {DeptName}:");
            foreach (var employee in Staff)
            {
                Console.WriteLine($"- Employee ID: {employee.EmployeeID}, BirthDate: {employee.BirthDate.ToShortDateString()}, VacationStock: {employee.VacationStock}");
            }
        }
    }
}