using Candidates.Core;
using Candidates.Core.Contracts;
using Candidates.Dal;
using Candidates.Dal.contracts;
using Candidates.Data;
using Candidates.Data.contracts;
using Candidates.Entities;
using Candidates.Helpers;
using Candidates.Helpers.filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates.API
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
            services.AddControllers();
            services.AddScoped<IDataContext,CSVContext>();
            services.AddScoped<ICandidateCore, CandidateCore>();
            services.AddScoped<ICandidateDal, CandidateDal>();
            services.AddAutoMapper(typeof(CandidateProfile));
            services.AddScoped<CandidatesDataReader>();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CandidatesDataReader candidatesDataReader)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            candidatesDataReader.LoadCandidates();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
