using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Extensions;
using ETFHelper_WPF.Helpers;
using ETFHelper_WPF.Models.Tarkov_Tools;

namespace ETFHelper_WPF.ViewModels;

public  class ItemBaseViewModel : Screen
{
    #region ველები

    private System.Action<ItemBaseViewModel>? _action;

    #endregion


    #region კონსტრუქტორი

    public ItemBaseViewModel(ItemBase item, System.Action<ItemBaseViewModel> action)
    {
        Id = item.Id;
        Name = item.Name;
        ShortName = item.ShortName;
        IconLink = item.IconLink;
        BasePrice = $"{item.BasePrice.ToString("N0")} {CurrencyHelper.GetCurrencySymbol("RUB")}";
        Types = item.Types.ToItemTypes();
        _action = action;
    }


    #endregion


    #region თვისებები

    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public string? IconLink { get; set; }
    public string? BasePrice { get; set; }
    public List<ItemTypes>? Types { get; set; }
    public string? TypesValue => string.Join(", ", Types.Select(x => x.ToString().ToSentence()));

    #endregion

    #region მეთოდები

    public void OnItemClicked()
    {
        _action?.Invoke(this);
    }

    #endregion
}
