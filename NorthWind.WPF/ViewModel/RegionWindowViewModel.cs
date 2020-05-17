using Northwind.DB;
using Northwind.DB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WPF.ViewModel
{
    public class RegionWindowViewModel : INotifyPropertyChanged
    {
        private Region selectedRegion;
        private RegionRepository regionRepository;

        public ObservableCollection<Region> Regions { get; set; }

        public Region SelectedRegion
        {
            get { return selectedRegion; }
            set
            {
                selectedRegion = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegionWindowViewModel()
        {
            //TODO: вынести в файл настроек и чтение из Класса Northwind.BL
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";
            regionRepository = new RegionRepository(connString);
            Regions = new ObservableCollection<Region>(regionRepository.GetAll());
        }
    }
}
