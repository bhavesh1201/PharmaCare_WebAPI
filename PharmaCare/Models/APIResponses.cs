using System.Net;

namespace PharmaCare.Models
{
    public class APIResponses
    {
        public HttpStatusCode  HttpStatus {get;set;}

        public bool IsSuccess { get;set;}   

        public List<String> Messages { get; set;}   

        public object Result { get; set;}   


    }
}
