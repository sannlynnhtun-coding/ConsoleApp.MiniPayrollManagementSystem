using BetterConsoleTables;
using ConsoleApp.MiniPayrollManagementSystem;
using System;
using System.Collections.Generic;

List<Employee> employees =
[
    new Employee { Id = 1, Name = "John Doe", HourlyRate = 25.50, HoursWorked = 40 },
    new Employee { Id = 2, Name = "Jane Smith", HourlyRate = 30.75, HoursWorked = 38 },
    new Employee { Id = 3, Name = "Michael Lee", HourlyRate = 18.00, HoursWorked = 45 },
    //new Employee { Id = 4, Name = "Olivia Jones", HourlyRate = 22.25, HoursWorked = 36 },
    //new Employee { Id = 5, Name = "William Miller", HourlyRate = 35.00, HoursWorked = 40 },
    //new Employee { Id = 6, Name = "Jennifer Brown", HourlyRate = 20.00, HoursWorked = 32 },
    //new Employee { Id = 7, Name = "David Davis", HourlyRate = 28.10, HoursWorked = 42 },
    //new Employee { Id = 8, Name = "Elizabeth Garcia", HourlyRate = 19.50, HoursWorked = 35 },
    //new Employee { Id = 9, Name = "Robert Hernandez", HourlyRate = 32.00, HoursWorked = 40 },
    //new Employee { Id = 10, Name = "Margaret Moore", HourlyRate = 27.75, HoursWorked = 37 },
];

MainMenu();

void MainMenu()
{
    Console.WriteLine("Payroll Management System");
    Console.WriteLine("1. Add Employee");
    Console.WriteLine("2. View Employees");
    Console.WriteLine("3. Calculate Payroll");
    Console.WriteLine("4. Exit");

    int choice = GetIntInput("Enter your choice: ");

    switch (choice)
    {
        case 1:
            AddEmployee();
            break;
        case 2:
            ViewEmployees();
            break;
        case 3:
            CalculatePayroll();
            break;
        case 4:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice.");
            MainMenu();
            break;
    }
}

void AddEmployee()
{
    Console.WriteLine("Enter Employee Details");
    Console.Write("ID: ");
    int id = GetIntInput();

    Console.Write("Name: ");
    string name = Console.ReadLine()!;

    Console.Write("Hourly Rate: ");
    double hourlyRate = GetDoubleInput();

    employees.Add(new Employee { Id = id, Name = name, HourlyRate = hourlyRate });

    Console.WriteLine("Employee added successfully.");
    MainMenu();
}

void ViewEmployees()
{
    if (employees.Count == 0)
    {
        Console.WriteLine("No employees found.");
    }
    else
    {
        Console.WriteLine("Employee List:");
        foreach (Employee employee in employees)
        {
            Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Hourly Rate: ${employee.HourlyRate}");
        }
    }
    MainMenu();
}

void CalculatePayroll()
{
    if (employees.Count == 0)
    {
        Console.WriteLine("No employees found.");
    }
    else
    {
        foreach (Employee employee in employees)
        {
            Console.Write($"Enter hours worked for {employee.Name}: ");
            employee.HoursWorked = GetDoubleInput();
        }

        //Console.WriteLine("\nPayroll Report:");
        //Console.WriteLine("ID\tName\t\tHourly Rate\tHours Worked\tTotal Pay");
        //Console.WriteLine("--------------------------------------------------");
        //foreach (Employee employee in employees)
        //{
        //    double totalPay = employee.CalculatePay();
        //    Console.WriteLine($"{employee.Id}\t{employee.Name}\t\t${employee.HourlyRate:F2}\t\t{employee.HoursWorked:F2}\t\t${totalPay:F2}");
        //}

        ColumnHeader[] headers = new[]
        {
                new ColumnHeader("ID"),
                new ColumnHeader("Name"),
                new ColumnHeader("Hourly Rate", Alignment.Right),
                new ColumnHeader("Hours Worked", Alignment.Right),
                new ColumnHeader("Total Pay", Alignment.Right),
            };
        Table table = new Table(headers);
        table.Config = TableConfiguration.UnicodeAlt();
        double totalAmount = 0;
        foreach (Employee employee in employees)
        {
            double totalPay = employee.CalculatePay();
            totalAmount += totalPay;
            table.AddRow(employee.Id, employee.Name, employee.HourlyRate, employee.HoursWorked, totalPay);
        }
        table.AddRow("", "", "", "Total : ", "$ " + totalAmount);
        Console.Write(table.ToString());
    }
    MainMenu();
}

int GetIntInput(string prompt = "")
{
    int value;
    while (!int.TryParse(Console.ReadLine(), out value))
    {
        Console.Write($"{prompt}Please enter a valid integer: ");
    }
    return value;
}

double GetDoubleInput(string prompt = "")
{
    double value;
    while (!double.TryParse(Console.ReadLine(), out value))
    {
        Console.Write($"{prompt}Please enter a valid number: ");
    }
    return value;
}
