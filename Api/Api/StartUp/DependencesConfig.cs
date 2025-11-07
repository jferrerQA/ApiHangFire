using Api.Data;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace Api.StartUp
{
    public static class DependencesConfig
    {
        public static void AddDependences(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenApiServices();

            var connectionString = builder.Configuration.GetConnectionString("DbConnection");


            /*builder.Services.AddHangfire(config=>
            {
                config.UsePostgreSqlStorage(connectionString);
            });*/

            builder.Services.AddControllers();
            builder.Services.AddHangfireServer();

            builder.Services.AddTransient<JobData>();

        }
    }
}
