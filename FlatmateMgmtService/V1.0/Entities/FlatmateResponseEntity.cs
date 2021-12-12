using System;
using System.Globalization;

namespace FlatmateMgmtService.V1.Entities
{
  public class FlatmateDataEntity
  {
    public string Id { get; set; }
    public string Name { get; set; }

    public DateTime DoB { get; set; }

  }

  public class FlatmateRequestEntity
  {
    public string Name { get; set; }

    public DateTime DoB { get; set; }

  }
}