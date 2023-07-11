using System.Collections.Generic;

namespace ETFHelper_WPF.Models.Tarkov_Tools;

    public class EFTaskRequirement
    {
    #region კონსტრუქტორი

    public EFTaskRequirement()
    {
        Quests = new List<int>();
        PrerequisiteQuests  = new List<EFTTaskBase>();
    }


    #endregion


    #region თვისებები 

    public int Level { get; set; }

    public List<int>? Quests { get; set; }

    public List<EFTTaskBase>? PrerequisiteQuests { get; set; }

    #endregion

}

