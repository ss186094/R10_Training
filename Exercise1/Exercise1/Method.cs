using System;

interface Method
{
    void add(List<Employee> list);
    void update(List<Employee> list);

    void Search(List<Employee> list, String name);

    void sortname(List<Employee> list);

    void sortsalary(List<Employee> list);

    void delete(List<Employee> list,int id);

    void display(List<Employee> list);
}
