using Microsoft.AspNetCore.Mvc;
using MenKosAPI.Base;
using MenKosAPI.Models;
using MenKosAPI.Repositories.Data;
using Microsoft.AspNetCore.Http;

namespace MenKosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController<PaymentRepository, Payment>
    {
        private readonly PaymentRepository paymentRepository;
        public PaymentController(PaymentRepository paymentRepository) : base(paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }
    }
}
