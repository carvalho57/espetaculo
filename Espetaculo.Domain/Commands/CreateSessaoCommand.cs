using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;
using Espetaculos.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System.Linq;

namespace Espetaculos.Domain.Commands {
    public class CreateSessaoCommand : Notifiable, ICommand{                                        
       
        public bool Validate()
        {            
            return Valid;
        }
    }
}