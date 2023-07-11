using Lurker.AppData;
using System;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Models;


namespace ETFHelper_WPF.Services;

public class SettingsService : AppDataFileBase<Settings>
{
    #region კონსტანტები

    public const int OPACITY_MIN = 20;
    public const int OPACITY_MAX = 100;

    #endregion

    #region ივენთები

    public event EventHandler? OnSaved;

    #endregion

    #region თვისებები

    public WindowInformations WindowInformations
    {
        get => Entity.WindowInformation;
        set
        {
            Entity.WindowInformation = value;
        }
    }

    public Theme Theme
    {
        get => (Theme)Entity.Scheme;
        set
        {
            Entity.Theme = value;
        }
    }

    public Scheme Scheme
    {
        get => Entity.Scheme;
        set
        {
            Entity.Scheme = value;  
        }
    }

    public bool  TopMost
    {
        get => Entity.TopMost;
        set
        {
            Entity.TopMost = value;
        }
    }

    public int Opacity
    {
        get => Entity.Opacity;
        set
        {
            Entity.Opacity = value; 
        }
    }

    protected override string FileName => "Settings.json";

    protected  override string FolderName => "EFTHelper";

    #endregion

    #region მეთოდები 

    public new void Save()
    {
        base.Save();
        OnSaved?.Invoke(this, EventArgs.Empty);
    }

    #endregion 

}
