using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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

        List<string> calclogsOP = new List<string>();
        List<string> log = new List<string>();
        List<string> logOP = new List<string>();

        List<double> history = new List<double>();
        List<double> calclogsNum = new List<double>();
        List<double> PostConcat = new List<double>(); 
        

        const string ordnerpfad = @"C:\Users\JuniorN\source\repos\nj888frfr\wowo-C-\WindowsFormsApp2\XML";
        string dateipfad = Path.Combine(ordnerpfad, "daten.xml");
        string xmlcalc = Path.Combine(ordnerpfad, "xmlcalc.xml");
        



        public Form1()
        {
            InitializeComponent();
            XMLÜberwachung();
            TimeStamp(); // Form1 Konstruktor
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void EventClickNumHandler(object sender, EventArgs e)
        {

            var button = (Button)sender;
            int conv = Convert.ToInt32(button.Text);
            textBox1.Text += button.Text;
            TimeStamp(button.Text, button); //übergibt alle button inputs (Num)
            calclogsNum.Add(conv);
            
        }

        public void schlagmmichtot()
        {
            string combined = string.Concat(calclogsNum);
            double NewVal = double.Parse(combined);
            PostConcat.Add(NewVal);
            calclogsNum.Clear();
        }


        private void EventClickArithmeticHandler(object sender, EventArgs e)
        {
            var aributton = (Button)sender;


            if (textBox1.Text.Length == 0) return;
            label4.Text = aributton.Text;
            value1 = Convert.ToDouble(textBox1.Text);
            sign = aributton.Text;
            label1.Text = textBox1.Text;
            textBox1.Text = "";
            schlagmmichtot();

        }

        private void SaveButton(object sender, EventArgs e)
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

        private void LoadButton(object sender, EventArgs e)
        {
            var lastIem = history.Last();
            textBox1.Text = lastIem.ToString();
            label1.Text = "";
            label2.Text = "";

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
            label4.Text = sign;


            // 1. WICHTIG: Fügt die Einzelziffern der ZWEITEN Zahl zusammen,
            // bevor wir rechnen und das XML schreiben!
            schlagmmichtot();

            if (sign == "+")
            {
                result = value1 + value2;
                textBox1.Text = Convert.ToString(result);
                label3.Text = Convert.ToString(result);
                textBox1.Text = "";
                label1.Text = "";
                label2.Text = "";
                label4.Text = "";
            }
            else if (sign == "-")
            {
                result = value1 - value2;
                textBox1.Text = Convert.ToString(result);
                label3.Text = Convert.ToString(result);
                textBox1.Text = "";
                label1.Text = "";
                label2.Text = "";
                label4.Text = "";
            }
            else if (sign == "*")
            {
                result = value1 * value2;
                textBox1.Text = Convert.ToString(result);
                label3.Text = Convert.ToString(result);
                textBox1.Text = "";
                label1.Text = "";
                label2.Text = "";
                label4.Text = "";
            }
            else if (sign == "/")
            {
                result = value1 / value2;
                textBox1.Text = Convert.ToString(result);
                label3.Text = Convert.ToString(result);
                textBox1.Text = "";
                label1.Text = "";
                label2.Text = "";
                label4.Text = "";
            }

            // 2. WICHTIG: Den Operator speichern
            calclogsOP.Add(sign);

            // 3. WICHTIG: Das Ergebnis in die History packen, DAMIT die XML-Methode es lesen kann
            history.Add(result);

            // 4. JETZT ERST das XML schreiben, da nun alle Daten (Zahlen, Operator, Ergebnis) bereitstehen
            XMLÜberwachung();

            TimeStamp(buttoninputgleich: (Button)sender);
        }


        int x = 0;
        public void TimeStamp(string parameterString = null, Button buttoninputgleich = null)
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
                else if (!string.IsNullOrEmpty(parameterString) && Program.Closexe == false)
                {
                    parameterString = hms + $" {logD}" + " " + $"button {parameterString} pressed" + Environment.NewLine;
                    File.AppendAllText(path, parameterString);
                }
                else if (Program.Closexe == true)
                {
                    File.AppendAllText(path, hms + " Program ending... I>" + Environment.NewLine);
                }
                else if (buttoninputgleich != null && buttoninputgleich.Text == "=" && !string.IsNullOrEmpty(label3.Text))
                {
                    File.AppendAllText(path, hms + $"{logI}" + " " + result.ToString() + Environment.NewLine);
                }
            }
        }

        public void XMLÜberwachung()
        {
            using (XmlWriter writer = XmlWriter.Create(xmlcalc, new XmlWriterSettings() { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Calculations");

                // Wir gehen alle aufgezeichneten Operationen durch
                for (int i = 0; i < calclogsOP.Count; i++)
                {
                    writer.WriteStartElement("Calculation");
                    writer.WriteAttributeString("Operator", calclogsOP[i]);

                    // Zu Operator i gehören die Zahlen aus PostConcat (immer im 2er-Paar)
                    int indexZahl1 = i * 2;
                    int indexZahl2 = (i * 2) + 1;

                    // Erste Zahl schreiben
                    if (indexZahl1 < PostConcat.Count)
                    {
                        writer.WriteStartElement("Number");
                        writer.WriteValue(PostConcat[indexZahl1]);
                        writer.WriteEndElement();
                    }

                    // Zweite Zahl schreiben
                    if (indexZahl2 < PostConcat.Count)
                    {
                        writer.WriteStartElement("Number");
                        writer.WriteValue(PostConcat[indexZahl2]);
                        writer.WriteEndElement();
                    }

                    // NEU: Das dazugehörige Ergebnis aus der history-Liste schreiben
                    if (i < history.Count)
                    {
                        writer.WriteStartElement("Result");
                        writer.WriteValue(history[i]);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement(); 
                }

                writer.WriteEndElement(); 
            }
        }

    }
}

