using System;
using System.Collections.Generic;
using System.Linq;
using Espetaculos.Domain.Entities;
using Espetaculos.Domain.Repositories;

namespace Espetaculos.Tests.Repositories
{
    public class FakeEspetaculoRepository : IEspetaculoRepository
    {
        private readonly List<Espetaculo> _espetaculo;
        public FakeEspetaculoRepository()
        {
            _espetaculo = new List<Espetaculo>();
            _espetaculo.Add(new Espetaculo("Homem aranha", "Aranha verso", 130));
        }

        public void Add(Espetaculo espetaculo)
        {
            _espetaculo.Add(espetaculo);
        }

        public void Delete(Espetaculo espetaculo)
        {
            _espetaculo.Remove(espetaculo);
        }

        public bool EspetaculoNameExist(string name)
        {
            return _espetaculo.Any(espetaculo => espetaculo.Nome == name);
        }

        public Espetaculo GetById(Guid id)
        {
            return _espetaculo.FirstOrDefault();
        }

        public void Update(Espetaculo espetaculo)
        {
            var removeEspetaculo = _espetaculo.FirstOrDefault(esp => esp.Nome == esp.Nome);
            _espetaculo.Remove(removeEspetaculo);
            _espetaculo.Add(espetaculo);
        }
    }
}