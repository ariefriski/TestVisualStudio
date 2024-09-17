using MenKosAPI.Base;
using MenKosAPI.Models;
using MenKosAPI.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenKosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController<PaymentRepository, Payment>
    {
        private PaymentRepository paymentRepository;
        public PaymentController(PaymentRepository paymentRepository) : base(paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }
    }
}
