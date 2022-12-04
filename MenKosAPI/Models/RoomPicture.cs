

using System.Text.Json.Serialization;

namespace MenKosAPI.Models
{
    public class RoomPicture
    {
        public int Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RoomId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Room? room { get; set; }
    }
}
