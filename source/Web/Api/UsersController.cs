using DotNetCore.AspNetCore;
using IDCardScanning.Application;
using IDCardScanning.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IDCardScanning.Web
{
    [ApiController]
    [RouteController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserApplication userApplication)
        {
            UserApplication = userApplication;
        }

        private IUserApplication UserApplication { get; }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return UserApplication.List();
        }

        [HttpGet("{id}")]
        public UserModel Get(long id)
        {
            return UserApplication.Select(id);
        }
    }
}
