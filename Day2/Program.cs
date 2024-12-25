#pragma warning disable

using System;
using TantawiisLibrary;

namespace EmployeeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[4];
            employees[0] = new Employee();
            int count = 1;

            while (true)
            {
                Console.WriteLine("\n1- Add Employee\n2- Print Employees (Sorted by Hiring Date)\n3- Exit");
                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if (count >= employees.Length)
                        {
                            Console.WriteLine("Employee array is full!");
                            break;
                        }

                        Console.WriteLine($"\nEnter details for Employee {count + 1}:");

                        Console.Write("ID: ");
                        int id;
                        if (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("Invalid input! Please enter a number.");
                            continue;
                        }

                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Age (18-45): ");
                        int age = int.Parse(Console.ReadLine());
                        if (age < 18 || age > 45)
                        {
                            Console.WriteLine("OOOOF!");
                            continue;
                        }

                        Console.Write("Target (>300): ");
                        double target = double.Parse(Console.ReadLine());
                        if (target < 300)
                        {
                            Console.WriteLine("OOOOF!");
                            continue;
                        }

                        Console.Write("Security Level (Admin (A)/Human Resources (HR)/Officer (O)/TheTantawii (TT)): ");
                        string securityLevelInput = Console.ReadLine();
                        SecurityLevel securityLevel = SecurityLevel.Imposter;
                        if (securityLevelInput.Equals("Admin", StringComparison.OrdinalIgnoreCase) || securityLevelInput.Equals("A", StringComparison.OrdinalIgnoreCase))
                            securityLevel = SecurityLevel.Admin;
                        else if (securityLevelInput.Equals("Human Resources", StringComparison.OrdinalIgnoreCase) || securityLevelInput.Equals("HR", StringComparison.OrdinalIgnoreCase))
                            securityLevel = SecurityLevel.HR;
                        else if (securityLevelInput.Equals("Officer", StringComparison.OrdinalIgnoreCase) || securityLevelInput.Equals("O", StringComparison.OrdinalIgnoreCase))
                        {
                            securityLevel = SecurityLevel.Officer;
                        }
                        else if (securityLevelInput.Equals("TheTantawii", StringComparison.OrdinalIgnoreCase) || securityLevelInput.Equals("TT", StringComparison.OrdinalIgnoreCase))
                        {
                            securityLevel = SecurityLevel.TheTantawii;
                        }
                        else
                        {
                            Console.WriteLine("Imposter FOUND!!! OUT YOU GO!!");
                            continue;
                        }

                        Console.Write("Salary (6000-20000): ");
                        double salary = double.Parse(Console.ReadLine());

                        Console.Write("Hire Day: ");
                        int day = int.Parse(Console.ReadLine());

                        Console.Write("Hire Month: ");
                        int month = int.Parse(Console.ReadLine());

                        Console.Write("Hire Year: ");
                        int year = int.Parse(Console.ReadLine());

                        Console.Write("Gender (Male(M)/Female(F)/Tantawii(T): ");
                        string genderInput = Console.ReadLine();
                        Gender gender = Gender.Unknown;
                        if (genderInput.Equals("Male", StringComparison.OrdinalIgnoreCase) || genderInput.Equals("M", StringComparison.OrdinalIgnoreCase))
                            gender = Gender.Male;
                        else if (genderInput.Equals("Female", StringComparison.OrdinalIgnoreCase) || genderInput.Equals("F", StringComparison.OrdinalIgnoreCase))
                            gender = Gender.Female;
                        else if (genderInput.Equals("Tantawii", StringComparison.OrdinalIgnoreCase) || genderInput.Equals("T", StringComparison.OrdinalIgnoreCase))
                        {
                            gender = Gender.Tantawii;
                        }
                        else
                        {
                            Console.WriteLine("So you are genderless, alrighty then! Mister Gender Classifed Unknown, Try Again!");
                            continue;
                        }

                        employees[count] = new Employee(
                            id,
                            name,
                            age,
                            target,
                            securityLevel,
                            salary,
                            new HireDate(day, month, year),
                            gender
                        );
                        count++;
                        Console.WriteLine("Employee added successfully!");
                        break;

                    case 2:
                        if (count == 0)
                        {
                            Console.WriteLine("No employees to display.");
                        }
                        else
                        {
                            Array.Sort(employees, 0, count);
                            Console.WriteLine("\nSorted Employee Details by Hiring Date:");
                            for (int i = 0; i < count; i++)
                            {
                                employees[i].DisplayEmployee();
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Exiting.. ASTA LAVISTA BABY!!!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! I mean come on, only 1,2, & 3 are applicable. THEY ARE 3 CHOICES!!!");
                         break;
                }
            }
        }
    }
}
