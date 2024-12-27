using System;

namespace Day5Task
{
    public class BoardMember : Employee
    {
        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.Resignation });
            Console.WriteLine($"BoardMember {EmployeeID} has resigned.");
        }
    }
}
