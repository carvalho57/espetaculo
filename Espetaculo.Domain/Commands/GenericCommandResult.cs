using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;
using Espetaculos.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Espetaculos.Domain.Commands {
    public class GenericCommandResult : ICommandResult {
        public GenericCommandResult(bool sucess, string message, IReadOnlyCollection<Notification> notifications)
        {
            Sucess = sucess;
            Message = message;
            Notifications = notifications;            
        }
         public GenericCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public IReadOnlyCollection<Notification> Notifications {get;set;}
        public object Data {get;set;}


    }
}