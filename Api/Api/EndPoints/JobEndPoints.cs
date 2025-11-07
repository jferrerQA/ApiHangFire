using Api.Data;
using Hangfire.States;
using System.Net.NetworkInformation;

namespace Api.EndPoints
{
    public static class JobEndPoints
    {
        public static void AddJobsEndpoints(this WebApplication app)
        {

            app.MapGet("/jobs", AllJobs);
            app.MapGet("/jobs/qtt", CountAllJobs);
            app.MapGet("/jobs/{id}", JobById);
            app.MapGet("/jobs/state/{state}", JobByState);

            /*app.MapGet("/jobs", (JobData 
                data) =>
            {
                return data.Jobs;
            });      */  
        }

        private static IResult AllJobs(JobData data)
        {
            return Results.Ok(data.Jobs);
        }

        private static IResult CountAllJobs(JobData data)
        {
            var count = data.Jobs.Count();
            return Results.Ok(new {count });
        }

        private static IResult JobById(JobData data, int id)
        {
            return Results.Ok(data.Jobs.SingleOrDefault(x=> x.Id == id));
        }



        private static IResult JobByState(JobData data, string state)
        {
            var count= data.Jobs.Count(x => x.State == state);
            return Results.Ok(new { state, count });
        }
    }
}
