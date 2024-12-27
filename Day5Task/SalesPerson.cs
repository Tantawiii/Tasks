using System;

namespace Day5Task
{
    public class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }

        public bool CheckTarget(int quota)
        {
            if (AchievedTarget < quota)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.FailedSalesTarget });
                Console.WriteLine($"SalesPerson {EmployeeID} failed to meet the sales target of {quota}.");
                return false;
            }

            Console.WriteLine($"SalesPerson {EmployeeID} successfully met the sales target of {quota}.");
            return true;
        }
    }
}
