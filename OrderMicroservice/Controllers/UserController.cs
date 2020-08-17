using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcAuthService;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceInterfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }


        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = _userService.GetAllUsers(new Empty(), new CallOptions());
            return Ok(response);
        }

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserRequest request)
        {
            var response = _userService.RegisterUser(request, new CallOptions());

            var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/api/user/";
            var location = new Uri(url + response.Id);

            return Created(location, response);
        }

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
