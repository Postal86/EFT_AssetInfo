using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;
using Squirrel;

namespace ETFHelper_WPF.Services;

public class UpdateManagerService
{
    #region  ველები

    private static readonly string GithubUrl = "https://github.com/Postal86";
    private Timer? _timer;

    #endregion

    #region ივენთები

    public event EventHandler? UpdateAvailable;

    #endregion


    #region თვისებები

    public  string ReleaseUrl => $"{GithubUrl}/releases/tag/v{GetVersion().ToString(3)}";

    #endregion

    #region მეთოდები

    /// <summary>
    /// Updates this instance.
    /// </summary>
    /// <returns>The task awaiter.</returns>
    public async  Task Update()
    {
        using var updateManager = await CreateUpdateManagerAsync();
        await updateManager.UpdateApp();
        UpdateManager.RestartApp();
    }


    /// <summary>
    /// Updates this instance.
    /// </summary>
    /// <returns>True if needs update.</returns>
    public  async Task<bool>  CheckForUpdate()
    {
#if DEBUG
        return false;
#endif

#pragma warning disable CS0162
        try
        {
            using var updateManager = await CreateUpdateManagerAsync();
            var information = await updateManager.CheckForUpdate();
            return information.ReleasesToApply.Any();
        }
        catch
        {
            return false;
        }

#pragma warning restore CS0162
    }

    /// <summary>
    /// Get the AssemblyVersion of this instance.
    /// </summary>
    /// <returns></returns>
    public Version GetVersion() => Assembly.GetExecutingAssembly().GetName().Version;

    public void HandleSquirrel()
    {
        SquirrelAwareApp.HandleEvents(onInitialInstall: OnInstall, onAppUninstall: OnUninstall);
    }



    public void Watch()
    {
        if (_timer != null)
        {
            DisposeTime();
        }

        _timer = new Timer(TimeSpan.FromMinutes(5).TotalMilliseconds);
        _timer.Elapsed += Timer_Elapsed;
        _timer.Start();
    }

    private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        var needUpdate = await CheckForUpdate();
        if (needUpdate)
        {
            UpdateAvailable?.Invoke(this, EventArgs.Empty);
            DisposeTime();
        }
    }

    private void DisposeTime()
    {
        _timer.Stop();
        _timer.Elapsed -= Timer_Elapsed;
        _timer.Dispose();
        _timer = null; 
    }

    //private  void OnInstall(System.Version version)
    //{
    //    using var updateManager = new Squirrel.UpdateManager(GithubUrl, "EFTHelper");
    //    updateManager.CreateUninstallerRegistryEntry();
    //    updateManager.CreateShortcutForThisExe(ShortcutLocation.StartMenu | ShortcutLocation.Desktop);
    //}

    //private void OnUninstall(System.Version version)
    //{
    //    using var updateManager = new Squirrel.UpdateManager(GithubUrl, "EFTHelper");
    //    updateManager.RemoveUninstallerRegistryEntry();
    //    updateManager.RemoveShortcutForThisExe(ShortcutLocation.StartMenu | ShortcutLocation.Desktop);
    //}


    private void OnUninstall(SemanticVersion version, IAppTools tools)
    {
        using var updateManager = new Squirrel.UpdateManager(GithubUrl, "EFTHelper");
        updateManager.RemoveUninstallerRegistryEntry();
        updateManager.RemoveShortcutForThisExe(ShortcutLocation.StartMenu | ShortcutLocation.Desktop);
    }

    private void OnInstall(SemanticVersion version, IAppTools tools)
    {
        using var updateManager = new Squirrel.UpdateManager(GithubUrl, "EFTHelper");
        updateManager.CreateUninstallerRegistryEntry();
        updateManager.CreateShortcutForThisExe(ShortcutLocation.StartMenu | ShortcutLocation.Desktop);
    }

    [Obsolete]
    private Task<UpdateManager> CreateUpdateManagerAsync() => UpdateManager.GitHubUpdateManager(GithubUrl);

    #endregion
}
