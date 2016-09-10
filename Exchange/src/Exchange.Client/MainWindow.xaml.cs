using Exchange.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using System.Threading;
using System.Diagnostics;

namespace Exchange.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExchangeManager manager = new ExchangeManager(new Uri("http://cb.am/latest.json.php"));
        private ObservableCollection<CurrRatePair> collection = new ObservableCollection<CurrRatePair>();
        private Task<Dictionary<string, decimal>> task;
        private DispatcherTimer timer = new DispatcherTimer();
        CancellationTokenSource cts = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();

            listView.ItemsSource = collection;
            timer.Interval = new TimeSpan(0,0,4);
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (task != null && !task.IsCompleted)
            {
                cts.Cancel();
            }

            task = manager.Get(cts.Token);
            label.Content = "Updateing...";

            if (!task.IsCanceled)
            {
                var dictionary = await task;
                Debug.WriteLine(task.Id);
                label.Content = $"Last Updated: {DateTime.Now.ToLocalTime()}";
                collection.Clear();
                foreach (var kv in dictionary)
                {
                    collection.Add(new CurrRatePair { Currency = kv.Key, Rate = kv.Value });
                }
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

    class CurrRatePair
    {
        public string Currency { get; set; }
        public decimal Rate { get; set; }
    }
}
