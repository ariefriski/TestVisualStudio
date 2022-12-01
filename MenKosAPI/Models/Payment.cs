using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenKosAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int OrderId { get; set; }    
        public Order order { get; set; }
        public bool Status { get; set; }
        public string ProofPayment { get; set; }
    }
}
