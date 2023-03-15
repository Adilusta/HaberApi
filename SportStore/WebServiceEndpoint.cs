using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.Json;
using SportStore.Models;

namespace SportStore
{
    public static class WebServiceEndpoint
    {
        private static string BASEURL = "api/haberler";

        public static void MapWebService(this IEndpointRouteBuilder app)
        {

            app.MapGet($"{BASEURL}/{{id}}", async context =>
            {
                int key = int.Parse(context.Request.RouteValues["id"] as string);
                HaberDbContext data = context.RequestServices.GetService<HaberDbContext>();
                Haber p = data.Haberler.Find(key);
                if (p == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    context.Response.ContentType = "application/json";
                    await context.Response
                        .WriteAsync(JsonSerializer.Serialize(p));
                }
            });

            app.MapGet(BASEURL, async context =>
            {
                HaberDbContext data = context.RequestServices.GetService<HaberDbContext>();
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer
                    .Serialize<IEnumerable<Haber>>(data.Haberler));
            });

            app.MapPost(BASEURL, async context =>
            {
                HaberDbContext data = context.RequestServices.GetService<HaberDbContext>();
                Haber p = await
                    JsonSerializer.DeserializeAsync<Haber>(context.Request.Body);
                await data.AddAsync(p);
                await data.SaveChangesAsync();
                context.Response.StatusCode = StatusCodes.Status200OK;
            });
        }
    }
}
