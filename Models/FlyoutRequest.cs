using Caliburn.Micro;
using MahApps.Metro.Controls;

namespace ETFHelper_WPF.Models;

public class FlyoutRequest
{
    #region თვისებები

    public string? Header { get; set; }

    public Position? Position { get; set; }

    public PropertyChangedBase? Content { get; set; }

    #endregion

}
