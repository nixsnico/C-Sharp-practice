using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        double value1;
        double value2;
        double result = 0;
        string sign;

        List<string> log = new List<string>();
        List<double> history = new List<double>();
        List <string> logOP = new List<string>();


        const string ordnerpfad = @"C:\Users\JuniorN\source\repos\nj888frfr\wowo-C-\WindowsFormsApp2\XML";
        string dateipfad = Path.Combine(ordnerpfad, "daten.xml");


        

        public Form1()
        {
            //Logger.Log("Programm gestartet", dateipfad);
            
            InitializeComponent();
            TimeStamp(); // Form1 Konstruktor
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void EventClickNumHandler(object sender, EventArgs e)
        {
            var button = (Button)sender;

            //if (button is Button)
            //{
                textBox1.Text += button.Text;
            //}
            TimeStamp(button.Text, button);

            //log(button.Text);

        }

        private void EventClickArithmeticHandler(object sender, EventArgs e)
        {
            var aributton = (Button)sender;

            if (textBox1.Text.Length == 0) return;

            value1 = Convert.ToDouble(textBox1.Text);
            sign = aributton.Text;
            label1.Text = textBox1.Text + sign;
            textBox1.Text = "";

            //log(aributton.Text);

        }





        private void button17_Click_1(object sender, EventArgs e)
        {
            using (XmlWriter writer = XmlWriter.Create(dateipfad, new XmlWriterSettings() { Indent = true }))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("Datenbank");
                writer.WriteStartElement("History");
                foreach (var item in history)
                {
                    writer.WriteStartElement("Ergebnis");
                    writer.WriteValue(item);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var lastIem = history.Last();
            textBox1.Text = lastIem.ToString();

        }



        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ",";
        }
        private void buttonAC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
            label2.Text = "";

        }
        private void Gleich(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0) return;

            value2 = Convert.ToDouble(textBox1.Text);
            label2.Text = textBox1.Text;
            if (sign == "+")
            {
                result = value1 + value2;
                textBox1.Text = Convert.ToString(result);
                label3.Text = Convert.ToString(result);
                textBox1.Text = "";
                label1.Text = "";
                label2.Text = "";

            }
            else if (sign == "-")
            {
                result = value1 - value2;
                textBox1.Text = Convert.ToString(result);
                label3.Text = Convert.ToString(result);
                textBox1.Text = "";
                label1.Text = "";
                label2.Text = "";

            }
            else if (sign == "*")
            {
                result = value1 * value2;
                textBox1.Text = Convert.ToString(result);
                label3.Text = Convert.ToString(result);
                textBox1.Text = "";
                label1.Text = "";
                label2.Text = "";

            }
            else if (sign == "/")
            {
                result = value1 / value2;
                textBox1.Text = Convert.ToString(result);
                label3.Text = Convert.ToString(result);
                textBox1.Text = "";
                label1.Text = "";
                label2.Text = "";


            }


            history.Add(result);
            TimeStamp(meinButtonDerÜbergebenWurde: (Button)sender);
        }

        int x = 0;
        public void TimeStamp(string parameterString = null, Button meinButtonDerÜbergebenWurde = null)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string folderPath = $@"C:\Users\JuniorN\source\repos\nj888frfr\wowo-C-\WindowsFormsApp2\XML";
            string path = Path.Combine(folderPath, $"Log_{date}.txt");


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(DateTime.Now);
                }

            }
            else
            {
                
                string logI = "I>";
                string logD = "D>";
                string hms = DateTime.Now.ToString("HH:mm:ss");
                
                // wenn parameterString NULL ist, dann übergeben wir keine Zahl
                if (parameterString == null && x == 0)
                {
                    x += 1;
                    File.AppendAllText(path, Environment.NewLine + "Program starting... I>" + Environment.NewLine);
                }
                if (Program.Closexe == false)
                {

                    parameterString = hms + $" {logD}" + " " + parameterString + Environment.NewLine;
                    File.AppendAllText(path, parameterString);
                }
                else if (Program.Closexe == true)
                {
                    File.AppendAllText(path, hms + " Program ending... I>" + Environment.NewLine);
                }


                if (meinButtonDerÜbergebenWurde != null && meinButtonDerÜbergebenWurde.Text == "=")
                {
                    File.AppendAllText(path, hms + $"{logI}" + " " + result.ToString() + Environment.NewLine);
                }
            }
        }
    }
}

