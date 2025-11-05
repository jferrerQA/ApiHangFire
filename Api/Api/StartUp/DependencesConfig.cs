using Api.Data;

namespace Api.StartUp
{
    public static class DependencesConfig
    {
        public static void AddDependences(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenApiServices();

            /*var connectionString = builder.Configuration.GetConnectionString("DbConnection");

            builder.Services.addHangfire(ConfigurationBinder =>
            {
                config.Use
            });*/

            builder.Services.AddTransient<JobData>();

        }
    }
}
