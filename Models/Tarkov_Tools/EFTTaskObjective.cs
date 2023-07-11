using System.Collections.Generic;


namespace ETFHelper_WPF.Models.Tarkov_Tools;

public class EFTTaskObjective
{
    #region კონსტრუქტორი

    public EFTTaskObjective() {

        Target = new List<string>();
    }
    

    #endregion

    #region თვისებები

    public string? Id { get; set; }

    public string? Type { get; set; }

    public List<string>? Target { get; set; }

    public ItemBase? TargetItem { get; set; }

    public int Number { get; set; }

    public string? Location { get; set; }

    #endregion
}
