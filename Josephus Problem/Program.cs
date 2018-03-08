using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josephus_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of people:");
            try
            { int num_pp = Convert.ToInt32(Console.ReadLine());
                Make(num_pp);
            }
            catch (Exception) { Console.WriteLine("Invalid value"); Console.ReadKey(); Environment.Exit(0); }
        }

        static void Make(int num_pp)
        {
            Person[] People = new Person[num_pp];

            for (int i = 0; i < num_pp; i++)
            {
                People[i] = new Person(i + 1);
            }

            int first = 1;
            int actual = first - 1;
                
            while (Person.Alive > 1)
            {
                Kill(ref actual,People, num_pp);
                if (Person.Alive == 1)
                    break;
                Give(ref actual, People, num_pp);
            }

            Console.WriteLine("Person Alive : {0}", People[actual].name);
            Console.ReadKey();

            
        }

        static void Kill(ref int actual, Person [] People, int num_pp)
        {
            bool retry = true;
            for (int i = actual + 1; i < num_pp; i++)
            {
                if (People[i].ImAlive == true)
                {
                    People[i].ImAlive = false;
                    Person.Alive--;
                    retry = false;
                    Console.WriteLine("{0} kills to {1}", People[actual].name, People[i].name);
                    break;
                }
            }

            if (retry)
            {
                for (int i = 0; i < actual; i++)
                {
                    if (People[i].ImAlive == true)
                    {
                        People[i].ImAlive = false;
                        Person.Alive--;
                        Console.WriteLine("{0} kills to {1}", People[actual].name, People[i].name);
                        break;
                    }
                }
            }
                
        }
    

        public static void Give(ref int actual, Person[] People, int num_pp)
        {
            bool retry = true;
            for (int i = actual + 1; i < num_pp; i++)
            {
                if (People[i].ImAlive == true)
                {
                    Console.WriteLine("{0} gives sword to {1}", People[actual].name, People[i].name);
                    actual = i;
                    retry = false;
                    break;
                }
            }
            if (retry)
            {
                for (int i = 0; i < actual; i++)
                {
                    if (People[i].ImAlive == true)
                    {
                        Console.WriteLine("{0} gives sword to {1}", People[actual].name, People[i].name);
                        actual = i;
                        break;
                    }
                }
            }
        }
    }

    public class Person
    {
        public string name { get; set; }
        public bool ImAlive { get; set; }
        public static int Alive = 0;

        public Person(int a)
        {
            name = "Person " + Convert.ToString(a);
            ImAlive = true;
            Alive++;
        }


    }
}
