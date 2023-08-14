namespace EngineExpert.Data.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdateAt { get; set; }

        public DateTime CretedByUserId { get; set; }

        public DateTime LastUpdatedByUserId { get; set; }
    }
}