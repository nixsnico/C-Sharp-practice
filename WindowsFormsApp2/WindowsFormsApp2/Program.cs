using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace WindowsFormsApp2
{
    internal static class Program
    {
        public static bool Closexe { get; set; } = false;
        // initialisieren
        static Form1 form1 = null;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += OnApplicationExit;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // instanziiere
            form1 = new Form1();
            Application.Run(form1);
        }

        
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            Closexe = true;

            form1.TimeStamp();
        }
    }
}
