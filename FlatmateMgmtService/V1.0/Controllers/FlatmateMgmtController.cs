using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlatmateMgmtService.V1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlatmateMgmtService.V1.Entities;
using FlatmateMgmtService.V1.Models;

namespace FlatmateMgmtService.V1._0.Controllers
{
  [ApiVersion("1.0")]
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  public class FlatmateMgmtController : ControllerBase
  {
    private readonly IFlatmateMgmtService _FlatmateMgmtService;

    private readonly ILogger<FlatmateMgmtController> _logger;

    public FlatmateMgmtController(ILogger<FlatmateMgmtController> logger, IFlatmateMgmtService flatmateMgmtService)
    {
      _logger = logger;
      _FlatmateMgmtService = flatmateMgmtService;
    }

    [HttpGet("FlatmateBy/{id}")]
    public async Task<ActionResult<FlatmateDataModel>> GetFlatemateByIdAsync(string id)
    {
      return await _FlatmateMgmtService.GetFlatmateById(id);
    }

    [HttpPost("Flatmate/")]
    public async Task<ActionResult<bool>> GetFlatemateByIdAsync(FlatmateDataModel flatmateRequestEntity)
    {
      return await _FlatmateMgmtService.AddFlatmate(flatmateRequestEntity);
    }
  }
}
