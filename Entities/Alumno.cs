using System;
using System.Collections.Generic;

namespace CorEscuela.Entities
{
    public class Alumno : ObjetoEscuelaBase
    {

        public List<Evaluacion> Evaluaciones { get; set; }

    }
}