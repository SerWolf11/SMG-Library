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
using MahApps.Metro.Controls;
using System.Data;

using LibKo.WAPI;

namespace ADM
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
      
        private List<Object> j = new List<Object>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

      
            //for (int i = 0; i < 11; i++)
            //{
            //    j.Add(new kol() { f = i, lo = "ee " + i, Ko = DateTime.Today });
            //}
            
            //y.ItemsSource = j;
            //y.DataContext = j;

            j = WAPI.Get<List<Object>>("Caja?IDFarmacia=1");
            y.DataSource = j;
            o.ItemsSource = j;
        }

        class kol
        {

            public int f { get; set; }
            public string lo { get; set; }
            private DateTime ko=DateTime.Now;

            public DateTime Ko
            {
                get { return ko=DateTime.Now; }
                set { ko = value; }
            }
            
        }
    }
}
