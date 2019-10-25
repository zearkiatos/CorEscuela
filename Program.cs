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
            var keep = "Y";
            do
            {
                var menuOption = Printer.PrintMenu(reporteMenu, "Menú Core Escuela");
                keep = reporteador.PrintReport(menuOption);
                Console.Clear();
            }
            while (keep.ToUpper() == "Y");




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
