using System;

namespace CorEscuela.Entities
{
    public class Evaluacion : ObjetoEscuelaBase
    {

        public Alumno Alumno { get; set; }

        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }
    }
}