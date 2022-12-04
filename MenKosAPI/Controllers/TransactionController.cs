using MenKosAPI.Base;
using MenKosAPI.Models;
using MenKosAPI.Repositories.Data;
using MenKosAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenKosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private TransactionRepository _transactionRepository;
        private OccupantRepository _occupantRepository;
        public TransactionController(TransactionRepository transactionRepository, OccupantRepository occupantRepository)
        {
            _occupantRepository = occupantRepository;
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public IActionResult GetTransaction()
        {
            var listData = _transactionRepository.Get();

            return Ok(new
            {
                Message = "Success Get Data",
                StatusCode = 200,
                Data = listData
            });
        }


        [HttpPost("NewTransaction")]
        public IActionResult CreateTransaction(NewTransactionVM newTransaction)
        {
            var result = _transactionRepository.CreateNewTransaction(newTransaction);

            return result switch
            {
                1 => Ok(new
                {
                    Message = "Buat Transaksi Baru Berhasil!",
                    StatusCode = 200,
                }),
                _ => BadRequest(new
                {
                    Message = "Buat Transaksi Gagal!",
                    StatusCode = 400
                })
            };



        }



        [HttpGet("Admin/PaymentDeadline")]
        public IActionResult GetBill()
        {
            var listBill = _transactionRepository.GetBill();

            return Ok(new
            {
                Message = "Success Get Data",
                Status = 200,
                Data = listBill
            });
        }




    }
}
