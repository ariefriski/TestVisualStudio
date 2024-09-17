﻿

using System.Text.Json.Serialization;

namespace MenKosAPI.Models
{
    public class RoomFacility
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RoomId { get; set; }
        [JsonIgnore]
        public Room? room { get; set; }
        public string Description { get; set; }

    }
}
