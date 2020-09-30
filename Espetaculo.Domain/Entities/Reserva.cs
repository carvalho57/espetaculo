using System;
using System.Collections.Generic;
using Espetaculo.Domain.Enums;
using Espetaculo.Shared.Entities;
namespace Espetaculo.Domain.Entities {
    public class Reserva  : Entidade {
        public Reserva(Cliente pagador, Sessao sessao)
        {
            Pagador = pagador;
            Sessao = sessao;
            Ingressos = new List<Ingresso>();
            Status = EStatusReserva.Criada;
        }

        public Cliente Pagador { get; set; }
        public Sessao Sessao { get; set; }        
        public ICollection<Ingresso> Ingressos {get;set;}
        public EStatusReserva Status { get; set; }

        public void AdicionarIngresso(Ingresso ingresso) {
            Ingressos.Add(ingresso);
        }
    }
}