using FlatmateMgmtService.V1.Entities;
using FlatmateMgmtService.V1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlatmateMgmtService.V1.Data
{
  public class DataContext
  {
    private readonly IMongoDatabase _database = null;

    public DataContext(IOptions<DBSettings> settings)
    {
      var client = new MongoClient(settings.Value.ConnectionString);

      if (client != null)
        _database = client.GetDatabase(settings.Value.Database);
    }

    public IMongoCollection<FlatmateDataModel> FlatmateDataModel
    {
      get
      {
        return _database.GetCollection<FlatmateDataModel>("Flatmate");
      }
    }
  }
}
