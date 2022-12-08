using MenKosAPI.Models;

namespace MenKosAPI.Responses
{
    public class PostResponse : BaseResponse
    {
        public Payment Post { get; set; }
    }
}
