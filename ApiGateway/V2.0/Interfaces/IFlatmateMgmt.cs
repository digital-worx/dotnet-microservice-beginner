
using System.Threading.Tasks;
using ApiGateway.V2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.V2.Interfaces
{
  public interface IFlatmateMgmtService
  {
    Task<ActionResult<FlatmateDataEntity>> GetFlatmateById(string id);
  }
}