using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public ActionResult<List<Message>> GetMessages()
        {
            var messages = _messageService.GetMessages();
            return Ok(messages);
        }

        [HttpPost]
        public IActionResult PostMessage(Message message)
        {
            _messageService.PostMessage(message);
            return Ok();
        }

        [HttpGet("Konversation")]
        public ActionResult<List<Message>> GetMessagesBetweenParticipants([FromQuery] string Person1, [FromQuery] string Person2)
        {
            var messages = _messageService.GetMessagesBetweenParticipants(Person1, Person2);
            return Ok(messages);
        }

    }
}
