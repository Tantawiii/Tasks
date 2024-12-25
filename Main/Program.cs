namespace Day3C
{
    using Point;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            Point3D P = new Point3D(10, 10, 10);
            Console.WriteLine(P.ToString());

            Console.WriteLine("Enter coordinates for P1 (X, Y, Z):");
            Point3D P1 = ReadPoint();

            Console.WriteLine("Enter coordinates for P2 (X, Y, Z):");
            Point3D P2 = ReadPoint();

            Console.WriteLine(P1 == P2 ? "P1 and P2 are equal" : "P1 and P2 are not equal");

            Point3D[] points = {
                new Point3D(3, 2, 5),
                new Point3D(1, 7, 3),
                new Point3D(2, 4, 8)
            };

            Array.Sort(points);
            Console.WriteLine("Sorted Points:");
            foreach (var point in points)
            {
                Console.WriteLine(point);
            }

            Point3D clone = (Point3D)P1.Clone();
            Console.WriteLine("Cloned Point:");
            Console.WriteLine(clone);

            int a = 20, b = 10;
            Console.WriteLine($"Add: {MathClass.Add(a, b)}");
            Console.WriteLine($"Subtract: {MathClass.Subtract(a, b)}");
            Console.WriteLine($"Multiply: {MathClass.Multiply(a, b)}");
            Console.WriteLine($"Divide: {MathClass.Divide(a, b)}");

            Duration D1 = new Duration(1, 10, 15);
            Console.WriteLine(D1.ToString());

            Duration D2 = new Duration(7800);
            Console.WriteLine(D2.ToString());

            Duration D3 = new Duration(666);
            Console.WriteLine(D3.ToString());

            D3 = D1 + D2;
            Console.WriteLine(D3.ToString());

            D3 = D1 + 7800;
            Console.WriteLine(D3.ToString());

            D3 = 666 + D3;
            Console.WriteLine(D3.ToString());

            D3++;
            Console.WriteLine(D3.ToString());

            D3 = --D2;
            Console.WriteLine(D3.ToString());

            Console.WriteLine(D1.ToString());
            Console.WriteLine(D2.ToString());
            D1 = -D2;
            Console.WriteLine(D1.ToString());
            Console.WriteLine(D2.ToString());

            Console.WriteLine(D1 > D2 ? "D1 is greater" : "D1 is not greater");

            if (D1) Console.WriteLine("D1 has a value");

            DateTime dateTime = (DateTime)D1;
            Console.WriteLine(dateTime.ToString("HH:mm:ss"));

            Console.WriteLine("Are You Done?");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "Yes")
            {
                string[] catFrames = new string[]
                {
                    @"
                         /\_/\  
                        ( o.o ) 
                         > ^ <  
                        ",
                    @"
                         /\_/\  
                        ( -.- ) 
                         > ^ <  
                        ",
                    @"
                         /\_/\  
                        ( o.o ) 
                         > - <  
                        ",
                    @"
                         /\_/\  
                        ( -.- ) 
                         > - <  
                        "
                };

                CATSpin spinner = new CATSpin(catFrames, 200);
                spinner.Spin();
            }

            static Point3D ReadPoint()
            {
                int x, y, z;

                Console.Write("X: ");
                while (!int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Invalid input. Please enter an integer for X.");
                }

                Console.Write("Y: ");
                while (true)
                {
                    try
                    {
                        y = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter an integer for Y.");
                        y = 0;
                    }
                }

                Console.Write("Z: ");
                while (true)
                {
                    try
                    {
                        z = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter an integer for Z.");
                        z = 0;
                    }
                }

                return new Point3D(x, y, z);
            }


        }
    }
}