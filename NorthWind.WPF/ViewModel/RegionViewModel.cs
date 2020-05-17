using Northwind.DB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WPF.ViewModel
{
    public class RegionViewModel : INotifyPropertyChanged
    {
        private Region region;

        public RegionViewModel(Region region)
        {
            this.region = region;
        }

        private int regionID;

        public int RegionID
        {
            get { return regionID; }
            set { 
                regionID = value;
                NotifyPropertyChanged();
            }
        }

        private string regionDescription;

        public string RegionDescription
        {
            get { return regionDescription; }
            set { 
                regionDescription = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
