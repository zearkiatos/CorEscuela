using System;
using System.Collections.Generic;
using CorEscuela.Entities.Enum;

namespace CorEscuela.Entities
{
    public class Curso : ObjetoEscuelaBase
    {

        public TipoJornadas Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }
    }
}