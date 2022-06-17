using System;
using Newtonsoft.Json;
using System.Linq;
using System.IO;


class Program
{
    static void Main(String[] args)
    {
        var people = ReadPeopleFromJsonFile();
    
        //var firstPerson=people.First();
        var firstPerson=people.FirstOrDefault();
        if(firstPerson == null)
        {
            Console.WriteLine("Person not existing");
        }
        else
        {

        }
        Console.WriteLine(firstPerson);

       // var lastPerson=people.Last();
       var lastPerson=people.LastOrDefault();
        if(lastPerson == null)
        {
              Console.WriteLine("Person not existing");
        }
        Console.WriteLine(lastPerson);




        var firstPersonStartsWithA= people.FirstOrDefault(p=> p.FirstName.StartsWith("A"));
        Console.WriteLine(firstPersonStartsWithA);




        var getSinglePerson = people.SingleOrDefault(p=> p.Id== 10004);
        Console.WriteLine(getSinglePerson);



        var maxSalary =people.Max(p=>p.Salary); 
        Console.WriteLine(maxSalary);
        var minSalary=people.Min(p=>p.Salary);
        Console.WriteLine(minSalary);
        var avgSalary=people.Average(p=>p.Salary);  
        Console.WriteLine(avgSalary);




        if (people.Any())
        {
            Console.WriteLine("There are people in the list");
        }
        else
        {
            Console.WriteLine("No people in the list");
        }






        //var peopleSortedByAge = people.OrderBy(p => p.BirthDate).ThenBy(p=>p.FirstName).ToArray();
        //foreach(var person in peopleSortedByAge)
        //{
        //    Console.WriteLine(person);
        //}




        //var firstTenPeople = people.Take(10);
        //var skipTenPeople= people.Skip(10);

        //int pageSize = 10;
        //int pageNumber = 1;
        //Console.WriteLine("Paging-----------------------------------------------");
        //var peopleByPaging = people.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        //foreach(var item in peopleByPaging)
        //{
        //    Console.WriteLine(item);
        //}




        //Console.WriteLine("Where----------------------------------------------");
        //var filteredData = people.Where(p => p.BirthDate > new DateTime(1990, 1, 1) && p.Salary > 3500);
        //foreach(var item in filteredData)
        //{
        //    Console.WriteLine(item);
        //}



        //Grouping
        Console.WriteLine("Grouping----------------------------------------------------");
        var peopleByCity=people.GroupBy(p => p.City);   
        foreach(var item in peopleByCity)
        {
            Console.WriteLine($"{item.Key}");
            foreach(var person in item)
            {
                Console.WriteLine($"\t{person}");
            }
        }


        //Query Syntax

        var peopleWithHighSalaries = (from p in people where p.Salary > 5000 && p.City == "Cairo" orderby p.Id descending select p);

        // Projection

        var olderPeopleIds= people.Where(p=> p.BirthDate < new DateTime(1990,1,1)).Select(p=> p.Id);
        foreach(var item in olderPeopleIds)
        {
            Console.Write($"{item} ");
        }

        var projectionPeople = people.Select(p => new 
        {
            Id = p.Id,
            FullName = p.FirstName +" "+ p.LastName
        }) ;
        foreach(var item in projectionPeople)
        {
            Console.WriteLine(item.FullName);
        }


    }
    static Person[] ReadPeopleFromJsonFile()
    {
        using(var reader=new StreamReader("people.json"))
        {
            string jsonData=reader.ReadToEnd();
            var people= JsonConvert.DeserializeObject<Person[]>(jsonData);
            return people;
        }

    }

}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string City { get; set; }

    public decimal Salary { get; set; }

    public DateTime BirthDate { get; set; }


    public override string ToString()
    {
        return ($"{Id} {FirstName} {LastName} |{City} | {BirthDate.ToShortDateString()} | ${Salary}");
    }
}
