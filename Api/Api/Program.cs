using Api.Data;
using Api.EndPoints;
using Api.StartUp;
using Api.Workers;
using Hangfire;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependences();
var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.UseHangfireDashboard("/hangfire");


app.MapGet("/", context =>
{
    context.Response.Redirect("/jobs");
    return Task.CompletedTask;
});



using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.EnsureCreated(); 
}
app.UseOpenApi();

app.UseHttpsRedirection();
app.UseHangfireDashboard("/hangfire");



app.AddJobsEndpoints();

using (var scope = app.Services.CreateScope())
{
    var jobData = scope.ServiceProvider.GetRequiredService<JobData>();
    var worker = scope.ServiceProvider.GetRequiredService<JobWorker>();

    foreach (var job in jobData.Jobs)
    {
        // Crea un job real en Hangfire basado en tus datos del JSON
        if (job.IsRecurrent)
        {
            RecurringJob.AddOrUpdate(job.Name, () => worker.EjecutarJobsRecurrentes(job), job.cron);
        }
        else
        {
            BackgroundJob.Enqueue(() => worker.EjecutarJobsNoRecurrentes(job));
        }
        
        
    }
}

app.Run();

/*
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/
