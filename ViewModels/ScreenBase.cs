using Caliburn.Micro;
using ETFHelper_WPF.Models;

namespace ETFHelper_WPF.ViewModels;

public abstract class ScreenBase : PropertyChangedBase
{
    public abstract HamburgerMenuInformation GetHamburgerMenuInformation();

    public abstract void MenuSelectionChanged(IMenuItem item);
}
