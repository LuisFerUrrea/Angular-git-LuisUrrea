using Microsoft.AspNetCore.Mvc;
using ProyectoAngular.Models;
using ProyectoAngular.Models.Response;
using ProyectoAngular.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAngular.Services
{
    public interface IMessageService
    {
        void AddMessage(Message message);
        IEnumerable<MessageViewModel> Message();
        MyResponse Add([FromBody]MessageViewModel model);
    }
}
