using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenKosAPI.Models
{
    public class RoomPrice
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string RoomType { get; set; }
  
    }
}
