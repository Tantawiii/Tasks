using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using System;

namespace TantawiisLibrary
{
    public class Employee : IComparable<Employee>
    {
        public int ID { get; set; }
        public string Name { get; set; }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18 || value > 45)
                    throw new ArgumentException("Age must be in the range [18, 45]");
                age = value;
            }
        }

        private double target;
        public double Target
        {
            get { return target; }
            set
            {
                if (value <= 300)
                    throw new ArgumentException("Target must be greater than 300");
                target = value;
            }
        }

        public SecurityLevel SecurityLevel { get; set; }

        private double salary;
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value < 6000 || value > 20000)
                    throw new ArgumentException("Salary must be in the range [6000, 20000]");
                salary = value;
            }
        }

        public HireDate HiringDate { get; set; }
        public Gender EmpGender { get; set; }

        public Employee() {
            ID = 0;
            Name = "Omar";
            Age = 24;
            Target = 50000;
            SecurityLevel = SecurityLevel.TheTantawii;
            Salary = 15000;
            HiringDate = new HireDate(13, 07, 2000);
            EmpGender = Gender.Tantawii;
        }

        public Employee(int id, string name, int age, double target, SecurityLevel securityLevel, double salary, HireDate hiringDate, Gender gender) : base()
        {
            ID = id;
            Name = name;
            Age = age;
            Target = target;
            SecurityLevel = securityLevel;
            Salary = salary;
            HiringDate = hiringDate;
            EmpGender = gender;
        }

        public void DisplayEmployee()
        {
            Console.WriteLine(this.ToString());
        }

        public int CompareTo(Employee other)
        {
            if (other == null) return 1;
            int yearComparison = this.HiringDate.Year.CompareTo(other.HiringDate.Year);
            if (yearComparison != 0) return yearComparison;

            int monthComparison = this.HiringDate.Month.CompareTo(other.HiringDate.Month);
            if (monthComparison != 0) return monthComparison;

            return this.HiringDate.Day.CompareTo(other.HiringDate.Day);
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Age: {Age}, Target: {Target}, Security Level: {SecurityLevel}, " +
                   $"Salary: {Salary:C}, Hire Date: {HiringDate.DisplayDate()}, Gender: {EmpGender}";
        }
    }
}

