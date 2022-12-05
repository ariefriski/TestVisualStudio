using MenKosAPI.Context;
using MenKosAPI.Handler;
using MenKosAPI.Models;
using MenKosAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace MenKosAPI.Repositories.Data
{
    public class TransactionRepository
    {
        private MyContext _context;
        private OccupantRepository _occupantRepository;
        private UserRepository _userRepository;
        private OrderRepository _orderRepository;
        private PaymentRepository _paymentRepository;
        private RoomRepository _roomRepository;
        public TransactionRepository(MyContext myContext, OccupantRepository occupantRepository, UserRepository userRepository, OrderRepository orderRepository, PaymentRepository paymentRepository, RoomRepository roomRepository)
        {
            _context = myContext;
            _occupantRepository = occupantRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _roomRepository = roomRepository;
        }

        public List<PaymentOrderOccupantVM> Get()
        {
            var Payments = _context.Payments.Include(p => p.Order).ThenInclude(order => order.Occupant).ToList();

            

            List<PaymentOrderOccupantVM> transactions = new List<PaymentOrderOccupantVM>();
            //Console.WriteLine(transactions[0]);

            foreach (var payment in Payments)
            {
                PaymentOrderOccupantVM transaction = new() {
                    Amount = payment.Amount,
                    PaymentDate = payment.PaymentDate,
                    PaymentId = payment.Id,
                    Order = new(){
                        Id = payment.Order.Id,
                        EntryDate = payment.Order.EntryDate,
                        OutDate = payment.Order.OutDate,
                        OccupantId = null,
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

        public int CreateNewTransaction(NewTransactionVM newTransaction)
        {
            Occupant occupant = new()
            {
                NIK = newTransaction.NIK,
                Name = newTransaction.Name,
                BirthDate = newTransaction.BirthDate,
                City = newTransaction.City,
                Contact = newTransaction.Contact,
                Gender = newTransaction.Gender,
                Religion = newTransaction.Religion,
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            _occupantRepository.Create(occupant);

            var newOccupantId = _context.Occupants.FirstOrDefault(o => o.NIK == newTransaction.NIK && o.Name == newTransaction.Name).Id;

            User user = new()
            {
                Email = newTransaction.Email,
                Password = Hashing.HashPassword(newTransaction.Password),
                OccupantId = newOccupantId,
                RoleId = 3
            };

            _userRepository.Create(user);



            Order order = new()
            {
                OccupantId = newOccupantId,
                EntryDate = newTransaction.EntryDate,
                OutDate = newTransaction.OutDate,
            };

            _orderRepository.Create(order);

            var newOrderId = _context.Orders.FirstOrDefault(o => o.OccupantId == newOccupantId && o.EntryDate == newTransaction.EntryDate).Id;

            Payment payment = new()
            {
                Amount = newTransaction.Amount,
                PaymentDate = newTransaction.EntryDate,
                ProofPayment = "coba.jpg",
                Status = true,
                OrderId = newOrderId
            };

            _paymentRepository.Create(payment);

            var newPaymentId = _context.Payments.SingleOrDefault(p => p.OrderId == newOrderId).Id;

            var room = _context.Rooms.SingleOrDefault(r => r.Id == newTransaction.RoomId);

            room.Status = true;
            room.PaymentId = newPaymentId;

            var result = _roomRepository.Update(room);

            if(result > 0)
            {
                return 1; // return Ok
            }

            return 2; // return BadRequest





        }

        public IEnumerable<RoomPaymentOrderOccupantVM> GetBill()
        {

            var listRoom = _context.Rooms.Include(r => r.Payment).ThenInclude(p => p.Order).ThenInclude(o => o.Occupant).Include(r => r.RoomPrice).AsEnumerable().Where(r =>
            {
                try
                {
                    var currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    int? intervalDayofOutToCurrent = (r.Payment.Order.OutDate - currentDate).Days;
                    return (intervalDayofOutToCurrent <= 0 && intervalDayofOutToCurrent >= -7) && r.Status == true;   //tampil data jika outdate h-7 sampai hari h
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

            });


            List<RoomPaymentOrderOccupantVM> roomPaymentOrderOccupantVMs = new List<RoomPaymentOrderOccupantVM>();

            foreach(var room in listRoom)
            {
                RoomPaymentOrderOccupantVM roomPaymentOrderOccupant = new()
                {
                    RoomId = room.Id,
                    Description = room.Description,
                    Floor = room.Floor,
                    Status = room.Status,
                    RoomPrice = room.RoomPrice,
                    Payment = new(){
                        Id = room.Payment.Id,
                        Amount = room.Payment.Amount,
                        PaymentDate = room.Payment.PaymentDate,
                        ProofPayment = room.Payment.ProofPayment,
                        Status = room.Payment.Status,
                        OrderId = null,
                        Order = new(){
                            Id = room.Payment.Order.Id,
                            EntryDate = room.Payment.Order.EntryDate,
                            OutDate = room.Payment.Order.OutDate,
                            OccupantId = null,
                            Occupant = new(){
                                Id = room.Payment.Order.Occupant.Id,
                                Name = room.Payment.Order.Occupant.Name,
                                NIK = room.Payment.Order.Occupant.NIK,
                                BirthDate = room.Payment.Order.Occupant.BirthDate,
                                City = room.Payment.Order.Occupant.City,
                                Contact = room.Payment.Order.Occupant.Contact,
                                Gender = room.Payment.Order.Occupant.Gender,
                                Religion = room.Payment.Order.Occupant.Religion,
                                CreatedAt = room.Payment.Order.Occupant.CreatedAt,
                                UpdateAt = room.Payment.Order.Occupant.UpdateAt 
                            }
                        }
                    }
                };

                roomPaymentOrderOccupantVMs.Add(roomPaymentOrderOccupant);
            }



            return roomPaymentOrderOccupantVMs;

            //return listRoom;
        }

    }

   
}
