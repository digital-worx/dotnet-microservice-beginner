using System;
using System.Threading.Tasks;
using ApiGateway.V2.Entities;
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


    public async Task<ActionResult<FlatmateDataEntity>> GetFlatmateById(string id)
    {
      try
      {

        // HttpContent appPostData = new StringContent(JsonConvert.SerializeObject(defaultDataModel), System.Text.Encoding.UTF8, "application/json");
        // string addAdviceServiceUrl = _configuration.GetSection("ServiceEndpoints:AdviceAddNew").Value;
        // string addInstitutionResponse = await HttpClientServiceRepository.PostHttpclient(string.Empty, string.Empty, addAdviceServiceUrl, appPostData);

        // AdviceDataEntity Advice = JsonConvert.DeserializeObject<AdviceDataEntity>(addInstitutionResponse);
        FlatmateDataEntity flatmateDataEntity = new FlatmateDataEntity();
        if (id == "rohit")
        {
          flatmateDataEntity.id = "rb";
          flatmateDataEntity.Name = "rohit";
          flatmateDataEntity.DoB = DateTime.Now;
          return flatmateDataEntity;
        }
        return flatmateDataEntity;
      }
      catch (Exception)
      {
        Log.Debug("exception in service");
        throw;
      }
    }
  }
}