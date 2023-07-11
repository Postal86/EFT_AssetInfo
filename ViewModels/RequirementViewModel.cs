using System;
using Caliburn.Micro;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Extensions;
using ETFHelper_WPF.Helpers;
using ETFHelper_WPF.Models.Tarkov_Tools;


namespace ETFHelper_WPF.ViewModels;

public class RequirementViewModel
{
    #region  კონსტრუქტორი

    public RequirementViewModel(Requirement requirement)
    {
        Type = requirement.Type; 
        Value = requirement.Value;
        DisplayValue = BuildDisplayValue();
    }

    #endregion


    #region თვისებები

    public string Type { get; set; }

    public int Value { get; set; }

    public string DisplayValue { get; set; }

    #endregion


    #region მეთოდები

    private string BuildDisplayValue()
    {
        var isRequirementType = Enum.TryParse<RequirementTypes>(Type, true, out var type);
        if (isRequirementType && type == RequirementTypes.QuestCompleted)
        {
            var eftTask = IoC.Get<EFTTasksHelper>().GetTask(Value.ToString()).Result;
            if (eftTask != null)
            {
                return $"- Task completed: \"{eftTask.Title}\"";
            }
        }

        return $"- {Type.ToSentence()} {Value}";
    }


    #endregion
}
