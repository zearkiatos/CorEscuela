using System;
using System.Collections.Generic;
using CorEscuela.App;
using CorEscuela.Entities;
using CorEscuela.Entities.Enum;
using CorEscuela.Utils;
using System.Linq;
using static System.Console;
using CorEscuela.Entities.Interfaces;

namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += EventAction;
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(100, 1000, 1);
            AppDomain.CurrentDomain.ProcessExit -= EventAction;
            var engine = new EscuelaEngine();

            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");

            var reporteador = new Reporteador(engine.GetDictionaryObject());
            var evalList = reporteador.GetEvaluationList();
            var listaAsig = reporteador.GetAsignaturaList();
            var listaEvaluaciones = reporteador.GetDictionaryEvaluaXAsig();
            var listAverageByAsignature = reporteador.GetPromeStudentByAsignature();

            var listAverageTop = reporteador.GetAverageTopByMatter();

            
            string[] reporteMenu = engine.GetReportMenu();

            Printer.PrintMenu(reporteMenu,"Menú Core Escuela");

            // Printer.WriteTitle("Captura de una Evaluación por Consola");
            // var newEval = new Evaluacion();

            // string nombre;
            // float nota;

            // WriteLine("Ingrese el nombre de la evaluación");

            // Printer.PressEnter();

            // nombre = Console.ReadLine();

            // if (string.IsNullOrEmpty(nombre))
            // {
            //     Printer.WriteTitle("El valor del nombre no puede ser vacío");
            // }
            // else
            // {
            //     newEval.Nombre = nombre.ToLower();

            //     WriteLine("El nombre de la evaluación ha sido ingresado correctamente");
            // }

            // WriteLine("Ingrese el nota de la evaluación");

            // Printer.PressEnter();

            // string notastring = Console.ReadLine();

            // if (string.IsNullOrEmpty(notastring))
            // {
            //     Printer.WriteTitle("El valor del nota no puede ser vacío");
            //     WriteLine("Saliendo del Programa");
            // }
            // else
            // {
            //     try
            //     {
            //         newEval.Nota = float.Parse(notastring);
            //         if (newEval.Nota < 0 || newEval.Nota > 5)
            //         {
            //             throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
            //         }
            //         WriteLine("El nota de la evaluación ha sido ingresado correctamente");
            //     }
            //     catch (ArgumentOutOfRangeException arge)
            //     {
            //         WriteLine(arge.Message);
            //         WriteLine("Saliendo del Programa");
            //     }
            //     catch (Exception e)
            //     {
            //         Printer.WriteTitle("El valor del nota no es un número valido.");
            //         WriteLine("Saliendo del Programa");
            //     }
            //     finally
            //     {
            //         Printer.WriteTitle("Finally");
            //         Printer.Beep(2500, 500, 3);
            //     }

            // }




        }

        private static void EventAction(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("SALIO");
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
