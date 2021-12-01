using System;
namespace SAPexGoogleSupportService.Models
{
    public class GoogleResponse<T>
    {
        public string Message { get; set; }

        public int Code { get; set; }

        public T Data { get; set; }

    }
}
