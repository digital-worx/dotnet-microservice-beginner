using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.V2.Entities;
using ApiGateway.V2.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ApiGateway.V2.Services
{
  public class FlatmateMgmtService : IFlatmateMgmtService
  {
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    //private readonly IHttpContextAccessor _httpContextAccessor;
    // public FlatmateMgmtService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    // {
    //   _configuration = configuration;
    //   _httpContextAccessor = httpContextAccessor;
    // }

    public FlatmateMgmtService(IConfiguration configuration, HttpClient httpClient)
    {
      _configuration = configuration;
      _httpClient = httpClient;
    }


    public async Task<ActionResult<FlatmateDataEntity>> GetFlatmateById(string id)
    {
      try
      {
        //HttpContent appPostData = new StringContent(JsonConvert.SerializeObject(defaultDataModel), System.Text.Encoding.UTF8, "application/json");
        string addAdviceServiceUrl = string.Format("{0}/{1}", _configuration.GetSection("ServiceEndpoints:FmGetFlatmateById").Value, id);
        FlatmateDataEntity addInstitutionResponse = await _httpClient.GetFromJsonAsync<FlatmateDataEntity>(addAdviceServiceUrl);
        //FlatmateDataEntity flatmateDataEntity = JsonConvert.DeserializeObject<FlatmateDataEntity>(addInstitutionResponse);
        return addInstitutionResponse;
      }
      catch (Exception)
      {
        Log.Debug("exception in service");
        throw;
      }
    }
  }
}