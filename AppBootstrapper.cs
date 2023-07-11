using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using ETFHelper_WPF.Helpers;
using ETFHelper_WPF.Models;
using ETFHelper_WPF.Services;
using ETFHelper_WPF.ViewModels;

namespace ETFHelper_WPF;

 class AppBootstrapper : BootstrapperBase
{
    #region ველები

    private SimpleContainer? _container;
    private UpdateManagerService? _updateManager;
    private SettingsService? _settingsService;

    #endregion


    #region კონსტრუქტორი

    public AppBootstrapper()
    {
       _updateManager = new UpdateManagerService();
       _updateManager.HandleSquirrel();
       _settingsService = new SettingsService();    
       _settingsService.Initialize();
        Initialize();
    }

    #endregion


    #region მეთოდები

    protected override void Configure()
    {
        this._container = new SimpleContainer();
        AddServices();
        AddViewModels();
        _container.Singleton<IWindowManager, WindowManager>();
        _container.Singleton<SettingMenuItem, SettingMenuItem>();
        _container.Singleton<EFTTasksHelper, EFTTasksHelper>();
        _ = _container.GetInstance<EFTTasksHelper>().LoadEFTTasks();
        _container.Instance(Application);
        _container.Instance(_updateManager);
        _container.Instance(_settingsService);

    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        DisplayRootViewForAsync<TaskBarIconViewModel>();
    }


    protected override object GetInstance(Type service, string key)
    {
        return _container.GetInstance(service, key);
    }

    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        return _container.GetAllInstances(service);
    }

    protected override void BuildUp(object instance)
    {
        base.BuildUp(instance);
    }

    private  void AddViewModels()
    {
        _container.Singleton<ShellViewModel, ShellViewModel>();
        _container.Singleton<TaskBarIconViewModel, TaskBarIconViewModel>();
        _container.Singleton<LocationSelectorViewModel, LocationSelectorViewModel>();
        _container.Singleton<LocationViewModel, LocationViewModel>();
        _container.Singleton<VersionViewModel, VersionViewModel>();
        _container.Singleton<ItemsListViewModel, ItemsListViewModel>();
        _container.Singleton<ItemTypeViewModel, ItemTypeViewModel>();
        _container.Singleton<SettingsViewModel, SettingsViewModel>();

    }

    private void AddServices()
    {
        _container.Singleton<ThemeService, ThemeService>();
        _container.Singleton<TarkovToolsService, TarkovToolsService>();
        _container.Singleton<FlyoutService, FlyoutService>();
        _container.PerRequest<DialogService, DialogService>();
    }

    #endregion
}
