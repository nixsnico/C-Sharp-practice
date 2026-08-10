using System;
using System.Formats.Asn1;
using System.Linq;



namespace summierung 
{
    class Program
    {

        static void Main()
        {
            {
                Console.WriteLine("Welche Aufgabe?");
                Console.WriteLine();
                string input2k = Console.ReadLine()??"";

                if (input2k == "1")

                
                    {
                        int[] gruppe1 = new int[]{1,2,3,1,2};
                        int[] gruppe2 = new int[]{1,2,3,4,5};
                        int[] gruppe3 = new int[]{1,2,3,3,2,1};

                        int summe1 = gruppe1.Sum();
                        int summe2 = gruppe2.Sum();
                        int summe3 = gruppe3.Sum();

                        Console.WriteLine(summe1);
                        Console.WriteLine(summe2);
                        Console.WriteLine(summe3);
                    }

                if (input2k == "2")
                    {
                        int[] gruppe4 = new int[]{1,2,3,1,2};
                        int[] gruppe5 = new int[]{1,2,3,4,5};
                        int[] gruppe6 = new int[]{1,2,3,3,2,1};

                        int[] UniqueNum4 = gruppe4
                        //gruppiert den shi
                        .GroupBy(x => x)
                        //guckt ob die gruppe(g) mehr als einmal existiert, ergo 1x2 wäre EINMAL in ner ZWEIER Gruppe
                        .Where(g => g.Count() == 1)
                        //macht die gruppen wieder zu Keys(trocks)
                        .Select(g => g.Key)
                        //macht diese dann zu einem Lesbaren Array
                        .ToArray();

                        int[] UniqueNum5 = gruppe5
                        .GroupBy(x => x)
                        .Where(g => g.Count() == 1)
                        .Select(g => g.Key)
                        .ToArray();

                        int[] UniqueNum6 = gruppe6
                        .GroupBy(x => x)
                        .Where(g => g.Count() == 1)
                        .Select(g => g.Key)
                        .ToArray();


                        int UniSum4 = UniqueNum4.Sum();
                        int UniSum5 = UniqueNum5.Sum();
                        int UniSum6 = UniqueNum6.Sum();

                        Console.WriteLine(UniSum4);
                        Console.WriteLine(UniSum5);
                        Console.WriteLine(UniSum6);
                        
                    }
                
                if (input2k == "3")
                    {
                        int[] gruppe7 = new int[]{1,2,3,1,2};
                        int[] gruppe8 = new int[]{1,2,3,4,5};
                        int[] gruppe9 = new int[]{1,2,3,3,2,1};

                        int[] UniqueNum7 = gruppe7
                     //gruppiert den shi
                        .GroupBy(x => x)
                        .Where(g => g.Count() > 1)
                        //macht die gruppen wieder zu Keys(trocks)
                        .Select(g => g.Key)
                        //macht diese dann zu einem Lesbaren Array
                        .ToArray();

                        int[] UniqueNum8 = gruppe8
                        .GroupBy(x => x)
                        .Where(g => g.Count() > 1)
                        .Select(g => g.Key)
                        .ToArray();

                        int[] UniqueNum9 = gruppe9
                        .GroupBy(x => x)
                        .Where(g => g.Count() > 1)
                        .Select(g => g.Key)
                        .ToArray();


                        int UniSum7 = UniqueNum7.Sum();
                        int UniSum8 = UniqueNum8.Sum();
                        int UniSum9 = UniqueNum9.Sum();

                        Console.WriteLine(UniSum7);
                        Console.WriteLine(UniSum8);
                        Console.WriteLine(UniSum9);
                    }

                if(input2k == "4")
                    {
                    int[] gruppe1 = new int[]{1,2,3,1,2};
                    int[] gruppe2 = new int[]{1,2,3,4,5};
                    int[] gruppe3 = new int[]{1,2,3,3,2,1};

                    int summe1 = gruppe1.Sum();
                    int summe2 = gruppe2.Sum();
                    int summe3 = gruppe3.Sum();

                        //-------------------------------------//

                    int[] gruppe4 = new int[]{1,2,3,1,2};
                    int[] gruppe5 = new int[]{1,2,3,4,5};
                    int[] gruppe6 = new int[]{1,2,3,3,2,1};

                    int[] UniqueNum4 = gruppe4
                    //gruppiert den shi
                    .GroupBy(x => x)
                    //guckt ob die gruppe(g) mehr als einmal existiert, ergo 1x2 wäre EINMAL in ner ZWEIER Gruppe
                    .Where(g => g.Count() == 1)
                    //macht die gruppen wieder zu Keys(trocks)
                    .Select(g => g.Key)
                    //macht diese dann zu einem Lesbaren Array
                    .ToArray();

                    int[] UniqueNum5 = gruppe5
                    .GroupBy(x => x)
                    .Where(g => g.Count() == 1)
                    .Select(g => g.Key)
                    .ToArray();

                    int[] UniqueNum6 = gruppe6
                    .GroupBy(x => x)
                    .Where(g => g.Count() == 1)
                    .Select(g => g.Key)
                    .ToArray();


                    int UniSum4 = UniqueNum4.Sum();
                    int UniSum5 = UniqueNum5.Sum();
                    int UniSum6 = UniqueNum6.Sum();

                        //---------------------------------//

                    int[] gruppe7 = new int[]{1,2,3,1,2};
                    int[] gruppe8 = new int[]{1,2,3,4,5};
                    int[] gruppe9 = new int[]{1,2,3,3,2,1};

                    int[] UniqueNum7 = gruppe7
                        //gruppiert den shi
                    .GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                        //macht die gruppen wieder zu Keys(trocks)
                    .Select(g => g.Key)
                        //macht diese dann zu einem Lesbaren Array
                    .ToArray();

                    int[] UniqueNum8 = gruppe8
                    .GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToArray();

                    int[] UniqueNum9 = gruppe9
                    .GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToArray();


                    int UniSum7 = UniqueNum7.Sum();
                    int UniSum8 = UniqueNum8.Sum();
                    int UniSum9 = UniqueNum9.Sum();
                    string univ  = $"{summe1} {summe2} {summe3}";
                    string univ2 = $"{UniSum4} {UniSum5} {UniSum6}";
                    string univ3 = $"{UniSum7} {UniSum8} {UniSum9}";
                    Console.WriteLine(univ);
                    Console.WriteLine(univ2);
                    Console.WriteLine(univ3);     
                }
                
            }
        }
    }
}
