using System.Text.Json.Serialization;

namespace MenKosAPI.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Problem { get; set; }
        public string? Reply { get; set; }
        public bool Status { get; set; }

        public int RoomId { get; set; }

        [JsonIgnore]
        public Room? Room { get; set; }
    }
}
