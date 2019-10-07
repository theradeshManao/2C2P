using assignment2C2P.Models.ValidationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2C2P.Models.Responses
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Object { get; set; }

        public static Response<T> SendRespose(T object_, bool success = true)
        {
            return new Response<T>()
            {
                Object = object_,
                Success = success
            };
        }

        public static Response<T> SendResposeError(ValidationTest validationTest)
        {
            return new Response<T>()
            {
                ErrorMessage = validationTest.Message,
                Success = validationTest.Success
            };
        }
    }
}
