using CommunityToolkit.Mvvm.ComponentModel;
using ExploreCity.Models;
using System.Collections.ObjectModel;

namespace ExploreCity.ViewModels
{
    public partial class ListViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<PinModel> _locations;

        public ListViewModel()
        {
            _locations = new ObservableCollection<PinModel>();
        }


    }
}
