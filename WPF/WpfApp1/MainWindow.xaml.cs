using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("persons.json"))
            {
                string json = File.ReadAllText("persons.json");
                var LoadPersons = JsonSerializer.Deserialize<ObservableCollection<Person>>(json);

                Persons = LoadPersons ?? new ObservableCollection<Person>();
            }


            Persons.CollectionChanged += HandleChange;
            DataContext = this;

        }

        private void HandleChange(object? sender, NotifyCollectionChangedEventArgs e)
        {

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        { 
            string json = JsonSerializer.Serialize(Persons);
            File.WriteAllText("persons.json", json);
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
}



