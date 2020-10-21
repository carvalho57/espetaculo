using System;
using Espetaculos.Domain.Entities;

namespace Espetaculos.Domain.Repositories {
    public interface IReservaRepository {
        void Add(Reserva reserva);
    }
}