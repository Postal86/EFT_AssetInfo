using System.Collections.Generic;


namespace ETFHelper_WPF.Models.Tarkov_Tools;

/// <summary>
/// ItemBase is a smaller version of item. To be used when displaying lists of items.
/// </summary>
public class ItemBase
{
    #region კონსტრუქტორი

    public ItemBase()
    {
        Types = new List<string>();
    }

    #endregion


    #region თვისებები

    public string Id { get; set; }

    public string Name { get; set; }

    public string ShortName { get; set; }

    public string IconLink { get; set; }

    public long BasePrice { get; set; }

    public List<string> Types { get; set; }
         
    #endregion
}
