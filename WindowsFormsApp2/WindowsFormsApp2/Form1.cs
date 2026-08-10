using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        double value1;
        double value2;
        double result = 0;
        string sign;
        List<double> history = new List<double>();

        const string ordnerpfad = @"G:\IT-Softwareentwicklung\JuniorN\Aufgaben\C#\WindowsFormsApp2\XML";
        string dateipfad = Path.Combine(ordnerpfad, "daten.xml");

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
            label2.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) return;

            value1 = Convert.ToDouble(textBox1.Text);
            sign = "+";
            label1.Text = textBox1.Text + sign;
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) return;

            value1 = Convert.ToDouble(textBox1.Text);
            sign = "-";
            label1.Text = textBox1.Text + sign;
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) return;

            value1 = Convert.ToDouble(textBox1.Text);
            sign = "*";
            label1.Text = textBox1.Text + sign;
            textBox1.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) return;

            value1 = Convert.ToDouble(textBox1.Text);
            sign = "/";
            label1.Text = textBox1.Text + sign;
            textBox1.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
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
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ",";
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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
    }
}
