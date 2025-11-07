using Api.Data;
using Api.Workers;
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
            var connApiDb= builder.Configuration.GetConnectionString("DbConnApi");

            builder.Services.AddDbContext<DataContext>(options=> options.UseNpgsql(connApiDb));


            var hangfireDb = builder.Configuration.GetConnectionString("DbConnHangfire");
            builder.Services.AddHangfire(config=>
            {
                config.UsePostgreSqlStorage(hangfireDb);
            });

            builder.Services.AddControllers();
            builder.Services.AddHangfireServer();

            builder.Services.AddSingleton<JobData>();
            builder.Services.AddTransient<JobWorker>();

        }
    }
}
