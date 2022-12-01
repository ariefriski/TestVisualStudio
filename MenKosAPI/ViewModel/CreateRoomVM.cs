using System.Text.Json.Serialization;

namespace MenKosAPI.ViewModel
{
    public class CreateRoomVM
    {
        public int Floor { get; set; }

        public int RoomPriceId { get; set; }

        [JsonIgnore]
        public int? PaymentId { get; set; }
        public bool Status { get; set; }

        public string Description { get; set; }

    }
}
