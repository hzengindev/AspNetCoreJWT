using AspNetCore.JWT.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.JWT.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : SecureController
    {
        [NonAction]
        public IActionResult Success<T>(T data)
        {
            return Ok(new SuccessReturn<T>()
            {
                Data = data
            });
        }

        [NonAction]
        public IActionResult Success(object data = default(object))
        {
            return Ok(new SuccessReturn()
            {
                Data = data
            });
        }

        [NonAction]
        public IActionResult Error(string errorMessage = default(string), int? errorCode = (int?)null, object data = default(object))
        {
            return BadRequest(new ErrorReturn()
            {
                ErrorMessage = errorMessage,
                ErrorCode = errorCode,
                Data = data
            });
        }
    }
}