using MenKosAPI.Models;

namespace MenKosAPI.ViewModel
{
    public class TransactionVM
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public OrderVM? Order { get; set; }
        public bool Status { get; set; }
        public string ProofPayment { get; set; }
    }
}
