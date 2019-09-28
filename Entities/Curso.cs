using System;
using System.Collections.Generic;
using CorEscuela.Entities.Enum;

namespace CorEscuela.Entities
{
    public class Curso
    {
        
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public TipoJornadas Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public Curso()=>(UniqueId) = (Guid.NewGuid().ToString());
    }
}