using Candidates.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Candidates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected object ReturnMessage(string message, HttpStatusCode returnCode,
                bool successStatusCode, object model)
        {
            return new
            {
                Success = successStatusCode,
                Message = message,
                Data = model
            };
        }


        protected IActionResult GetActionResultByModel(CoreResponseModel<object> model, string message = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                message = model.StatusCode.ToString();
            }
            if (model == null)
            {
                model = new CoreResponseModel<object>(null, HttpStatusCode.InternalServerError);
            }


            switch (model.StatusCode)
            {
                case HttpStatusCode.OK:
                    {

                        return Ok(ReturnMessage(message, model.StatusCode, model.Success,model.Data));

                    }
                case HttpStatusCode.NotFound:
                    {
                        return NotFound(ReturnMessage(message, model.StatusCode, model.Success,model.Data));
                    }
                case HttpStatusCode.BadRequest:
                    {
                        return BadRequest(ReturnMessage(message, model.StatusCode, model.Success,model.Data));
                    }
                case HttpStatusCode.Forbidden:
                    {
                        return Forbid();
                    }
                case HttpStatusCode.InternalServerError:
                    {
                        return StatusCode(500,model.Data);
                    }
                default: // internal server Error
                    {
                        return StatusCode(500);
                    }
            }
        }

    }
}
