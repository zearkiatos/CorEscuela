using System;
using System.Collections.Generic;
using CorEscuela.Entities;
using CorEscuela.Entities.Enum;
using static System.Console;
namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Escuela Platzi", 2006, TipoEscuelas.PreEscolar, pais: "Colombia", ciudad: "Bogotá");

            var listaCursos = new List<Curso>(){
                new Curso(){Nombre = "101", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "201", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "301", Jornada = TipoJornadas.Maniana}
            };

            escuela.Cursos = listaCursos;

            escuela.Cursos.Add(new Curso(){
                Nombre="102",
                Jornada= TipoJornadas.Tarde
            });

            escuela.Cursos.Add(new Curso(){
                Nombre="202",
                Jornada= TipoJornadas.Tarde
            });

            var otraColeccion = new List<Curso>(){
                new Curso(){Nombre = "401", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "501", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "502", Jornada = TipoJornadas.Tarde}
            };

            Curso tmp = new Curso{
                Nombre="101-Vacacional",
                Jornada = TipoJornadas.Noche
            };
            otraColeccion.Clear();

            escuela.Cursos.AddRange(otraColeccion);

            escuela.Cursos.Add(tmp);


            ImprimirCursosEscuela(escuela);
            // WriteLine("Curso.Hash "+tmp.GetHashCode());

            Predicate<Curso> miAlgoritmo = precidado;
            escuela.Cursos.RemoveAll(miAlgoritmo);
            // escuela.Cursos.Remove(tmp);
            WriteLine("===============");
            ImprimirCursosEscuela(escuela);

        }

        private static bool precidado(Curso obj)
        {
            return obj.Nombre == "301";
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("====================");
            WriteLine("Cursos de la Escuela");
            WriteLine("====================");

            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id {curso.UniqueId}");
                }
            }


        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador++;
            }
            while (contador < arregloCursos.Length);
        }


        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {

            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre: {arregloCursos[i].Nombre}, Id {arregloCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {

            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre}, Id {curso.UniqueId}");
            }
        }
    }
}
