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

        
        public string Name { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidAge("Alter kann nicht negativ sein");
                }
                age = value;
            }
        }
        private int age;

        public void Introduce(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public void Vorstellung(string Name, int Age)
        {
            Console.WriteLine($"Hallo, mein Name ist {Name} und ich bin {Age} Jahre alt.");
        }

        public class InvalidAge : Exception
        {
            public InvalidAge(string message)
                : base(message)
            {
                
            }

            public InvalidAge(string message, Exception innerException)
                :base(message, innerException) 
            {
            
            }


        }
    }
}
