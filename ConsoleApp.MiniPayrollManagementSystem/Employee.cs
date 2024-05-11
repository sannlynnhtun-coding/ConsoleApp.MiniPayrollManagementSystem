namespace ConsoleApp.MiniPayrollManagementSystem;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double HourlyRate { get; set; }
    public double HoursWorked { get; set; }

    public double CalculatePay()
    {
        return HourlyRate * HoursWorked;
    }
}
