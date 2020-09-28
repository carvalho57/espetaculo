using System;
using Espetaculo.Domain.Enums;
using Espetaculo.Shared.Entities;
namespace Espetaculo.Domain.Entities {
    public class Reserva  : Entidade {        
        public Cliente Cliente { get; set; }
        public Sessao Sessao { get; set; }        
        public ICollection<Ingresso> Ingressos {get;set;}
        public ESatusReserva Status { get; set; }
    }
}