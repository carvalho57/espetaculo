using System;
using System.Collections.Generic;
using System.Linq;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Repositories;

namespace Espetaculos.Tests.Repositories {
    public class FakeReservaRepository : IReservaRepository
    {
        private readonly List<Reserva> _reservas;

        public FakeReservaRepository()
        {
            _reservas = new List<Reserva>();                    
        }

        public void Add(Reserva reserva)
        {
            _reservas.Add(reserva);
        }

        public void Delete(Reserva reserva)
        {
            _reservas.Remove(reserva);
        }

        public IEnumerable<Reserva> GetByCliente(Guid id)
        {
            return _reservas.Where(reserva => reserva.Pagador.Id == id).ToList();
        }

        public Reserva GetById(Guid id)
        {
            return _reservas.FirstOrDefault();
        }        
        public void Update(Reserva reserva)
        {
            var removed = _reservas.FirstOrDefault(res => res.Id == reserva.Id);
            _reservas.Remove(removed);
            _reservas.Add(reserva);
        }
    }
}