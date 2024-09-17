

using System.Text.Json.Serialization;

namespace MenKosAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Floor { get; set; }

        public int RoomPriceId { get; set; }

        
        public int? PaymentId { get; set; }
        [JsonIgnore]
        public RoomPrice? roomPrice{ get; set; }
        [JsonIgnore]
        public Payment? payment { get; set; }
        

        public bool Status { get; set; }

        public string Description { get; set; }
    }
}
