using System;
using System.Collections.Generic;

interface IPayable
{
    double CalculateSalary();
}


abstract class Employee : IPayable
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }

    public Employee(int id, string name)
    {
        EmployeeId = id;
        Name = name;
    }

    public abstract double CalculateSalary();

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"ID: {EmployeeId}");
        Console.WriteLine($"Name: {Name}");
    }
}


class FullTimeEmployee : Employee
{
    public double MonthlySalary { get; set; }
    public double Bonus { get; set; }

    public FullTimeEmployee(int id, string name, double salary, double bonus)
        : base(id, name)
    {
        MonthlySalary = salary;
        Bonus = bonus;
    }

    public override double CalculateSalary()
    {
        return MonthlySalary + Bonus;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Employee Type: Full Time");
        Console.WriteLine($"Net Salary: {CalculateSalary():C}");
        Console.WriteLine();
    }
}


class PartTimeEmployee : Employee
{
    public int HoursWorked { get; set; }
    public double HourlyRate { get; set; }

    public PartTimeEmployee(int id, string name, int hours, double rate)
        : base(id, name)
    {
        HoursWorked = hours;
        HourlyRate = rate;
    }

    public override double CalculateSalary()
    {
        return HoursWorked * HourlyRate;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Employee Type: Part Time");
        Console.WriteLine($"Net Salary: {CalculateSalary():C}");
        Console.WriteLine();
    }
}


class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>()
        {
            new FullTimeEmployee(101, "Alice", 5000, 800),
            new PartTimeEmployee(102, "Bob", 80, 25),
            new FullTimeEmployee(103, "Charlie", 6500, 1200),
            new PartTimeEmployee(104, "David", 60, 30)
        };

        Console.WriteLine("===== Employee Payroll System =====\n");

        foreach (Employee emp in employees)
        {
            emp.DisplayDetails();  
        }

        Console.ReadKey();
    }
}
