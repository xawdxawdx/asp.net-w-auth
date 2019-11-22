﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanilaWebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using DanilaWebApp.Models;

namespace DanilaWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => { options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=authdblul;Trusted_Connection=True;"); });
            services.AddMvc();
            services.Configure<PasswordHasherOptions>(option =>
            {
                option.IterationCount = 11000;
            });
            //АЙДЕНТИТА
            services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<DataContext>();
            //АЙДЕНТИТА
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/User/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Register}/{id?}");
            });
            
            app.UseStaticFiles();
        }
    }
}