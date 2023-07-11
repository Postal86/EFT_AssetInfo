using System.Collections.Generic;


namespace ETFHelper_WPF.Models.Tarkov_Tools.Responses;

public class QuestResponse
{
    #region კონსტრუქტორი

    public  QuestResponse()
    {
        Quests = new List<EFTTaskBase>();
    }


    #endregion

    #region თვისებები

    public List<EFTTaskBase> Quests { get; set; }

    #endregion
}
