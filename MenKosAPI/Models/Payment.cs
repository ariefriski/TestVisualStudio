namespace MenKosAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Order OrderId { get; set; }
        public bool Status { get; set; }
        public string ProofPayment { get; set; }
    }
}
