using System;
using System.IO;
using System.Threading;

namespace HelloWorld
{
    class Calc
    {
        static void Main(string[] args)
        {
        asd:
            Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome " + name);

        rqnum1:
            Console.WriteLine("Enter Num:");
            string n1 = Console.ReadLine();
            if (int.TryParse(n1, out int n1_new))
            {}
            else
            {
                Console.WriteLine("twin thats not a num. try again");
                goto rqnum1;
            }

            Console.WriteLine("Enter 2nd Num");
        rqnum2:
            string n2 = Console.ReadLine();
            if (int.TryParse(n2, out int n2_new))
            {}    
            else
            {
                Console.WriteLine("twin thats not a num. try again");
                goto rqnum2;
            }

            Console.WriteLine("Bitte geben Sie den gewünschten Operator ein: ");
            string op = Console.ReadLine();
            
            // Variable für das spätere Speichern vorbereiten
            string logText = "";

            if (op == "+")
            {
                logText = n1 + " + " + n2 + " = " + (n1_new + n2_new);
                Console.WriteLine(logText);
                Infosave(logText); 

                Thread.Sleep(1000);
                Console.WriteLine("Do you wish to repeat? y/n");
                string yesno1 = Console.ReadLine();
                if (yesno1 == "y") { goto rqnum1; }
                else if (yesno1 == "n") { Console.WriteLine("ciao kakao " + name); Environment.Exit(0); }
            }
            else if (op == "-")
            {
                logText = n1 + " - " + n2 + " = " + (n1_new - n2_new);
                Console.WriteLine(logText);
                Infosave(logText); 

                Thread.Sleep(1000);
                Console.WriteLine("Do you wish to repeat? y/n");
                string yesno2 = Console.ReadLine();
                if (yesno2 == "y") { goto rqnum1; }
                else if (yesno2 == "n") { Console.WriteLine("ciao kakao " + name); Environment.Exit(0); }
            }
            else if (op == "*")
            {
                logText = n1 + " * " + n2 + " = " + (n1_new * n2_new);
                Console.WriteLine(logText);
                Infosave(logText); 

                Thread.Sleep(1000);
                Console.WriteLine("Do you wish to repeat? y/n");
                string yesno3 = Console.ReadLine();
                if (yesno3 == "y") { goto rqnum1; }
                else if (yesno3 == "n") { Console.WriteLine("ciao kakao " + name); Environment.Exit(0); }
            }   
            else if (op == "/")
            {
                if (n2_new == 0)
                {
                    Console.WriteLine("Fehler: Teilen durch 0 ist nicht erlaubt!");
                    goto rqnum1;
                }
                else
                {
                    float result = (float)n1_new / n2_new;
                    logText = n1 + " / " + n2 + " = " + result;
                    Console.WriteLine(logText);
                    Infosave(logText); 

                    Thread.Sleep(1000);
                    Console.WriteLine("Do you wish to repeat? y/n");
                    string yesno4 = Console.ReadLine();
                    if (yesno4 == "y") { goto rqnum1; }
                    else if (yesno4 == "n") { Console.WriteLine("ciao kakao " + name); Environment.Exit(0); }
                }
            }
            else if (!(op == "-" || op == "+" ||  op == "/" || op == "*")) 
            {
                goto rqnum1;
            }
            goto asd;
        }

        // ERKLÄRUNG: Nimmt jetzt einen String 'text' als Parameter an
        public static void Infosave(string text)
        {
            string myfile = @"file.txt";

            // AppendText erstellt die Datei von alleine, falls sie fehlt.
            // Es fügt den neuen Text immer unten an die Datei an.
            using (StreamWriter sw = File.AppendText(myfile))
            {
                sw.WriteLine(text); 
            }

            // Gibt optional den aktuellen Inhalt der Datei zur Kontrolle aus
            Console.WriteLine("\n--- Aktueller Verlauf in der Datei ---");
            using (StreamReader sr = File.OpenText(myfile))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(" gespeichert: " + s);
                }
            }
            Console.WriteLine("--------------------------------------\n");
        }
    }
}
