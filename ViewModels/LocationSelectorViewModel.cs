using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using ETFHelper_WPF.Converters;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Helpers;
using ETFHelper_WPF.Models;
using ETFHelper_WPF.Services;

namespace ETFHelper_WPF.ViewModels;

public class LocationSelectorViewModel : ScreenBase
{
    #region ველები 

    private SettingsService? _settingsService;
    private LocationViewModel? _selectedLocation;

    #endregion

    #region კონსტრუქტორი

    public LocationSelectorViewModel(
        SettingsService  settingsService,
        SettingsViewModel settingsViewModel)
    {
       SettingsViewModel = settingsViewModel;
        _settingsService = settingsService;
        LocationViewModels = EnumHelper.GetEnumValues<Locations>().Select(x => new LocationViewModel(x)).OrderBy(x => x.Name).ToList();
        SelectedLocation = LocationViewModels.FirstOrDefault();
        LocationName = new ObservableCollection<string>(LocationViewModels.Select(x => x.Name));
    }

    #endregion


    #region თვისებები

    public string SelectedLocationName => SelectedLocation.Name;


     public LocationViewModel? SelectedLocation
    {
        get => _selectedLocation;
        set
        {
            if (_selectedLocation != value)
            {
                _selectedLocation = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => SelectedLocationName);
            }
        }
    }

    public List<LocationViewModel> LocationViewModels { get; set; }

    public ObservableCollection<string> LocationName { get; set; }

    public SettingsViewModel SettingsViewModel { get; set; }

    #endregion

    #region მეთოდები

    public override HamburgerMenuInformation GetHamburgerMenuInformation()
    {
        return new HamburgerMenuInformation
        {
            Items = LocationViewModels.Cast<IMenuItem>(),
            Header = "Locations",
            SelectedItem = SelectedLocation,
        };
    }

    public override void MenuSelectionChanged(IMenuItem item)
    {
         var location = item as LocationViewModel; 
        if (location != null)
        {
            SelectedLocation = location;
        }
    }



    #endregion
}
