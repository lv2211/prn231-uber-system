using System.Net;

namespace UberSystem.Dto
{
    public record ApiResponseModel<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; } = null!;

        public T? Response { get; set; }
    }
}
