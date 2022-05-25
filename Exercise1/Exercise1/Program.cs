using System;
using log4net;

public class Program
{
    static protected ILog log = LogManager.GetLogger("Task");

    public static void Main()
    {
        AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;
        FileInfo fileInfo = new FileInfo(@"C:\Users\ss186094\OneDrive - NCR Corporation\Documents\R10 Exercise\R10_Training\Exercise1\Exercise1\log4net.config");
        log4net.Config.XmlConfigurator.Configure(fileInfo);

        Controller controller = new Controller();
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
        int option = 0;
        try
        {
            option = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            log.Error(ex);
            Console.WriteLine(ex.Message);
        }

        string s = "-------------------------------------------------------------------";
        switch (option)
        {
            case (int)(Option.Add):
                controller.add(list);
                Console.WriteLine(s);
                goto start;


            case (int)(Option.Update):

                controller.update(list);
                Console.WriteLine(s);
                goto start;

            case (int)(Option.Search):
                Console.WriteLine("Enter the employee Name:");
                String name = Console.ReadLine();
                controller.Search(list, name);
                Console.WriteLine(s);
                goto start;

            case (int)(Option.Sortname):
                controller.sortname(list);
                Console.WriteLine(s);
                goto start;

            case (int)(Option.Sortsal):
                controller.sortsalary(list);
                Console.WriteLine(s);
                goto start;

            case (int)(Option.Delete):
                Console.WriteLine("Enter Id:");
                int id1 = int.Parse(Console.ReadLine());
                controller.delete(list, id1);
                Console.WriteLine(s);
                goto start;

            case (int)(Option.Display):
                controller.display(list);
                Console.WriteLine(s);
                goto start;
            default:
                Console.WriteLine("Enter a valid option");
                Console.WriteLine(s);
                goto start;


        }


        

    }
    private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        log.Error(e.ExceptionObject.ToString());
        Console.WriteLine("Global Exception: " + e.ExceptionObject.ToString());

    }
}





















































