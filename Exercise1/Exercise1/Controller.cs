using System;



class Controller : Method
{



    /// <summary>
    /// Add an employee
    /// </summary>
    /// <param name="list"></param>
    public void add(List<Employee> list)
    {
        Employee employee = new Employee();
        try
        {
            Console.WriteLine("Enter Id :");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            String name = Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            int sal = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Experience");
            int exp = int.Parse(Console.ReadLine());
            employee.Id = id;
            employee.Name = name;
            employee.Salary = sal;
            employee.Experience = exp;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        list.Add(employee);
    }


    /// <summary>
    /// Update the specified Employee
    /// </summary>
    /// <param name="list"></param>
    /// <param name="id"></param>
    public void update(List<Employee> list)
    {
        Console.WriteLine("Enter the Id to be updated:");
        int id = 0;
        try
        {
            id = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }

    select:
        Console.WriteLine("Choose the field that has to be updated");
        Console.WriteLine("1.Name");
        Console.WriteLine("2.Salary");
        Console.WriteLine("3.Experience");
        Console.WriteLine("4.End");
        int option = int.Parse(Console.ReadLine());

        foreach (Employee emp in list)
        {
            if (emp.Id == id)
            {
                switch (option)
                {
                    case (int)(Option.UpdateName):
                        Console.WriteLine("Enter the updated name:");
                        String update = Console.ReadLine();
                        emp.Name = update;
                        goto select;
                    case (int)(Option.UpdateSalary):
                        Console.WriteLine("Enter the updated salary");
                        int updatesal = int.Parse(Console.ReadLine());
                        emp.Salary = updatesal; goto select;
                    case (int)(Option.UpdateExp):
                        Console.WriteLine("Enter the updated Experience:");
                        int updateexp = int.Parse(Console.ReadLine());
                        emp.Experience = updateexp; goto select;
                    case (int)(Option.End):
                        break;
                    default:
                        Console.WriteLine("Enter correct value");
                        goto select;
                }
                break;
            }
        }
        Console.WriteLine("Updated Successfully");
    }







    /// <summary>
    /// Search for the specified Employee
    /// </summary>
    /// <param name="list"></param>
    /// <param name="name"></param>
    public void Search(List<Employee> list, String name)
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


    /// <summary>
    /// Sort the employee by name
    /// </summary>
    /// <param name="list"></param>
    public void sortname(List<Employee> list)
    {
        Console.WriteLine("Before Sorting");
        foreach (Employee employee in list)
        {
            Console.WriteLine("ID: {0} , Name: {1} , Salary: {2} , Experience: {3}", employee.Id, employee.Name, employee.Salary, employee.Experience);
        }
        list.Sort(delegate (Employee emp1, Employee emp2) { return emp1.Name.CompareTo(emp2.Name); });
        Console.WriteLine("After Sorting");
        foreach (Employee employee in list)
        {
            Console.WriteLine("ID: {0} , Name: {1} , Salary: {2} , Experience: {3}", employee.Id, employee.Name, employee.Salary, employee.Experience);
        }
    }



    /// <summary>
    /// Sort the employees by salary
    /// </summary>
    /// <param name="list"></param>
    public void sortsalary(List<Employee> list)
    {
        Console.WriteLine("Before Sorting");
        foreach (Employee emp in list)
        {
            Console.WriteLine("ID: {0} , Name: {1} , Salary: {2} , Experience: {3}", emp.Id, emp.Name, emp.Salary, emp.Experience);
        }
        list.Sort();
        Console.WriteLine("After Sorting");
        foreach (Employee emp in list)
        {
            Console.WriteLine("ID: {0} , Name: {1} , Salary: {2} , Experience: {3}", emp.Id, emp.Name, emp.Salary, emp.Experience);
        }
    }



    /// <summary>
    /// Deletes the specified Employee
    /// </summary>
    /// <param name="list"></param>
    /// <param name="id1"></param>
    public void delete(List<Employee> list, int id1)
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


    /// <summary>
    /// Displays all the Employees
    /// </summary>
    /// <param name="list"></param>
    public void display(List<Employee> list)
    {
        foreach (Employee emp in list)
        {
            Console.WriteLine("ID: {0} , Name: {1} , Salary: {2} , Experience: {3}", emp.Id, emp.Name, emp.Salary, emp.Experience);
        }
    }
}