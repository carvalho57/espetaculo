using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories
{
    public interface IReservaRepository
    {
        void Add(Reserva reserva);
        void Update(Reserva reserva);
        void Delete(Reserva reserva);
        Reserva GetById(Guid id);
        IEnumerable<Reserva> GetByCliente(Guid id);
    }
}