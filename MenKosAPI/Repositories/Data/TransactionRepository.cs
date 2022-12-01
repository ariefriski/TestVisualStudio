using MenKosAPI.Context;
using MenKosAPI.Models;
using MenKosAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace MenKosAPI.Repositories.Data
{
    public class TransactionRepository
    {
        private MyContext _context;
        public TransactionRepository(MyContext myContext)
        {
            _context = myContext;
        }

        public List<TransactionVM> Get()
        {
            var Payments = _context.Payments.Include(p => p.Order).ThenInclude(order => order.Occupant).ToList();

            List<TransactionVM> transactions = new List<TransactionVM>();
            //Console.WriteLine(transactions[0]);

            

            foreach (var payment in Payments)
            {

                
                TransactionVM transaction = new() {
                    Amount = payment.Amount,
                    PaymentDate = payment.PaymentDate,
                    Id = payment.Id,
                    Order = new(){
                        Id = payment.Order.Id,
                        EntryDate = payment.Order.EntryDate,
                        OutDate = payment.Order.OutDate,
                        Occupant = new(){
                            Id = payment.Order.Occupant.Id,
                            BirthDate = payment.Order.Occupant.BirthDate,
                            City = payment.Order.Occupant.City,
                            Contact = payment.Order.Occupant.Contact,
                            CreatedAt = payment.Order.Occupant.CreatedAt,
                            Gender = payment.Order.Occupant.Gender,
                            Name = payment.Order.Occupant.Name,
                            NIK = payment.Order.Occupant.NIK,
                            Religion = payment.Order.Occupant.Religion,
                            UpdateAt = payment.Order.Occupant.UpdateAt,
                        }

                    },
                    ProofPayment = payment.ProofPayment,
                    Status = payment.Status
                };

                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}
