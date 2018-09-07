using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPUTemp2;

namespace TempImplementation.Controllers
{
    [Route("Temprature")]
    public class TempController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTemp()
        {
            return new string[] { "value1", "value2" };
        }
    }
}