using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETFHelper_WPF.Models.Tarkov_Tools;
using ETFHelper_WPF.Services;

namespace ETFHelper_WPF.Helpers;

public class EFTTasksHelper
{
    #region ველები 

    private readonly  TarkovToolsService? _tarkovToolsService;
    private List<EFTTaskBase>? _EFTTasks;

    #endregion

    #region მეთოდები

    public EFTTasksHelper(TarkovToolsService  tarkovToolsService)
    {
        _tarkovToolsService = tarkovToolsService;
    }

    public  async Task  LoadEFTTasks()
    {
        var response = await _tarkovToolsService.GetEFTTasks();
        _EFTTasks = response?.Quests;
    }

    public  async Task<EFTTaskBase>  GetTask(string  taskId)
    {
        if (_EFTTasks is null  ||  !_EFTTasks.Any())
        {
            await LoadEFTTasks();
        }

        return _EFTTasks.FirstOrDefault(x => x.Id.Equals(taskId, StringComparison.InvariantCultureIgnoreCase));

    }


    #endregion



}
