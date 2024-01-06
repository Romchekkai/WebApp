namespace WebApp.Models.Db.Entities
{
    
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Url { get; set; }
    }
}
