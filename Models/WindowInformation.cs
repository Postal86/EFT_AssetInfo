using Caliburn.Micro;
using MahApps.Metro.Controls;
using System.Windows;

namespace ETFHelper_WPF.Models;

public  class WindowInformations
{
    #region კონსტრუქტორი

    public WindowInformations() { 
        
     Position = new WindowPosition();
        Height = 800;
        Width = 1200;
     }

    #endregion


    #region თვისებები

    public double Height { get; set; }

    public double Width  { get; set; }

    public WindowPosition Position { get; set; }

    #endregion

    #region მეთოდები

    public void Copy(IViewAware view)
    {
        if (view.GetView() is not Window window)
        {
            return;
        }

        Height = window.Height;
        Width = window.Width;
        Position.Top = window.Top;
        Position.Left = window.Left;

    }

    #endregion
}
