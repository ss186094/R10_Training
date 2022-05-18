using System;

public class Program
{
    public static void Main()
    {
        List<Employee> list= new List<Employee>();
        Employee employee1=new Employee()
        {
            Id=1,
            Name ="Paul",
            Salary =5000,
            Experience =3

        };
        Employee employee2 = new Employee()
        {
            Id = 2,
            Name = "Bob",
            Salary = 6000,
            Experience = 4

        };
        Employee employee3 = new Employee()
        {
            Id = 1,
            Name = "Jack",
            Salary = 3000,
            Experience = 2

        };
        Employee employee4 = new Employee()
        {
            Id = 4,
            Name = "Ross",
            Salary = 8000,
            Experience = 5

        };
        list.Add(employee1);
        list.Add(employee2);
        list.Add(employee3);
        list.Add(employee4);
        
        //Updating Employee
        foreach (Employee employee in list)
        {
            if(employee.Name == "Jack")
            {
                employee.Salary = 4000;
            }
        }
        foreach (Employee employee in list)
        {
            Console.WriteLine(employee.Name+"    "+employee.Salary);
        }


        //Getting Employee Details

        foreach (Employee employee in list)
        {
            if (employee.Id == 2)
            {
                Console.WriteLine("Employee Name : {0}", employee.Name);
                Console.WriteLine("Employee Salary : {0}", employee.Salary);
                Console.WriteLine("Employee Experience : {0}", employee.Experience);
            }
        }

        //Sorting Employee by Salary
        Console.WriteLine("Before Sorting");
        foreach (Employee employee in list)
        {
            Console.WriteLine(employee.Salary);
        }
        list.Sort();
        Console.WriteLine("After Sorting");
        foreach (Employee employee in list)
        {
            Console.WriteLine(employee.Salary);
        }

        //Sorting Employee by Name using Delegate

        Console.WriteLine("Before Sorting");
        foreach (Employee employee in list)
        {
            Console.WriteLine(employee.Name);
        }
        list.Sort(delegate (Employee emp1, Employee emp2) { return emp1.Name.CompareTo(emp2.Name); });
        Console.WriteLine("After Sorting");
        foreach (Employee employee in list)
        {
            Console.WriteLine(employee.Name);
        }


        // Removing an employee
        foreach(Employee employee in list)
        {
            if(employee.Id == 2)
            {
                list.Remove(employee);
                break;
            }
            
        }
        foreach( Employee employee in list)
        {
            Console.WriteLine(employee.Name);
        }

        //Exception Handling

        try
        {
           
        }
        catch(Exception ex)
        {
            Console.WriteLine("Employee Not Found");
        }




    }
}

public class Employee: IComparable<Employee>
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