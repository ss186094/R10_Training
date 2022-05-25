using System;
public class Employee : IComparable<Employee>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public int Experience { get; set; }



    public int CompareTo(Employee other)
    {
        if (this.Salary > other.Salary)
        {
            return 1;
        }
        else if (this.Salary < other.Salary)
        {
            return -1;
        }
        else
        {
            return 0;
        }
        //return this.Salary.CompareTo(other.Salary);
    }
}