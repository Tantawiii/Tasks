using System;
using System.Collections.Generic;

namespace Day5Task
{
    public class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        private List<Employee> Members = new List<Employee>();

        public void AddMember(Employee e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            Members.Add(e);
            e.EmployeeLayOff += RemoveMember;
        }

        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee employee)
            {
                if (e.Cause == LayOffCause.VacationStockNegative)
                {
                    Members.Remove(employee);
                    Console.WriteLine($"Employee {employee.EmployeeID} removed from club {ClubName} due to vacation stock being negative.");
                }
                else if (e.Cause == LayOffCause.AgeAboveLimit)
                {
                    Console.WriteLine($"Employee {employee.EmployeeID} remains in the club {ClubName} despite age above limit.");
                }
            }
        }
    }
}
