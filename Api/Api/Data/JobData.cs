using Api.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Data
{
    public class JobData
    {
        public List<JobModel> Jobs { get; private set; }

        public JobData()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "JobData.json");

            string json = File.ReadAllText(filePath);

            Jobs = JsonSerializer.Deserialize<List<JobModel>>(json, options) ?? new();
        }
    }
}
