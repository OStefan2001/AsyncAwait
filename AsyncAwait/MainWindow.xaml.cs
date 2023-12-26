using AsyncAwait;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource ts;
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void CriptareAsync(object sender, RoutedEventArgs e)
        {
            string Ftext = "C:\\Users\\User\\Desktop\\Stefan\\PPC#\\AsyncAwait\\AsyncAwait\\TextInitial.txt";
            ts = new CancellationTokenSource();
            int i = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string[] fileContent = await CitireFisier.FRead(Ftext,ts.Token);
            foreach (string linie in fileContent)
            {
                
                
                if (ts.Token.IsCancellationRequested)
                {
                    // Operația a fost anulată, ieșim din buclă
                    break;
                }
                string liniecriptata = await CriptareDecriptare.CriptareAsync1(linie);
                TextCriptat.Text += liniecriptata + Environment.NewLine;
                i++;
                MessageBox.Text += "Linia "+ i +" a fost criptata" + Environment.NewLine;
            }
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            TimpExecutie.Text = elapsedTime.TotalSeconds +" secunde";


        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            ts.Cancel();
            MessageBox.Text = "Criptarea a fost intrerupta.";
        }

        private async void DecriptareAsync(object sender, RoutedEventArgs e)
        {
            string[] liniiCriptate = TextCriptat.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string linieCriptata in liniiCriptate)
            {
                string linieDecriptata = await CriptareDecriptare.DecriptareAsync1(linieCriptata);
                TextDecriptat.Text += linieDecriptata + Environment.NewLine;

            }

        }

        
    }
}
