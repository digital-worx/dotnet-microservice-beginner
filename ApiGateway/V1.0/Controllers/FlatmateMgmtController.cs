using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using System.Threading.Tasks;
using ApiGateway.V2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiGateway.V1._0.Controllers
{
  [ApiVersion("2.0")]
  [ApiController]
  [Route("[controller]")]
  public class FlatmateMgmtController : ControllerBase
  {
    private readonly IFlatmateMgmtService _FlatmateMgmtService;

    private readonly ILogger<FlatmateMgmtController> _logger;

    public FlatmateMgmtController(ILogger<FlatmateMgmtController> logger, IFlatmateMgmtService flatmateMgmtService)
    {
      _logger = logger;
      _FlatmateMgmtService = flatmateMgmtService;
    }

    [HttpGet]
    public async Task<ActionResult<string>> GetFlatemateByIdAsync()
    {
      return await _FlatmateMgmtService.GetFlatemateById("hell");
    }
  }
}
