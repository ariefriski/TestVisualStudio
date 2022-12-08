using MenKosAPI.Base;
using MenKosAPI.Models;
using MenKosAPI.Repositories.Data;
using MenKosAPI.Responses;
using MenKosAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MenKosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private TransactionRepository _transactionRepository;
        private readonly ILogger<TransactionController> logger;

        public TransactionController(TransactionRepository transactionRepository, ILogger<TransactionController> logger)
        {

            _transactionRepository = transactionRepository;
            this.logger = logger;
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
        public async Task<IActionResult> CreateTransaction([FromForm]NewTransactionVM newTransaction)
        {
            //var result = _transactionRepository.CreateNewTransaction(newTransaction);

            if (newTransaction == null)


            {


                return BadRequest(new PostResponseNewTransaction { Success = false, ErrorCode = "S01", Error = "Invalid post request" });


            }


            if (string.IsNullOrEmpty(Request.GetMultipartBoundary()))


            {


                return BadRequest(new PostResponseNewTransaction { Success = false, ErrorCode = "S02", Error = "Invalid post header" });


            }


            if (newTransaction.Image != null)


            {


                await _transactionRepository.SavePayment(newTransaction);


            }


            var postResponse = await _transactionRepository.CreateNewTransaction(newTransaction);


            if (!postResponse.Success)


            {


                return NotFound(postResponse);


            }


            return Ok(postResponse.Post);


            //return result switch
            //{
            //    1 => Ok(new
            //    {
            //        Message = "Buat Transaksi Baru Berhasil!",
            //        StatusCode = 200,
            //    }),
            //    _ => BadRequest(new
            //    {
            //        Message = "Buat Transaksi Gagal!",
            //        StatusCode = 400
            //    })
            //};



        }



        [HttpGet("PaymentDeadline")]
        public IActionResult GetBill()
        {
            var listBill = _transactionRepository.GetBill();

            return Ok(new
            {
                Message = "Get Data Successfuly",
                Status = 200,
                Data = listBill
            });
        }

        [HttpGet("PaymentDeadline/{occupantId}")]
        public IActionResult GetBill(int occupantId)
        {
            var bill = _transactionRepository.GetBill(occupantId);

            if (bill != null)
            {

                return Ok(new
                {
                    Message = "Get Data Successfuly",
                    Status = 200,
                    Data = bill
                });
            }

            return BadRequest(new
            {
                Message = "Data not found!",
                Status = 400
            });
        }

        [HttpPost("ExtendTransaction")]
        public IActionResult CreateExtendRequestTransaction(ExtendTransactionVM extendTransaction)
        {
            var result = _transactionRepository.CreateExtendTransaction(extendTransaction);
            return result switch
            {
                1 => Ok(new
                {
                    Message = "Buat Permintaan Perpanjang Kamar Berhasil!",
                    StatusCode = 200
                })
            };
        }



    }
}
