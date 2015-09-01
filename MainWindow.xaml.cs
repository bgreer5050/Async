using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Net.Http;
using System.Net;
using System.IO;

namespace WPFTaskRun
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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button Pressed");

            btnSubmit.IsEnabled = false;

            //We use the static Task.Run method to run an action asyncronously.
            var task = Task.Run(() =>
            {
                Debug.WriteLine("Starting Async Task Part 1");

                Debug.WriteLine(Task.CurrentId.ToString());
                Thread.Sleep(3000);
                Debug.WriteLine("Part 1 Almost Finished");


            });

            Debug.WriteLine("Random"); // Since the above is async, this will run before the above is complete.
            

            //Above Task.Run returns a task. We call ContinueWith to run another async method once the
            //above is done.
            task.ContinueWith((t) =>
            {
                Debug.WriteLine("Continuatrion Started");
                Dispatcher.Invoke(() =>
                {
                    btnSubmit.IsEnabled = true;

                });
                Debug.WriteLine("Continuation Done");

            });
        }
    }
}
