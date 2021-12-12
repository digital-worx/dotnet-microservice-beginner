using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlatmateMgmtService.V1.Interfaces;
using FlatmateMgmtService.V1.Models;
using FlatmateMgmtService.V1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FlatmateMgmtService
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddSingleton<IFlatmateMgmtService, FlatmateMgmtBackendService>();
      services.AddControllers();
      services.AddApiVersioning(
      options =>
      {
        // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(2, 0);
      });
      services.AddVersionedApiExplorer(
        options =>
        {
          // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
          // note: the specified format code will format the version as "'v'major[.minor][-status]"
          options.GroupNameFormat = "'v'VVV";

          // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
          // can also be used to control the format of the API version in route templates
          options.SubstituteApiVersionInUrl = true;
        });
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlatmateMgmtService", Version = "v1" });
      });
      services.Configure<DBSettings>(options =>
      {
        options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
        options.Database = Configuration.GetSection("MongoConnection:Database").Value;
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlatmateMgmtService v1"));
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
