using System;
using System.Collections.Generic;
using System.Linq;
using ETFHelper_WPF.Enums;


namespace ETFHelper_WPF.Extensions;

public static class StringExtensions
{
    #region მეთოდები

    public static  string  ToSentence(this string Input)
    {
        // https://stackoverflow.com/questions/272633/add-spaces-before-capital-letters
        return new string(Input.FirstCharToUpper().SelectMany((c, i) => i > 0 && char.IsUpper(c) ? new[] { ' ', c } : new[] { c }).ToArray()).TrimStart(' ');
    }


    public static  string FirstCharToLower(this  string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        return char.ToLower(input[0]) + (input.Length > 1 ? input[1..] : string.Empty);
    }

    public static  string  FirstCharToUpper(this  string  input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        return char.ToUpper(input[0]) + (input.Length > 1 ? input[1..] : string.Empty);
    }


    public static List<ItemTypes> ToItemTypes(this List<string> input)
    {
        var types = new List<ItemTypes>();
        foreach (var item in input)
        {
            if (Enum.TryParse<ItemTypes>(item, ignoreCase: true, out var result))
            {   
                types.Add(result);
            }
        }

        return types;
    }



    #endregion
}
