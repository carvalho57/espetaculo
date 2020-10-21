using System;
using System.Linq;
using System.Collections.Generic;
using Espetaculos.Domain.Commands;

namespace Espetaculos.Domain.Utils {
    public static class ExtractGuids {
        public static IEnumerable<Guid> Extract(CreateReservaCommand command) {
            return command.Ingressos.Select(ingresso => ingresso.PoltronaId);
        }
    }
}