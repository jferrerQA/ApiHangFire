using Api.Models;
using Hangfire;
using System.ComponentModel;

namespace Api.Workers
{
    public class JobWorker
    {
        [DisplayName("Ejecucción Job Recurrente")]
        [AutomaticRetry(Attempts = 3)]
        public void EjecutarJobsRecurrentes(JobModel job)
        {
            Console.WriteLine($"Ejecutando Job {job.Id}: {job.Name}");

            if (job.State == "failed")
            {
                throw new Exception($"Failed test {job.Name}");
            }
        }

        [DisplayName("Ejecucción Job")]
        [AutomaticRetry(Attempts = 3)]
        public void EjecutarJobsNoRecurrentes(JobModel job)
        {
            Console.WriteLine($"Ejecutado recurrente job {job.Id} : {job.Name}");

            if (job.State == "failed")
            {
                throw new Exception($"Failed test {job.Name}");
            }
        }

    }
}
