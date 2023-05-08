using System.Net;

namespace PharmaCare.Models
{
    public class APIResponses
    {
        public HttpStatusCode  HttpStatus {get;set;}

        public bool IsSuccess = true;  

        public List<String> ErrorMessages { get; set;}   
        
        public object Result { get; set;}   


    }
}
