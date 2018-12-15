using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 引用传递
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(22, "郭大路");
            GetPerson(p);
            Console.WriteLine(p.name + ":" + p.Age);
            Console.ReadKey();
        }

        public static void GetPerson(Person p)
        {
            Person test = p;
            test.name = "燕七";
            test.Age = 12;
            Console.WriteLine(test.name + ":" + test.Age);
        }
    }

    class Person
    {
        public int Age { get; set; }
        public string name { get; set; }

        public Person(int Age,string name)
        {
            this.Age = Age;
            this.name = name;
        }
    }
}
