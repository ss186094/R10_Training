using System;

public class Program
{

    public static void Main()
    {
        List<Employee> list = new List<Employee>();
        start:
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1.Add an employee");
        Console.WriteLine("2.Update an Employee");
        Console.WriteLine("3.Search an Employee");
        Console.WriteLine("4.Sort employees by name");
        Console.WriteLine("5.Sort employees by salary");
        Console.WriteLine("6.Delete an employee");
        Console.WriteLine("7.Display all the employees");
        int option=int.Parse(Console.ReadLine());
       
        string s = "-------------------------------------------------------------------";
        switch (option)
        {
            case 1: add(list);
                Console.WriteLine(s);
                goto start;
           
                
            case 2: Console.WriteLine("Enter the Id to be updated:");
                    int id=int.Parse(Console.ReadLine());
                    update(list,id);
                    Console.WriteLine(s);
                    goto start;

            case 3: Console.WriteLine("Enter the employee Name:");
                    String name=Console.ReadLine();
                    Search(list, name);
                    Console.WriteLine(s);
                    goto start;

            case 4: sortname(list);
                    Console.WriteLine(s);
                    goto start;

            case 5: sortsalary(list);
                    Console.WriteLine(s);
                    goto start;

            case 6: Console.WriteLine("Enter Id:");
                    int id1 = int.Parse(Console.ReadLine());
                    delete(list,id1);
                    Console.WriteLine(s);
                    goto start;

            case 7:display(list);
                    Console.WriteLine(s);
                    goto start;
            default:Console.WriteLine("Enter a valid option");
                    Console.WriteLine(s);
                    goto start;


        }
        



    }





    // add an employee
    public static void add(List<Employee> list)
    {
        Console.WriteLine("Enter Id :");
        int id=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Name:");
        String name=Console.ReadLine();
        Console.WriteLine("Enter Salary:");
        int sal=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Experience");
        int exp=int.Parse(Console.ReadLine());
        Employee employee=new Employee();
        employee.Id=id;
        employee.Name=name;
        employee.Salary=sal;
        employee.Experience=exp;
        list.Add(employee);
    }



    //Update an employee
    public static void update(List<Employee> list,int id)
    {   select:
        Console.WriteLine("Choose an option");
        Console.WriteLine("1.Name");
        Console.WriteLine("2.Salary");
        Console.WriteLine("3.Experience");
        Console.WriteLine("4.End");
        int option=int.Parse(Console.ReadLine());

        foreach(Employee emp in list)
        {
            if(emp.Id == id)
            {
                switch (option)
                {
                    case 1: Console.WriteLine("Enter the updated name:");
                        String update=Console.ReadLine();
                        emp.Name=update;
                        goto select;
                    case 2: Console.WriteLine("Enter the updated salary");
                        int updatesal=int.Parse(Console.ReadLine());
                        emp.Salary=updatesal;goto select;
                    case 3: Console.WriteLine("Enter the updated Experience:");
                        int updateexp=int.Parse(Console.ReadLine());
                        emp.Experience=updateexp;goto select;
                    case 4:
                        break ;
                    default: Console.WriteLine("Enter correct value");
                        goto select;
                }
                break;
            }
        }
        Console.WriteLine("Updated Successfully");
    }




    // Searching an employee
    public static void Search(List<Employee> list, String name)
    {
        foreach (Employee employee in list)
        {
            if (employee.Name == name)
            {
                Console.WriteLine("Employee Id : {0}", employee.Id);
                Console.WriteLine("Employee Salary : {0}", employee.Salary);
                Console.WriteLine("Employee Experience : {0}", employee.Experience);
            }
        }

    }


    //Sorting Employee by Name using Delegate
    public static void sortname(List<Employee> list)
    {
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
    }



    //Sorting Employee by Salary
    public static void sortsalary(List<Employee> list)
    {
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
    }



    //Delete an Employee
    public static void delete(List<Employee> list,int id1)
    {
        foreach (Employee employee in list)
        {
            if (employee.Id == id1)
            {
                list.Remove(employee);
                break;
            }

        }
        

    }


    // Display all the Employees
    public static void display(List<Employee> list)
    {
        foreach (Employee emp in list)
        {
            Console.WriteLine("ID: {0} , Name: {1} , Salary: {2} , Experience: {3}",emp.Id,emp.Name,emp.Salary,emp.Experience);
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


















































//Employee employee1 = new Employee()
//{
//    Id = 1,
//    Name = "Paul",
//    Salary = 5000,
//    Experience = 3

//};
//Employee employee2 = new Employee()
//{
//    Id = 2,
//    Name = "Bob",
//    Salary = 6000,
//    Experience = 4

//};
//Employee employee3 = new Employee()
//{
//    Id = 1,
//    Name = "Jack",
//    Salary = 3000,
//    Experience = 2

//};
//Employee employee4 = new Employee()
//{
//    Id = 4,
//    Name = "Ross",
//    Salary = 8000,
//    Experience = 5

//};
//list.Add(employee1);
//list.Add(employee2);
//list.Add(employee3);
//list.Add(employee4);






////Updating Employee
//foreach (Employee employee in list)
//{
//    if (employee.Name == "Jack")
//    {
//        employee.Salary = 4000;
//    }
//}
//foreach (Employee employee in list)
//{
//    Console.WriteLine(employee.Name + "    " + employee.Salary);
//}