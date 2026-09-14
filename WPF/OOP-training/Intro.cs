using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OOP_training
{
    public class Person
    {

        private int age;
        public string Name { get; set; }
        public int Age
        { 
           get { return age; }
           set 
           {
                if (value < 0)
                {
                    age = 0;
                    Console.WriteLine("Alter kann nicht negativ sein. Es wurde auf 0 gesetzt.");
                }
                else
                {
                    age = value;
                }
           }
        }
        
        public void Introduce(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public void Vorstellung(string Name, int Age)
        {
            Console.WriteLine($"Hallo, mein Name ist {Name} und ich bin {Age} Jahre alt.");
        }
    }
}
