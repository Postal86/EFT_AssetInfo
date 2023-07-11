using ETFHelper_WPF.Enums;


namespace ETFHelper_WPF.Models;

public class Settings
{
    #region კონსტრუქტორი

    public Settings()
    {
        WindowInformation = new WindowInformations();
        Theme = Theme.Dark;
        Scheme = Scheme.Amber;
        TopMost = true;
        Opacity = 100;
    }

    #endregion

    #region თვისებები

    public WindowInformations WindowInformation { get; set; }

    public Theme Theme { get; set; }

    public Scheme Scheme { get; set; }

    public bool TopMost { get; set; }

    public int  Opacity { get; set; }

    #endregion
}
