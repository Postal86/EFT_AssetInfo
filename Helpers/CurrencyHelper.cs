using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Accessibility;
using Caliburn.Micro;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Models.Tarkov_Tools;
using ETFHelper_WPF.Services;

namespace ETFHelper_WPF.Helpers;

public static  class CurrencyHelper
{
    #region კონსტანტები

    private static Dictionary<Currencies, long> _currencyValues = new Dictionary<Currencies, long>();
    private const string Roubles = "RUB";
    private const string RoubleSymbol = "₽";
    private const string USDollars = "USD";
    private const string USDollarSymbol = "$";
    private const string Euro = "EUR";
    private const string EuroSymbol = "€";

    #endregion

    #region მეთოდები

    public static string  GetCurrencySymbol(string currency)
    {
        if (string.IsNullOrEmpty(currency) || currency.Equals(Roubles, StringComparison.InvariantCultureIgnoreCase))
        {
            return RoubleSymbol;
        }

        if (currency.Equals(USDollars, StringComparison.InvariantCultureIgnoreCase))
        {
            return USDollarSymbol;
        }

        if (currency.Equals(Euro, StringComparison.InvariantCultureIgnoreCase))
        {
            return EuroSymbol;
        }

        return string.Empty;
    }


    public static  string GetCurrencySymbol(Currencies  currency)
    {
        var currencyValue = string.Empty;

        switch (currency)
        {
            case Currencies.Rouble:
                currencyValue = Roubles;
                break;
            case Currencies.Euro: 
                currencyValue = Euro; 
                break;
            case Currencies.USDollar:
                currencyValue = USDollars;
                break;
        }

        return GetCurrencySymbol(currencyValue);
    }


    public async static Task<long>  GetValueInRoublesAsync(Currencies  currency)
    {
        if (currency == Currencies.Rouble)
        {
            return 1;
        }

        var service = IoC.Get<TarkovToolsService>();
        var shortName = GetCurrencyShortName(currency);
        var items = await service.GetItemsByNameAsync<Item>(shortName);

        if (items is null || !items.ItemsByName.Any())
        {
            return 1;
        }

        var item = items.ItemsByName.FirstOrDefault(x => x.ShortName.Equals(shortName, StringComparison.InvariantCultureIgnoreCase));
        var result = default(long);
        if (item != null)
        {
            result = item.BuyFor?.FirstOrDefault()?.Price ?? item.BasePrice;
        }

        SaveValueInRoubles(currency, result);

        return result;
    }

    public static  long GetPriceInRoubles(Currencies currency, long price)
    {
        if (_currencyValues.TryGetValue(currency, out var value))
        {
            return value * price; 
        }

        return price;
    }

    public static  Currencies GetCurrencyByShortName(string shortName)
    {
        if (string.IsNullOrEmpty(shortName) || shortName.Equals(Roubles, StringComparison.InvariantCultureIgnoreCase))
        {
            return Currencies.Rouble;

        }

        if (shortName.Equals(USDollars, StringComparison.InvariantCultureIgnoreCase))
        {
            return Currencies.USDollar;
        }

        if (shortName.Equals(Euro, StringComparison.InvariantCultureIgnoreCase))
        {
            return Currencies.Euro;
        }

        return Currencies.Rouble;

    }



    private static string GetCurrencyShortName(Currencies currency)
    {
        switch (currency)
        {
            case Currencies.Rouble:
                return Roubles;
            case Currencies.Euro:
                return Euro;
            case Currencies.USDollar:
                return USDollars;
        }

        return string.Empty;
    }

    private static void SaveValueInRoubles(Currencies currency, long value)
    {
        _currencyValues[currency] = value;
    }


     #endregion
}
