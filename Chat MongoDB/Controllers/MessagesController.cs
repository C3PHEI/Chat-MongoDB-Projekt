﻿using Microsoft.AspNetCore.Mvc;
using Chat_MongoDB.Models;
using Chat_MongoDB.Services;

namespace Chat_MongoDB.Controllers
{
   

    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessagesController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult PostMessage(Message message)
        {
            _messageService.PostMessage(message);
            return Ok();
        }

        // Weitere Methoden hinzufügen, falls benötigt
    }

}