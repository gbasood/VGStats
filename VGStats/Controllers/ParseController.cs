using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VGStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParseController : ControllerBase
    {
        /// <summary>
        /// How we receive the alert for a new file stored on the file system, waiting to be parsed.
        /// </summary>
        /// <returns></returns>
        [HttpGet("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update()
        {
            return new StatusCodeResult(StatusCodes.Status200OK);
        }
    }


}