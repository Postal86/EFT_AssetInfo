using System;

namespace ETFHelper_WPF.Models;

public interface IMenuItem
{
    #region თვისებები

    public string? Label { get;  }

    public string? Title { get;  }

    public object? Icon { get; }

    public Action? OnClick { get; }

    #endregion
}
