using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoAngular.Models.Response;
using ProyectoAngular.Models.ViewModels;
using ProyectoAngular.Services;

namespace ProyectoAngular.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly IMessageService _messageService;

        public ChatController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("[action]")]
        public IEnumerable<MessageViewModel> Message()
        {
            return _messageService.Message();
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]MessageViewModel model)
        {
            return _messageService.Add(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}