using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_training
{
    class Lagerbestand<T>
    {
        private List<T> element = new List<T>();


        public void AddElement(T item) 
        { 
            element.Add(item);
        }

        public void RemoveElement(T item) 
        {
            element.Remove(item);
        }

        public int numElement()
        {
            return element.Count;
        }
        public override string? ToString()          //<-- Manuelle überschreibung von ToString() spezifisch für Elemememte der Lagerbestand Class
        {
            string emptystring = "";
            foreach (var item in element)           //<-- Für jede Varibale in meinen elementen 
            { emptystring += item + Environment.NewLine; }
            return emptystring;                     //<-- den Inhalt mit dem der String befühllt wurde wieder geben
        }
    }

}
