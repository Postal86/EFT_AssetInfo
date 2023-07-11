using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace ETFHelper_WPF.Services;

public class DialogService
{
    #region ველები

    private  static readonly IDialogCoordinator Coordinator = DialogCoordinator.Instance;

    private object? _context;

    #endregion

    #region მეთოდები

    public async Task ShowProgressAsync(string?  title, string? message,  Task  task)
    {
        var controller = await Coordinator.ShowProgressAsync(_context, title, message);

        await task;

        await controller.CloseAsync();
    }


    public void Register(object  context)
    {
        _context = context;
    }

    #endregion
}
