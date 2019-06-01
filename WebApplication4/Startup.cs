﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using WeddingGo.Models;
using WeddingGo.Models.Repositery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WeddingGo

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
			services.AddDbContext<WeddingContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Weddingcon")));

			services.AddMvc();

			services.AddScoped<IClientRepositery<MakeupArtist>, MakeupArtistRepositery>();
            services.AddScoped<IClientRepositery<Photographer>, PhotographerRespositery>();

            services.AddScoped<IClientRepositery<Atelier>, AtelierRespositery>();

            services.AddScoped<IClientRepositery<WeddingHall>, WeddingHallRespositery>();

            services.AddScoped<IClientRepositery<User>, UserRepository>();

			services.AddScoped<IRepository<Package>, PackageRepositery>();

			services.AddScoped<IRepository<Offer>, OfferRepository>();



			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration
                    .GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

            app.UseAuthentication();
            app.UseMvc();
        }
	}
}
