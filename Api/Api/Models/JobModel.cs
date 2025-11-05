namespace Api.Models
{
    public class JobModel
    {
 
        public int Id { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public string UpdateCount { get; set; }
        public bool IsRecurrent { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

}
