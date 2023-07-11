using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ETFHelper_WPF.Models.Tarkov_Tools;

/// <summary>
/// To be used when querying a product by id.
/// </summary>
public class Item : ItemBase
    {
    #region  კონსტრუქტორი

    public Item()
    {
        BuyFor = new List<TransactionInformation>();
        SellFor = new List<TransactionInformation>();
    }

    #endregion

    #region თვისებები 

    public string? GridImageLink { get; set; }

    public string? ImageLink { get; set; }

    public string? WikiLink { get; set; }

    public string? Link { get; set; }


    public string? NormalizedName { get; set; }

    public List<TransactionInformation> BuyFor { get; set; }

    public List<TransactionInformation> SellFor { get; set; }

    public int AccuracyModifier { get; set; } = 0;

    public int RecoilModifier { get; set; } = 0;

    public int ErgonomicsModifier { get; set; } = 0;

    public bool HasGrid { get; set; } = false;

    public bool BlocksHeadphones { get; set; } = false;

    #endregion

}

