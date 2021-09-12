using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace AltenHotel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<object> _log;

        protected IActionResult CreateExceptionMessage(Exception exception)
        {
            _log.LogError(exception.Message, exception);

            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultError
            {
                Message = "Unexpected error"
            });
        }
    }
}