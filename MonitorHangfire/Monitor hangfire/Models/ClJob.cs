namespace Monitor_hangfire.Models
{
    public class ClJob
    {
        public int id { get; set; } 
        public int statId { get; set; }
        public string stateName { get; set; }
        public DateTime arguments { get; set; } 
        public DateTime createDate { get; set; }
        public DateTime expireDate { get; set; }
        public int updateCount { get; set; }
        public bool jobCorrecto { get; set; }   

    }


   
}
