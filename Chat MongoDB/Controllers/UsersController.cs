﻿using Chat_MongoDB.Models;
using Chat_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;


namespace Chat_MongoDB.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            _userService.Register(user);
            return Ok();
        }

        // Weitere Methoden für Login und Messaging hinzufügen
    }

}