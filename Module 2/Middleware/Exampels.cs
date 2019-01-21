using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    internal class Exampels
    {
        internal void Use(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                //Do some work here
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                //Pass the request on down to the next pipeline (Which is the MVC middleware)
                return next();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            app.Use((context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                return next();
            });
        }

        internal void UseOrder(IApplicationBuilder app)
        {
            //The order of these things are important. 
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("[1] ----- \n");//1
                await next.Invoke();
                await context.Response.WriteAsync("[5] =====\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("[2] Hello world with order\n");//2
                await next.Invoke();
                await context.Response.WriteAsync("[4]  \n");//4
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("[3] ----- \n");//3
            });
        }

        internal void Run(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                //Do some work here
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                //Pass the request on down to the next pipeline (Which is the MVC middleware)
                return next();
            });

            app.Use((context, next) =>
            {
                context.Response.WriteAsync("Hello World with Run!");
                return next();
            });

            app.Run(async (context) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
            });
        }

        internal void Map(IApplicationBuilder app)
        {
           	app.Map("/helloworld", mapApp =>
            {
                mapApp.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("Hello World with Map!");
                });
            });
        }

        internal void MapWhen(IApplicationBuilder app)
        {
           	app.MapWhen(context => context.Request.Query.ContainsKey("helloworld"), mapApp =>
            {
                mapApp.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello World with MapWhen!");
                });
            });
        }

        internal void MapWhenOptions(IApplicationBuilder app, MapWhenOptions options)
        {
            app.UseMiddleware<MapWhenMiddleware>(options);
        }
    }
}