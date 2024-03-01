namespace EvoChat.Shared
{
    public class ResponseDto
    { 
        public bool status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object data { get; set; }
    }
}