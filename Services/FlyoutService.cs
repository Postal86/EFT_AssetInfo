using System;
using Caliburn.Micro;
using ETFHelper_WPF.Models;
using MahApps.Metro.Controls;

namespace ETFHelper_WPF.Services;

public class FlyoutService
{
    #region ივენთები

    public event EventHandler<FlyoutRequest>? ShowFlyoutRequested;
    public event EventHandler? CloseFlyoutRequested;
    public event EventHandler? FlyoutClosed;

    #endregion

    #region __

    public Position CurrentPosition { get; set; }

    #endregion

    #region მეთოდები

    public void Show(string? header, PropertyChangedBase  content, Position position)
    {
        CurrentPosition = position;
        var request = new FlyoutRequest
        {
            Header = header,
            Content = content,
            Position = position
        };
        ShowFlyoutRequested?.Invoke(this, request); 
    }

    public void  Close()
    {
        CloseFlyoutRequested?.Invoke(this, EventArgs.Empty);
    }

    public void NotifyFlyoutClosed()
    {
        FlyoutClosed?.Invoke(this, EventArgs.Empty);    
    }

    #endregion
}
