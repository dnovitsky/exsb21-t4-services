using System;
namespace SAPex.Models
{
    public class ActionResponse<T>
    {
        public long TimeStamp { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public T Data { get; set; }
    }
}

