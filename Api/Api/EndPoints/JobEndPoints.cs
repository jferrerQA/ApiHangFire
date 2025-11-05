using Api.Data;
using System.Net.NetworkInformation;

namespace Api.EndPoints
{
    public static class JobEndPoints
    {
        public static void AddJobsEndpoints(this WebApplication app)
        {
            app.MapGet("/jobs", (JobData data) =>
            {
                return data.Jobs;
            });        
        }

   
    }
}
