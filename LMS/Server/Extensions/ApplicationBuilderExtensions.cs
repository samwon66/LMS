﻿using LMS.Server.Data;

namespace LMS.Server.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();

                try
                {
                    await SeedData.InitAsync(context, services);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return app;
        }
    }
}
