using System;
using System.Threading.Tasks;
using FlatmateMgmtService.V1.Data;
using FlatmateMgmtService.V1.Entities;
using FlatmateMgmtService.V1.Interfaces;
using FlatmateMgmtService.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlatmateMgmtService.V1.Services
{
  public class FlatmateMgmtBackendService : IFlatmateMgmtService
  {
    private readonly DataContext _context = null;

    public FlatmateMgmtBackendService(IOptions<DBSettings> settings)
    {
      _context = new DataContext(settings);
    }

    public async Task<ActionResult<FlatmateDataModel>> GetFlatmateById(string id)
    {
      try
      {
        return await _context.FlatmateDataModel.Find(dm => dm.Id == id).FirstOrDefaultAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }
    public async Task<ActionResult<bool>> AddFlatmate(FlatmateDataModel flatmateDataModel)
    {
      await _context.FlatmateDataModel.InsertOneAsync(flatmateDataModel);
      return true;
    }
  }
}