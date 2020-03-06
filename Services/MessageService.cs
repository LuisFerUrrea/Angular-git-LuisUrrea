using Microsoft.AspNetCore.Mvc;
using ProyectoAngular.Context;
using ProyectoAngular.Models;
using ProyectoAngular.Models.Response;
using ProyectoAngular.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAngular.Services
{
    public class MessageService : IMessageService
    {
        private readonly IContextDB _contextDB;

        public MessageService(IContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public void AddMessage(Message message)
        {
            _contextDB.Messages.Add(message);
            _contextDB.SaveChanges();
        }

        //public List<Message> Message()
        //{
        //    List<Message> lstMessage = null;
        //    lstMessage = _contextDB.Messages.ToList();
        //    return lstMessage;
        //}

        public IEnumerable<MessageViewModel> Message()
        {
            List<MessageViewModel> lst = (from d in _contextDB.Messages
                                          select new MessageViewModel
                                          {
                                              Id = d.Id,
                                              Name = d.Name,
                                              Texto = d.Texto
                                          }).ToList();
            return lst;
        }


        public MyResponse Add([FromBody]MessageViewModel model)
        {
            MyResponse objMyResponse = new MyResponse();
            try
            {
                Message objMessage = new Message();
                objMessage.Name = model.Name;
                objMessage.Texto = model.Texto;
                _contextDB.Messages.Add(objMessage);
                _contextDB.SaveChanges();
                objMyResponse.Success = 1;
            }
            catch (Exception ex)
            {

                objMyResponse.Success = 0;
                objMyResponse.Message = ex.Message;
            }
            return objMyResponse;
        }
    }
}
