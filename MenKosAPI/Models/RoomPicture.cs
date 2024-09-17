﻿using Newtonsoft.Json;

namespace MenKosAPI.Models
{
    public class RoomPicture
    {
        public int Id { get; set; }
        
        public int RoomId { get; set; }

        [JsonIgnore]
        public Room? room { get; set; }
    }
}
