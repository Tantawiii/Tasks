using System;

namespace Day5Task
{
    public class Program
    {
        static void Main()
        {
            // Create employees
            Employee emp1 = new Employee { EmployeeID = 1, BirthDate = new DateTime(1960, 1, 1), VacationStock = -5 };
            Employee emp2 = new Employee { EmployeeID = 2, BirthDate = new DateTime(1985, 5, 15), VacationStock = 10 };

            // Create department
            Department dept = new Department { DeptID = 101, DeptName = "HR" };
            dept.AddStaff(emp1);
            dept.AddStaff(emp2);

            // Create club
            Club club = new Club { ClubID = 201, ClubName = "Recreational Club" };
            club.AddMember(emp1);
            club.AddMember(emp2);

            // Year-end operation
            emp1.EndOfYearOperation();
            emp2.EndOfYearOperation();

            // Create salesperson
            SalesPerson sp = new SalesPerson { EmployeeID = 3, AchievedTarget = 50 };
            sp.CheckTarget(60);

            // Create board member
            BoardMember bm = new BoardMember { EmployeeID = 4 };
            bm.Resign();

            Console.WriteLine("Program execution completed.");
            Console.ReadLine();
        }
    }
}
