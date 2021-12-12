
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.V2.Interfaces
{
  public interface IFlatmateMgmtService
  {
    Task<ActionResult<string>> GetFlatemateById(string id);
  }
}