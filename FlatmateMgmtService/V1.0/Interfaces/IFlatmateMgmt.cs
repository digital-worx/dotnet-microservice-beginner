
using System.Threading.Tasks;
using FlatmateMgmtService.V1.Entities;
using FlatmateMgmtService.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlatmateMgmtService.V1.Interfaces
{
  public interface IFlatmateMgmtService
  {
    Task<ActionResult<FlatmateDataModel>> GetFlatmateById(string id);
    Task<ActionResult<bool>> AddFlatmate(FlatmateDataModel flatmateRequestEntity);
  }
}