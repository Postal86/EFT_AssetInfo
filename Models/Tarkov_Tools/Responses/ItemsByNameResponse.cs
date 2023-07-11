using System.Collections.Generic;


namespace ETFHelper_WPF.Models.Tarkov_Tools.Responses;

public class ItemsByNameResponse<TItem> where TItem : ItemBase
{
    #region კონსტრუქტორი

    public ItemsByNameResponse()
    {

        ItemsByName = new List<TItem>();
    }

    #endregion


    #region თვისებები

    public List<TItem> ItemsByName { get; set; }

    #endregion
}
