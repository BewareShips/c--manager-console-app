using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask
{
    class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public double salary { get; set; }

        public Person(int id, string name, int age, double salary)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.salary = salary;
        }

        public string returnDetails()
        {

            return "Employee ID : " + id + "\nName : " + name + "\nAge : " + age + "\nSalary : " + salary;
        }
    }
}
