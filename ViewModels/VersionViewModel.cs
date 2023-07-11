using System;
using Caliburn.Micro;
using ETFHelper_WPF.Helpers;
using ETFHelper_WPF.Services;

namespace ETFHelper_WPF.ViewModels;

public class VersionViewModel  : Screen
{
    #region ველები

    private bool _needUpdate;
    private UpdateManagerService _updateManagerService;


    #endregion


    #region კონსტრუქტორი

    public VersionViewModel(UpdateManagerService  updateManagerService)
    {
        _updateManagerService = updateManagerService;
    }


    #endregion


    #region ივენთები

    public event EventHandler OnUpdateRequested;

    #endregion


    #region თვისებები

    public string Version
    {
        get
        {
            var  version = _updateManagerService.GetVersion().ToString(3);
            return $"Version {version}";
        }
    }


    public bool NeedUpdate
    {
        get
        {
            return _needUpdate;
        }

        set
        {
            _needUpdate = value;
            NotifyOfPropertyChange();
            NotifyOfPropertyChange(() => UpToDate);
        }
    }

    public bool UpToDate => !NeedUpdate;


    #endregion

    #region მეთოდები

    public  void UpdateApplication()
    {
        OnUpdateRequested?.Invoke(this, EventArgs.Empty);
    }

    public void OpenReleasePage()
    {
        ProcessHelper.StartProcess(_updateManagerService.ReleaseUrl);

    }

    protected override async void OnViewLoaded(object view)
    {
        NeedUpdate = await  _updateManagerService.CheckForUpdate();
        if (!NeedUpdate)
        {
            _updateManagerService.UpdateAvailable += UpdateManagerService_UpdateAvailable;
            _updateManagerService.Watch();
        }
    }

    private void UpdateManagerService_UpdateAvailable(object  sender, EventArgs e)
    {
        NeedUpdate = true;
    }

    #endregion
}
