using MenKosAPI.Context;
using MenKosAPI.Models;

namespace MenKosAPI.Repositories.Data
{
    public class PaymentRepository : GeneralRepositories<Payment>
    {
        private MyContext _context;
        public PaymentRepository(MyContext myContext) : base(myContext)
        {
            _context = myContext;
        }

        public int UpdateStatusPayment(int paymentId)
        {
            var payment = this.Get(paymentId);
            payment.Status = true;
            int result = this.Update(payment);

            if (result > 0)
            {
                return 1; // update berhasil
            }

            return 2; // update gagal


        }
    }
}
