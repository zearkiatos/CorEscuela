using System;
using System.Collections.Generic;
using CorEscuela.App;
using CorEscuela.Entities;
using CorEscuela.Entities.Enum;
using CorEscuela.Utils;
using static System.Console;
namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();

            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            // Printer.Beep(10000,qty:10);
            ImprimirCursosEscuela(engine.Escuela);

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");
            var alumnoTest = new Alumno
            {
                Nombre = "Claire Underwood"
            };

            ObjetoEscuelaBase ob = alumnoTest;

            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"UniqueId: {alumnoTest.UniqueId}");
            WriteLine($"Type Objet: {alumnoTest.GetType()}");

            Printer.WriteTitle("Objeto Escuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"UniqueId: {ob.UniqueId}");
            WriteLine($"Type Objet: {ob.GetType()}");


            var objDummy = new ObjetoEscuelaBase()
            {
                Nombre = "Frank Underwood"
            };
            Printer.WriteTitle("Objeto Escuela Base");
            WriteLine($"Alumno: {objDummy.Nombre}");
            WriteLine($"UniqueId: {objDummy.UniqueId}");
            WriteLine($"Type Objet: {objDummy.GetType()}");

            alumnoTest = (Alumno)ob;

            var evaluacion = new Evaluacion
            {
                Nombre = "Evaluación de Matemática",
                Nota = 4.5f
            };

            Printer.WriteTitle("Evaluación");
            WriteLine($"Nombre: {evaluacion.Nombre}");
            WriteLine($"UniqueId: {evaluacion.UniqueId}");
            WriteLine($"Nota: {evaluacion.Nota}");
            WriteLine($"Type: {evaluacion.GetType()}");

            ob = evaluacion;

            Printer.WriteTitle("Objeto Escuela");
            WriteLine($"Evaluación: {ob.Nombre}");
            WriteLine($"UniqueId: {ob.UniqueId}");
            WriteLine($"Type Objet: {ob.GetType()}");



        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de Escuela");

            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id {curso.UniqueId}");
                }
            }
        }
    }
}
