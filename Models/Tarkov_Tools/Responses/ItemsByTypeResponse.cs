
using System.Collections.Generic;


namespace ETFHelper_WPF.Models.Tarkov_Tools.Responses;

public class ItemsByTypeResponse
{
    #region კონსტრუქტორი

    public ItemsByTypeResponse() {

        ItemsByType = new List<ItemBase>();
    }

    #endregion

    #region თვისებები

    public List<ItemBase> ItemsByType { get; set; }

    #endregion
}
