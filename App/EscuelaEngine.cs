using System.Collections.Generic;
using CorEscuela.Entities;
using CorEscuela.Entities.Enum;

namespace CorEscuela.App
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            this.Inicializate();
        }

        public void Inicializate()
        {
            Escuela = new Escuela("Escuela Platzi", 2006, TipoEscuelas.PreEscolar, pais: "Colombia", ciudad: "Bogotá");

            var listaCursos = new List<Curso>(){
                new Curso(){Nombre = "101", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "201", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "301", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "401", Jornada = TipoJornadas.Tarde},
                new Curso(){Nombre = "501", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "502", Jornada = TipoJornadas.Tarde}
            };

            Escuela.Cursos = listaCursos;




        }
    }
}