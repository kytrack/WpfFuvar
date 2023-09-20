using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfFuvar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         List<Fuvar> fuvarok = new List<Fuvar>();
        public MainWindow()
        {
            InitializeComponent();
            //balra: Danko Daniel, jobbra: Gyorfi Marcell

            StreamReader sr = new StreamReader("fuvar.csv");
            sr.ReadLine();
           // MessageBox.Show(sr.ReadLine());
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                fuvarok.Add(new Fuvar(int.Parse(adatok[0]), adatok[1], int.Parse(adatok[2]), double.Parse(adatok[3]), double.Parse(adatok[4]), double.Parse(adatok[5]), adatok[6]));
            }
            sr.Close();

            cbAzonositok.ItemsSource = fuvarok.GroupBy(x => x.Taxiazonosito).Select(x => x.Key);

            lbFizetesimodok.ItemsSource = fuvarok.GroupBy(x => x.Fizetesmod).Select(x => x.Key);


            lbLeghosszabbfuvar.Items.Add( fuvarok.Where(x => x.Indotartam == fuvarok.Max(x => x.Indotartam)).Select(x => x.Indotartam));
            lbLeghosszabbfuvar.Items.Add(  fuvarok.Where(x => x.Indotartam == fuvarok.Max(x => x.Indotartam)).Select(x => x.Taxiazonosito));
            lbLeghosszabbfuvar.Items.Add(fuvarok.Where(x => x.Indotartam == fuvarok.Max(x => x.Indotartam)).Select(x => x.Megtetttavolsag));
            lbLeghosszabbfuvar.Items.Add(fuvarok.Where(x => x.Indotartam == fuvarok.Max(x => x.Indotartam)).Select(x => x.Viteldij));


            StreamWriter sw = new StreamWriter("hibak.txt", append: true);
            sw.Close();

        }

        private void btnFuvarszam_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show(fuvarok.Count().ToString()+" fuvar");
        }

        private void btnTaxisInfo_Click(object sender, RoutedEventArgs e)
        {
            int kivalasztottTaxis =Convert.ToInt32(cbAzonositok.SelectedItem);
            double osszeg = 0;
            var viteldij = fuvarok.Where(x => x.Taxiazonosito == kivalasztottTaxis).Select(x => x.Viteldij).ToList();
            foreach (var item in viteldij)
            {
                osszeg += item;
            }
            var borravalo = fuvarok.Where(x => x.Taxiazonosito == kivalasztottTaxis).Select(x => x.Borravalo).ToList();
            foreach (var item in borravalo)
            {
                osszeg += item;
            }
            MessageBox.Show($"bevétele:{osszeg} fuvarok száma:{fuvarok.Where(x => x.Taxiazonosito == kivalasztottTaxis).Count()}");
        }

        private void btnOsszKM_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Math.Round((fuvarok.Sum(x => x.Megtetttavolsag)*1.6),2).ToString());
        }
    }
}




