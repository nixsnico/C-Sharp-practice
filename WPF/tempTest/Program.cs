using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;


//Longest Word:

//class Program
//{
//    static void Main()
//    {
//        string sentence = ("the quick brown fox jumped");
//        string[] words = sentence.Split(' ');
//        var longest = words.Where(s => s.Length == words.Max(m => m.Length)).First();
//        Console.WriteLine(longest);
//    }
//}


//Reverse Words:

//class Program
//{
//    static void Main()
//    {
//        string s = ("I love coding").Trim();
//        List<string> rev = new List<string>();
//        string[] words = s.Split(' ');

//        for (int i = words.Length - 1; i >= 0; --i)
//        {
//            rev.Add(words[i]);
//        }
//        string com = string.Join(" ", rev);

//        Console.WriteLine(com);
//        // Reverse the string without using Array.Reverse()
//    }
//}


//Most Common Char:

//class Program
//{
//    static void Main()
//    {
//        string input = Console.ReadLine();

//        char result = GetMostFrequentChar(input);
//        Console.WriteLine(string.Join(result));
//    }
//    private static char GetMostFrequentChar(string str)
//    {
//        Dictionary<char, int> chars = new Dictionary<char, int>();

//        foreach (char c in str)
//        {
//            if (chars.ContainsKey(c)) chars[c]++;
//            else chars.Add(c, 1);
//        }

//        int max = chars.Values.Max();
//        return chars.Where(b => b.Value == max)
//                    .Select(b => b.Key)
//                    .OrderBy(c => char.ToLower(c))
//                    .First();
//    }
//}



//Letter Frequency:

//class Program
//{
//    static void Main()
//    {
//        var word = Console.ReadLine() ?? string.Empty;

//        var words = word
//          .OrderBy(w => w)
//           .GroupBy(w => w);

//        foreach (var g in words)
//        {
//            Console.WriteLine($"{g.Key}:{g.Count()}");
//        }
//    }
//}


//Word Frequency:

//class Program
//{
//    static void Main()
//    {

//        var word = Console.ReadLine() ?? string.Empty;

//        string[] jucke = word.Split(' ');

//        var words = jucke
//          .GroupBy(w => w)
//          .OrderBy(w => w.Key);

//        foreach (var g in words)
//        {
//            Console.WriteLine($"{g.Key}:{g.Count()}");
//        }
//    }
//}



//Remove Duplicates:

//class Program
//{
//    static void Main()
//    {
//        var text = Console.ReadLine() ?? string.Empty;
//        StringBuilder removeddupes = new();


//        if (text.Length > 0) 
//        {
//            for (int i = 0; i < text.Length; i++)
//            {
//                if (i == 0 || text[i] != text[i -])
//                {
//                    removeddupes.Append(text[i]);
//                }
//            }
//            Console.WriteLine(removeddupes.ToString());
//        }
//        //var duplicateeItems = from x in list
//        //                      group x by x into grouped
//        //                      where grouped.Count() > 1
//        //                      select grouped.Key;
//    }
//}




//Run Length Encoding

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        //StringBuilder is a way of making a manipulateable string wasting a lot of memory 
        StringBuilder compressed = new StringBuilder();
        int count = 1;

        // Loop through the string to check consecutive characters
        for (int i = 0; i < text.Length; i++)

        {                           // text[i] == text[i + 1]
                                    // =
                                    // text[letter right now] is the same as text[as the next letter] in the string 
            if (i + 1 < text.Length && text[i] == text[i + 1])
            {
                count++;
            }
            else
            {              
                compressed.Append(text[i]);
                compressed.Append(count);

                count = 1;
            }
        }

        Console.WriteLine(compressed.ToString());
    }
}


