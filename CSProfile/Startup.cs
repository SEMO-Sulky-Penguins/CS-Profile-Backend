using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

using CSProfile.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CSProfile
{
    public class Startup
    {
		/*
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
		*/
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			//this is for the authentication
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = "https://localhost:44305",
					ValidAudience = "https://localhost:44305",
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
				};
			});

            //this is for the local DB
            services.AddDbContext<ProfileContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("profileContext")));
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAllHeaders", builder =>
				{
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
				});
			});

			services.AddCors(options =>
			{
				options.AddPolicy("EnableCORS", builder =>
				{
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
				});
			});

            //old code for previous pseudo db
			//services.AddDbContext<Models.ProfileContext>(opt =>
			//opt.UseInMemoryDatabase("ProfileList"));
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseHsts();
			}

			app.UseAuthentication();
			app.UseCors("AllowAllHeaders");
			app.UseCors("EnableCORS");
			app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
