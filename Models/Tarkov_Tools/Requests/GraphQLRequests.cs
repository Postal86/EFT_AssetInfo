using System.Text.Json.Serialization;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Extensions;
using ETFHelper_WPF.Helpers;

namespace ETFHelper_WPF.Models.Tarkov_Tools.Requests;

public class GraphQLRequests
{
    #region  კონსტრუქტორი

    public GraphQLRequests(TarkovToolsRequestTypes requestType, object  expectedResponse, string  filterValue) {

        Query = BuildQuery(requestType, expectedResponse, filterValue);
    }
  
    #endregion


    #region თვისებები


    [JsonPropertyName("query")]
    public  string Query { get; }

    #endregion


    private string BuildQuery(TarkovToolsRequestTypes requestType, object request, string filterValue)
    {
        var query = "{ ";
        var filterName = requestType.AssociatedFilterName();


        query += $"{requestType.ToString().FirstCharToLower()} ";

        if (!string.IsNullOrEmpty(filterName))
        {
            var filter = requestType == TarkovToolsRequestTypes.ItemsByType ? filterValue : $"\"{filterValue}\"";
            query += $"({filterName}: {filter})";
        }

        query += GraphQLHelper.SerializeToGraphQL(request);
        query += "}";

        return query;
    }
}
