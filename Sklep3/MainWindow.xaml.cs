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

namespace Sklep3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Item> list;
        public MainWindow()
        {
            InitializeComponent();

            list = new List<Item>();
            list.Add(new Item { ItemName = "Onion  ", ItemCount = 0, ItemPrice = 100 });
            list.Add(new Item { ItemName = "Potato  ", ItemCount = 0, ItemPrice = 200 });
            list.Add(new Item { ItemName = "Garlic  ", ItemCount = 0, ItemPrice = 300 });
            list.Add(new Item { ItemName = "RedMeat  ", ItemCount = 0, ItemPrice = 400 });
            list.Add(new Item { ItemName = "Pork  ", ItemCount = 0, ItemPrice = 500 });
            list.Add(new Item { ItemName = "Salmon  ", ItemCount = 0, ItemPrice = 600 });
            list.Add(new Item { ItemName = "Herring  ", ItemCount = 0, ItemPrice = 700 });
            list.Add(new Item { ItemName = "Dressing  ", ItemCount = 0, ItemPrice = 800 });
            listbox.ItemsSource = list;

        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl != null)
            {
                StackPanel parent = (StackPanel)ctrl.Parent;
                var res = (TextBlock)parent.FindName("t1");

                var record = list.FirstOrDefault(x => x.ItemName == res.Text);
                record.ItemCount -= (record.ItemCount > 0) ? 1 : 0;

                var resTemp = list.First(x => x.ItemName == res.Text).ItemCount > 0 ? list.First(x => x.ItemName == res.Text).ItemCount-- : 0;
                
                res = (TextBlock)parent.FindName("t2");
                res.Text = record.ItemCount.ToString();
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl != null)
            {
                StackPanel parent = (StackPanel)ctrl.Parent;
                var res = (TextBlock)parent.FindName("t1");
                var record = list.FirstOrDefault(x => x.ItemName == res.Text);
                record.ItemCount += 1;

                

                res = (TextBlock)parent.FindName("t2");
                res.Text = record.ItemCount.ToString();
            }
        }        
        private void buttonSum_Click(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            StringBuilder s = new StringBuilder();
            foreach(var rec in list)
            {
                sum += rec.ItemCount * rec.ItemPrice;
                if (rec.ItemCount > 0) {
                    s.Append($"[{rec.ItemName}] items:{rec.ItemCount} cost per unit: {rec.ItemPrice} ");
                }
            }
            
            Control ctrl = sender as Control;
            if (ctrl != null)
            {
                StackPanel parent = (StackPanel)ctrl.Parent;
                var res = (TextBlock)parent.FindName("t4");
                res.Text = $"Sum: {sum}{Environment.NewLine}{s}";                
            }
        }

        private void buttonRestart_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }
    }
    public class Item
    {
        public string ItemName { get; set; }
        public int ItemCount { get; set; }

        public int ItemPrice { get; set; }

        public override string ToString()
        {
            return this.ItemName + ", " + this.ItemCount + " items";
        }
    }

}
