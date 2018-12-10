using DotNetCore.AspNetCore;
using IDCardScanning.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace IDCardScanning.Web
{
    [ApiController]
    [RouteController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        public ApplicationModel Get()
        {
            return new ApplicationModel();
        }
    }
}
