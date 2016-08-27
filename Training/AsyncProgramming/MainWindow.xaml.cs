using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace AsyncProgramming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void buttonGet_Click(object sender, RoutedEventArgs e)
        {
            textBoxHtml.Clear();

            var client = new HttpClient();

            var task = client.GetStringAsync(textBoxUrl.Text);

            textBoxHtml.Text = await task;
        }

        private void buttonGet_Click1(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            var task = client.GetStringAsync(textBoxUrl.Text);

            while (!task.IsCompleted)
            {
                textBoxHtml.Text = task.Result;
            }
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxHtml.Text)) textBoxHtml.Text = "Please wait...";

            var collection = await CalculateAsyc(0, 2 * Math.PI, 10000000, Math.Sin);

            textBoxHtml.AppendText(collection.Last().ToString());
        }

        private Task<IEnumerable<double>> CalculateAsyc(double xMin, double xMax, int count, Func<double, double> function)
        {
            var task = Task.Run<IEnumerable<double>>(() =>
            {
                var collection = Enumerable.Range(1, count)
                .Select(x => xMin * (1 - (x - 1)/(count - 1)) + xMax * (x - 1)/(count - 1)) // TODO: need check
                .Select(x => function(x));
                return collection.ToArray();
            });

            return task;
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxHtml.Text)) textBoxHtml.Text = "Please wait...";

            var collection = await CalculateAsyc(0, 2 * Math.PI, 10000000, 
                x => Math.Sqrt(Math.Abs(Math.Sin(x) + Math.Cos(x))));

            textBoxHtml.AppendText(collection.Last().ToString());
        }
    }
}
