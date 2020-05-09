using Northwind.DB;
using Northwind.DB.Model;
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

namespace NorthWind.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Region> RegionList { get; set; }
        private RegionRepository regionRepository;

        public MainWindow()
        {
            
            InitializeComponent();
            //TODO: вынести в файл настроек и чтение из Класса Northwind.BL
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";
            regionRepository = new RegionRepository(connString);
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            RegionList = new List<Region>() {
                new Region()
                {
                    RegionID = 1,
                    RegionDescription = "123"
                },
                new Region()
                {
                    RegionID = 2,
                    RegionDescription = "123"

                }
            };

            RegionList = regionRepository.GetAll().ToList();

            listView_Region.ItemsSource = RegionList;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
