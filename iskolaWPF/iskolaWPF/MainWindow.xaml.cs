using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace iskolaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> list = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            StreamReader r = new StreamReader("nevek.txt");
            while (!r.EndOfStream)
            {
                list.Add(r.ReadLine());
            }
            r.Close();
            Listbox.ItemsSource= list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                list.RemoveAt(Listbox.SelectedIndex);
                Listbox.Items.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Nem jelölt ki tanulót!");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter w = new StreamWriter("nevekNEW.txt");
                for (int i = 0; i < list.Count; i++)
                {
                    w.WriteLine(list[i]);
                }                
                w.Close();
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
