using System;
using System.Collections.Generic;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Repositories;

namespace Espetaculos.Tests.Repositories {
    public class FakeSalaRepository : ISalaRepository
    {
        public readonly List<Sala> _salas;

        public FakeSalaRepository()
        {
            _salas = new List<Sala>();
            _salas.Add(new Sala("00", 200, 20, Domain.Enums.EIdentificacaoPoltrona.AlfaNumerico));
        }

        public void Add(Sala sala)
        {
            _salas.Add(sala);
        }

        public void Delete(Sala sala)
        {
            _salas.Remove(sala);
        }

        public Sala GetById(Guid id)
        {
            return _salas[0];
        }
    }
}