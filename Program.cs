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
            var engine = new EscuelaEngine();

            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            // Printer.Beep(10000,qty:10);
            ImprimirCursosEscuela(engine.Escuela);
            int dummy = 0;
            var listaObjetos = engine.GetObjetosEscuela();

            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            diccionario.Add(10, "JuanK");

            diccionario.Add(23, "Lorem Ipsum");

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key} Valor: {keyValPair.Value}");
            }

            Printer.WriteTitle("Acceso a diccionario");

            diccionario[0] = "Pekerman";

            WriteLine(diccionario[0]);

            Printer.WriteTitle("Otro Diccionario");

            var dic = new Dictionary<string, string>();
            dic["Luna"] = "Cuerpo celeste que gira alrededor de la Tierra";

            WriteLine(dic["Luna"]);

            dic["Luna"] = "Protagonista de Soy Luna";

            WriteLine(dic["Luna"]);

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
