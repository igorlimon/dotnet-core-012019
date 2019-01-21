using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Text.Encodings.Web;

namespace ErrorHandling
{
    internal class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = EnvironmentName.Development;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //app.UseStatusCodePagesWithRedirects("/error/{0}");

            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/plain";

                await context.HttpContext.Response.WriteAsync(
                    "Status code page, status code: " +
                    context.HttpContext.Response.StatusCode);
            });

            app.MapWhen(context => context.Request.Path == "/missingpage", builder => {});

            app.Map("/error", error =>
            {
                error.Run(async context =>
                {
                    await context.Response.WriteAsync("An error occurred!");
                });
            });

            app.MapWhen(context => context.Request.Path.ToString().Contains("helloerror"), mapApp =>
            {
                mapApp.Run(context =>
                {
                    throw new Exception();
                });
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}