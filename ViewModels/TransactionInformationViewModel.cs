using System;
using System.Collections.Generic;
using System.Linq;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Extensions;
using ETFHelper_WPF.Helpers;
using ETFHelper_WPF.Models.Tarkov_Tools;

namespace ETFHelper_WPF.ViewModels;

public class TransactionInformationViewModel 
{
    #region კონსტრუქტორი

    public TransactionInformationViewModel(TransactionInformation  transactionInformation)
    {
        Price = transactionInformation.Price;
        Source = transactionInformation.Source;
        Currency = CurrencyHelper.GetCurrencySymbol(transactionInformation.Currency);
        Requirements = transactionInformation.Requirements.Select(x => new RequirementViewModel(x)).ToList();
        if (Source.Equals("fleamarket", StringComparison.InvariantCultureIgnoreCase))
        {
            TraderImageSource = "pack://application:,,,/Images/incognito.png";
        }
        else {
            TraderImageSource = $"https://tarkov-tools.com/images/{Source}-icon.jpg";
        }

        TraderName = Source.ToSentence();   
    }


    #endregion

    #region თვისებები

    public long Price { get; set; }

    public string? DisplayPrice => Price.ToString("N0");

    public string? Source { get; set; }

    public string? TraderName { get; set; } 


    public string? TraderImageSource { get; set; }

    public string? Currency { get; set; }


    public List<RequirementViewModel>? Requirements { get; set; }

    public bool HasRequirements => Requirements != null && Requirements.Any();

    public string? JoinedRequirements => HasRequirements ? string.Join(',', Requirements.Select(x => $"{x.Type} {x.Value}".ToSentence())) : string.Empty;

    public Currencies CurrencyType { get; set; }

    #endregion



    #region მეთოდები

    public long GetPriceInRoubles() => CurrencyHelper.GetPriceInRoubles(CurrencyType, Price);

    #endregion
}
