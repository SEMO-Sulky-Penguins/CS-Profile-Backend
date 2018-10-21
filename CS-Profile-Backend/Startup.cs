﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;
using CS_Profile_Backend.Models;
using Microsoft.AspNetCore.Cors;

namespace CS_Profile_Backend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //CORS error No 'Access-Control-Allow-Origin' header
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
            services.AddDbContext<ProfileContext>(opt =>
                opt.UseInMemoryDatabase("ProfileList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        /*public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }*/
        //removed for now
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Shows UseCors with named policy.
            //CORS error No 'Access-Control-Allow-Origin' header
            app.UseCors("AllowAllHeaders");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
