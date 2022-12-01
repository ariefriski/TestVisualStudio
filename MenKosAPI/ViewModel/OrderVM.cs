using MenKosAPI.Models;

namespace MenKosAPI.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime OutDate { get; set; }

        //[JsonIgnore]
        public Occupant? Occupant { get; set; }
    }
}
