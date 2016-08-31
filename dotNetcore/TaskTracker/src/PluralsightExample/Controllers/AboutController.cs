using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace TaskTracker.Controllers
{
    [Route("company/[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+1-555-555-5555";
        }

        [Route("[action]")]
        public string Country()
        {
            return "USA";
        }
    }
}
