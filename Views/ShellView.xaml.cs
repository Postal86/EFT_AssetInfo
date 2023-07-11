using System;
using System.Runtime.InteropServices;
using MahApps.Metro.Controls;

namespace ETFHelper_WPF.Views;

/// <summary>
/// Interaction logic for SettingsView.xaml
/// </summary>
public partial class ShellView : MetroWindow
{
    public ShellView()
    {
        InitializeComponent();
    }

    /// <summary>
    /// ფანჯრის  ატრიბუტები
    /// </summary>
    public enum DWMWINDOWATTRIBUTE
    {
        /// <summary>
        ///  ფანჯრის პარამეტრები
        /// </summary>

        DWMWA_WINDOW_CORNER_PREFERENCE = 33,
    }


    /// <summary>
    /// 
    /// </summary>
    public enum DWM_WINDOW_CORNER_PREFERENCE
    {
        /// <summary>
        /// სისტემამ გადაწყვიტოს მოამრგვალოს თუ არა ფანჯრის კუთხეები
        /// </summary>
        DWMWCP_DEFAULT = 0,

        /// <summary>
        /// არასოდეს  მოამრგვალოს ფანჯრის  კუთხეები
        /// </summary>
        DWMWCP_DONOTROUND = 1,

        /// <summary>
        /// მოამრგვალოს იმ შემთხევაში თუ მისაღებია
        /// </summary>
        DWMWCP_ROUND = 2,

        /// <summary>
        /// მოამრგვალოს იმ შემთხევაში თუ მისაღებია, მცირე რადიუსით.
        /// </summary>
        DWMWCP_ROUNDSMALL = 3,
    }

    // 
    [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern long DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);

}