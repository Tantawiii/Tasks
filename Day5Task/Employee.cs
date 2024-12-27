namespace Day5Task
{
    public class EmployeeLayOffEventArgs : EventArgs
    {
        public LayOffCause Cause { get; set; }
    }

    public enum LayOffCause
    {
        VacationStockNegative,
        AgeAboveLimit,
        FailedSalesTarget,
        Resignation
    }

    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }
        public DateTime BirthDate { get; set; }
        public int VacationStock { get; set; }

        public bool RequestVacation(DateTime from, DateTime to)
        {
            int requestedDays = (to - from).Days;
            if (VacationStock - requestedDays < 0)
            {
                return false;
            }
            VacationStock -= requestedDays;
            return true;
        }

        public void EndOfYearOperation()
        {
            if (VacationStock < 0)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.VacationStockNegative });
            }

            if (DateTime.Now.Year - BirthDate.Year > 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.AgeAboveLimit });
            }
        }
    }
}
