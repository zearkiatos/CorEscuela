using System;
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

            escuela.Cursos = new Curso[]{
                new Curso(){Nombre = "101"},
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "301"}
            };
            ImprimirCursosEscuela(escuela);

            bool rta = 10 == 10; //true
            int cantidad = 11;
            if (rta == false)
            {
                WriteLine("Se cumplio la condición #1");
            }
            else if (cantidad > 15)
            {
                WriteLine("Se cumplio la condición #2");
            }
            else
            {
                WriteLine("No Se cumplio la condición");
            }

            if (cantidad > 5 && rta == false)
            {
                WriteLine("Se cumplio la condición #3");
            }

            if (cantidad > 5 && rta)
            {
                WriteLine("Se cumplio la condición #4");
            }

            if ((cantidad > 5 || !rta) && cantidad % 5 == 0)
            {
                WriteLine("Se cumplio la condición #5");
            }
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
