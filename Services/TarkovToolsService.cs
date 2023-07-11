using System;
using System.Threading.Tasks;
using ETFHelper_WPF.Enums;
using ETFHelper_WPF.Extensions;
using ETFHelper_WPF.Models.Tarkov_Tools;
using ETFHelper_WPF.Models.Tarkov_Tools.Requests;
using ETFHelper_WPF.Models.Tarkov_Tools.Responses;
using ETFHelper_WPF.Models.TarkovTools.Responses;

namespace ETFHelper_WPF.Services;

public class TarkovToolsService : HttpServiceBase
{
    #region ველები 

    private const string apiUrl = "https://api.tarkov.dev/";
    private const string apiEndpoint = "graphql";

    #endregion

    #region კონსტრუქტორი

    public TarkovToolsService() { 
    
      HttpClient.BaseAddress = new Uri(apiUrl); 
    }


    #endregion



    #region მეთოდები

    public Task<ItemsByNameResponse<TItem>?> GetItemsByNameAsync<TItem>(string name)
      where TItem : ItemBase,  new()
    {
        var request = new GraphQLRequests(TarkovToolsRequestTypes.ItemsByName, new TItem(), name);

        return ExecutePostRequestAsync(request, new ItemsByNameResponse<TItem>());
    }

    public Task<ItemsByTypeResponse?> GetItemsByTypeAsync(ItemTypes  itemType)
    {
        var request = new GraphQLRequests(TarkovToolsRequestTypes.ItemsByType, new ItemBaseRequest(), itemType.ToString().FirstCharToLower());

        return ExecutePostRequestAsync(request, new ItemsByTypeResponse());
    }

    public Task<ItemsByTypeResponse?>  GetAllItemAsync()
    {
        return GetItemsByTypeAsync(ItemTypes.Any);
    }

    public Task<ItemByIdResponse?> GetItemByIdAsync(string id)
    {
        var request = new GraphQLRequests(TarkovToolsRequestTypes.Item, new ItemRequest(), id);

        return ExecutePostRequestAsync(request, new ItemByIdResponse());
        
    }




    public Task<QuestResponse?> GetEFTTasks()
    {
        var request = new GraphQLRequests(TarkovToolsRequestTypes.Quests, new QuestsRequest(), string.Empty);

        return ExecutePostRequestAsync(request, new QuestResponse());
    }


    private async Task<TResponse?> ExecutePostRequestAsync<TResponse>(GraphQLRequests request, TResponse defaultValue)
    {
        var response = await ExecutePostRequestAsync<GraphQLRequests, TarkovToolsResponse>(apiEndpoint, request);

        return TryDeserialize(response?.Data?.ToString(), defaultValue);
    }

    #endregion
}
