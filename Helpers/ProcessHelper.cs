using System.Diagnostics;

namespace ETFHelper_WPF.Helpers;

public static class ProcessHelper
{
    #region მეთოდები

    public static  void StartProcess(string processName)
    {
        var processStartInfo = new ProcessStartInfo
        {
           UseShellExecute = true,
           FileName = processName,
        };

        Process.Start(processStartInfo);
    }

    #endregion
}
