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


        private ObservableCollection<Region> regions;
        public ObservableCollection<Region> Regions {
            get { return regions; }
            set {
                regions = value;
                NotifyPropertyChanged();
            }
        }

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

        private RelayCommand addRegionCommand;
        public RelayCommand AddRegionCommand
        {
            get
            {
                return addRegionCommand ??
                    (addRegionCommand = new RelayCommand(obj =>
                    {
                        //TODO:Задать вопрос перед добавлением
                        Region region = new Region() { RegionDescription=""};
                        region.RegionID = regionRepository.Create(region);
                        Regions.Insert(0, region);
                        SelectedRegion = region;
                    }));
            }
        }

        private RelayCommand removeRegionCommand;
        public RelayCommand RemoveRegionCommand
        {
            get
            {
                return removeRegionCommand ??
                    (removeRegionCommand = new RelayCommand(obj =>
                    {
                        //TODO:Задать вопрос перед удалением
                        Region region = obj as Region;
                        if (region != null)
                        {
                            int rows = regionRepository.Delete(region.RegionID);
                            if (rows>0 ) Regions.Remove(region);
                        }
                    },
                    (obj) => Regions.Count > 0));
            }
        }


        private RelayCommand selectAllCommand;
        public RelayCommand SelectAllCommand
        {
            get
            {
                return selectAllCommand ??
                    (selectAllCommand = new RelayCommand(obj =>
                    {
                        //TODO: DRY?
                        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";
                        regionRepository = new RegionRepository(connString);
                        //TODO: Правильно ли выкинуть прошлый запросы. Может быть чистить коллекцию и закидывать новые данные?
                        Regions = new ObservableCollection<Region>(regionRepository.GetAll());
                        //Или сделать так?
                        /* 
                        Regions.Clear();
                        var items = regionRepository.GetAll();
                        foreach (var item in items)
                        {
                            Regions.Add(item);
                        }*/
                    }));
            }
        }
    }
}
