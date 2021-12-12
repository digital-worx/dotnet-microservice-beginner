using System;
using System.Threading.Tasks;
using ApiGateway.V2.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace ApiGateway.V2.Services
{
  public class FlatmateMgmtService : IFlatmateMgmtService
  {
    //private readonly IConfiguration _configuration;
    //private readonly IHttpContextAccessor _httpContextAccessor;
    // public FlatmateMgmtService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    // {
    //   _configuration = configuration;
    //   _httpContextAccessor = httpContextAccessor;
    // }

    public FlatmateMgmtService()
    {
    }


    public async Task<ActionResult<string>> GetFlatemateById(string id)
    {
      try
      {

        // HttpContent appPostData = new StringContent(JsonConvert.SerializeObject(defaultDataModel), System.Text.Encoding.UTF8, "application/json");
        // string addAdviceServiceUrl = _configuration.GetSection("ServiceEndpoints:AdviceAddNew").Value;
        // string addInstitutionResponse = await HttpClientServiceRepository.PostHttpclient(string.Empty, string.Empty, addAdviceServiceUrl, appPostData);

        // AdviceDataEntity Advice = JsonConvert.DeserializeObject<AdviceDataEntity>(addInstitutionResponse);
        string name = "rohit";
        return name;

      }
      catch (Exception)
      {
        Log.Debug("exception in service");
        throw;
      }
    }
  }
}