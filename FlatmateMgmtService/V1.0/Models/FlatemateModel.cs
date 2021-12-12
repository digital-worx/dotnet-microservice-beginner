using System;
using System.Globalization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlatmateMgmtService.V1.Models
{
  public class FlatmateDataModel
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    public DateTime DoB { get; set; }

  }
}