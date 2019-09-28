using System;

namespace CorEscuela.Entities
{
    public class Evaluacion
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public Alumno Alumno { get; set; }

        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }

        public Evaluacion() => (UniqueId) = (Guid.NewGuid().ToString());
    }
}