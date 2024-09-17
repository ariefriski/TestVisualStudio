

using System.Text.Json.Serialization;

namespace MenKosAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int OrderId { get; set; }
        [JsonIgnore]
        public Order? order { get; set; }
        public bool Status { get; set; }
        public string ProofPayment { get; set; }
    }
}
