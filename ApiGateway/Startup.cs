using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.V2.Interfaces;
using ApiGateway.V2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ApiGateway
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
      services.AddSingleton<HttpClient, HttpClient>();
      services.AddSingleton<IFlatmateMgmtService, FlatmateMgmtService>();
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
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiGateway", Version = "v1" });
        c.SwaggerDoc("v2", new OpenApiInfo { Title = "ApiGateway", Version = "v2" });
      });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(
          options =>
          {
            // build a swagger endpoint for each discovered API version 
            foreach (var description in provider.ApiVersionDescriptions)
            {
              options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", "ApiGateway " + description.GroupName.ToUpperInvariant());
            }
          }
        );
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
