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
            Printer.Beep(10000,qty:10);
            ImprimirCursosEscuela(engine.Escuela);

        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de Escuela");

            if(escuela?.Cursos != null){
                foreach(var curso in escuela.Cursos){
                    WriteLine($"Nombre: {curso.Nombre}, Id {curso.UniqueId}");
                }
            }
        }
    }
}
