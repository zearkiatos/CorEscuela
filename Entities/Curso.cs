using System;
using CorEscuela.Entities.Enum;

namespace CorEscuela.Entities
{
    public class Curso
    {
        
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public TipoJornadas Jornada { get; set; }

        public Curso()=>(UniqueId) = (Guid.NewGuid().ToString());
    }
}