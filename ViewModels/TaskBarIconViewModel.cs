﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using ETFHelper_WPF.Models;
using ETFHelper_WPF.Services;
using Gma.System.MouseKeyHook;

namespace ETFHelper_WPF.ViewModels
{
    public  class TaskBarIconViewModel : Conductor<ScreenBase>.Collection.OneActive
    {
        #region ველები 

        private ShellViewModel? _shellViewModel;
        private LocationSelectorViewModel? _locationSelectorViewModel;
        private VersionViewModel? _versionViewModel;
        private IWindowManager? _windowManager;
        private ProcessService? _processService;
        private IKeyboardMouseEvents? _globalHook;
        private UpdateManagerService? _updateManagerService;
        private ItemsListViewModel? _itemsListViewModel;
        private System.Windows.Forms.Keys[] _hotKeys = { System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F3 };

        #endregion


        #region კონსტრუქტორი 


        public TaskBarIconViewModel(
            ShellViewModel shellViewModel,
            LocationSelectorViewModel locationSelectorViewModel,
            IWindowManager windowManager,
            UpdateManagerService updateManagerService,
            VersionViewModel  versionViewModel, 
            ItemsListViewModel itemsListViewModel, 
            ThemeService themeService)
        {
            _shellViewModel = shellViewModel;
            _locationSelectorViewModel = locationSelectorViewModel;
            _versionViewModel = versionViewModel;
            _windowManager = windowManager;
            _updateManagerService = updateManagerService;
            _itemsListViewModel = itemsListViewModel;
            DisplayName = "EFT_Helper";
            themeService.Apply();
            ChangeActiveItemAsync(_locationSelectorViewModel, true, CancellationToken.None);
            _processService = new ProcessService("EscapeFromTarkov");
            _processService.ProcessClosed += Service_ProcessClosed;
            _ = WaitForTarkov();
        }


        #endregion


        #region თვისებები

        public DoubleClickCommand ShowActiveScreen => new DoubleClickCommand(ShowActiveItem);

        public string Version
        {
            get
            {
                var version = _updateManagerService.GetVersion().ToString();
                return $"{version}";
            }
        }


        #endregion


        #region მეთოდები

        public async void Close()
        {
            if (ActiveItem != null)
            {
                await _shellViewModel.TryCloseAsync();
            }

            await TryCloseAsync(); 
        }

        public async  void ShowActiveItem()
        {
            await ShowItem(ActiveItem);
        }


        public async void ShowLocationsView()
        {
            await ShowItem(_locationSelectorViewModel);
        }


        public async void ShowItemsView()
        {
            await ShowItem(_itemsListViewModel);
        }

        private async Task ShowItem(ScreenBase item)
        {
            ActiveItem = item ?? _locationSelectorViewModel;

            if (_shellViewModel.IsActive && _shellViewModel.Content == ActiveItem)
            {
                await _shellViewModel.TryCloseAsync();
            }
            else
            {
                _shellViewModel.SetContent(ActiveItem);

                if (!_shellViewModel.IsActive)
                {
                    await _windowManager.ShowWindowAsync(_shellViewModel);
                }
            }
        }

        private void ShowItem(System.Windows.Forms.Keys key)
        {
            switch(key)
            {
                case System.Windows.Forms.Keys.F2:
                    ShowLocationsView(); break;
                 case System.Windows.Forms.Keys.F3: 
                    ShowItemsView(); break;
            }
        }

        private void HandleKeyboard(System.Windows.Forms.Keys key)
        {
            if (_hotKeys.Contains(key))
            {
                ShowItem(key);
            }
        }

        private async Task WaitForTarkov()
        {
            var processId = await _processService.WaitForProcess();
            _globalHook = Hook.GlobalEvents();
            _globalHook.KeyDown += _globalHook_KeyDown;
        }

        private  void  _globalHook_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            HandleKeyboard(e.KeyCode);
        }

        private void Service_ProcessClosed(object  sender, System.EventArgs e)
        {
            _globalHook.KeyDown -= _globalHook_KeyDown;
            _globalHook?.Dispose();
            _ = WaitForTarkov();    
        }



        #endregion
    }
}
