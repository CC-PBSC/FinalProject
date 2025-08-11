using System;
using System.Collections.Generic;

// Base class
class Contractor
{
    public string Name { get; set; }
    public string Number { get; set; }
    public string StartDate { get; set; }

    public Contractor(string name, string number, string startDate)
    {
        Name = name;
        Number = number;
        StartDate = startDate;
    }

    public override string ToString()
    {
        return $"Contractor: {Name}, Number: {Number}, Start Date: {StartDate}";
    }
}

class Subcontractor : Contractor
{
    public int Shift { get; set; } // 1/2= day/night
    public double HourlyPayRate { get; set; }

    public Subcontractor(string name, string number, string startDate, int shift, double hourlyPayRate)
        : base(name, number, startDate)
    {
        Shift = shift;
        HourlyPayRate = hourlyPayRate;
    }

    // calculates pay. %3 more is night shift
    public double ComputePay(int hoursWorked)
    {
        double pay = HourlyPayRate * hoursWorked;
        if (Shift == 2) 
        {
            pay *= 1.03; 
        }
        return pay;
    }

    public override string ToString()
    {
        return base.ToString() + $", Shift: {Shift}, Hourly Rate: ${HourlyPayRate:F2}";
    }
}

class Program
{
    static void Main()
    {
        //creates list and asks the user questions 1 by 1 in order
        // to get information needed
        List<Subcontractor> subs = new List<Subcontractor>();

        while (true)
        {
            Console.Write("Enter name (or 'q' to quit): ");
            string name = Console.ReadLine();
            if (name.ToLower() == "q") break;

            Console.Write("Enter contractor number: ");
            string number = Console.ReadLine();

            Console.Write("Enter start date (ie Monday, Tuesday, etc.): ");
            string startDate = Console.ReadLine();

            Console.Write("Enter shift (1 = day, 2 = night): ");
            int shift = int.Parse(Console.ReadLine());

            Console.Write("Enter hourly pay rate: ");
            double rate = double.Parse(Console.ReadLine());

            Subcontractor sub = new Subcontractor(name, number, startDate, shift, rate);
            subs.Add(sub);

            Console.Write("Enter hours worked: ");
            int hours = int.Parse(Console.ReadLine());

            Console.WriteLine($"Pay for {sub.Name}: ${sub.ComputePay(hours):F2}\n");
        }

        Console.WriteLine("\nAll Subcontractors:");
        foreach (var s in subs)
        {
            Console.WriteLine(s);
        }
    }
}
