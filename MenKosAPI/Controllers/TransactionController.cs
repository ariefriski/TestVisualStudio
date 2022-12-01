using MenKosAPI.Base;
using MenKosAPI.Models;
using MenKosAPI.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenKosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private TransactionRepository _transactionRepository;
        public TransactionController(TransactionRepository transactionRepository) 
        {
         _transactionRepository = transactionRepository;
        }

        [HttpGet("Transaction")]
        public IActionResult GetTransaction()
        {
            var listData = _transactionRepository.Get();

            return Ok(new
            {
                message = "berhasil",
                statusCode = 200,
                data = listData
            });
        }
    }
}
