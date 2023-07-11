using System.Collections.Generic;

namespace ETFHelper_WPF.Models.Tarkov_Tools;

public class TransactionInformation
{
    #region კონსტრუქტორი

    public TransactionInformation() { 
      
        Requirements = new List<Requirement>();  
    }

    #endregion

    #region თვისებები


    public long Price { get; set; }

    public string? Source { get; set; }

    public string? Currency { get; set; }

    public List<Requirement> Requirements { get; set; }

    #endregion


}
