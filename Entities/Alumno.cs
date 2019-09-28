using System;

namespace CorEscuela.Entities
{
    public class Alumno
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public Alumno() => (UniqueId) = (Guid.NewGuid().ToString());
    }
}