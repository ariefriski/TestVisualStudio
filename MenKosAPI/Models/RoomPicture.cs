using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenKosAPI.Models
{
    public class RoomPicture
    {
        public int Id { get; set; }
<<<<<<< Updated upstream
        public string Name { get; set; }
        public Room RoomId { get; set; }

=======
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string RoomType { get; set; }
>>>>>>> Stashed changes
    }
}
