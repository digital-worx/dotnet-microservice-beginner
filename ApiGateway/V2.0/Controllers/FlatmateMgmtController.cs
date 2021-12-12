using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using System.Threading.Tasks;
using ApiGateway.V2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiGateway.V2.Entities;

namespace ApiGateway.V2._0.Controllers
{
  [ApiVersion("2.0")]
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

    [HttpGet("FlatmateById/")]
    public async Task<ActionResult<FlatmateDataEntity>> GetFlatemateByIdAsync(string id)
    {
      return await _FlatmateMgmtService.GetFlatmateById(id);
    }
  }
}
