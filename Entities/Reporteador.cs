using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entities.Enum;
using CorEscuela.Utils;

namespace CorEscuela.Entities
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dictionary;

        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dictionaryObjEscuela)
        {
            if (dictionaryObjEscuela == null)
                throw new ArgumentNullException(nameof(dictionaryObjEscuela));

            dictionary = dictionaryObjEscuela;
        }

        public IEnumerable<Evaluacion> GetEvaluationList()
        {
            if (dictionary.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> list))
            {
                return list.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();

                //Escribir en el log de auditoria
            }
        }

        public IEnumerable<string> GetAsignaturaList(out IEnumerable<Evaluacion> listEval)
        {
            listEval = GetEvaluationList();
            var eval = (from Evaluacion ev in listEval
                        select ev.Asignatura.Nombre).Distinct();
            return eval;
        }


        public IEnumerable<string> GetAsignaturaList()
        {
            return GetAsignaturaList(out var dummy);
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDictionaryEvaluaXAsig()
        {
            var dictionaryRespuesta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listAsig = GetAsignaturaList(out var listEval);

            foreach (var asignatura in listAsig)
            {
                var evalsAsig = from eval in listEval
                                where eval.Asignatura.Nombre == asignatura
                                select eval;
                dictionaryRespuesta.Add(asignatura, evalsAsig);
            }



            return dictionaryRespuesta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromeStudentByAsignature()
        {
            var request = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDictionaryEvaluaXAsig();

            foreach (var asignatureConEval in dicEvalXAsig)
            {
                var averageStudent = from eval in asignatureConEval.Value
                                     group eval by new
                                     {
                                         eval.Alumno.UniqueId,
                                         eval.Alumno.Nombre

                                     }
                            into evalStudentGroup
                                     select new AlumnoPromedio
                                     {
                                         AlumnoId = evalStudentGroup.Key.UniqueId,
                                         AlumnoNombre = evalStudentGroup.Key.Nombre,
                                         Promedio = evalStudentGroup.Average(e => e.Nota)
                                     };
                request.Add(asignatureConEval.Key, averageStudent);
            }

            return request;
        }

        public Dictionary<string, IEnumerable<object>> GetAverageTopByMatter(int top = 5)
        {
            var request = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDictionaryEvaluaXAsig();
            foreach (var asignatureConEval in dicEvalXAsig)
            {
                var averageStudent = (from eval in asignatureConEval.Value
                                      group eval by new
                                      {
                                          eval.Alumno.UniqueId,
                                          eval.Alumno.Nombre,
                                          eval.Asignatura

                                      }
                            into evalStudentGroup
                                      select new AlumnoPromedio
                                      {
                                          AlumnoId = evalStudentGroup.Key.UniqueId,
                                          AlumnoNombre = evalStudentGroup.Key.Nombre,
                                          Promedio = evalStudentGroup.Average(e => e.Nota)
                                      }).Take(top).OrderByDescending(x => x.Promedio);
                request.Add(asignatureConEval.Key, averageStudent);
            }

            return request;
        }

        public string PrintReport(int reportedSelected)
        {
            Printer.DrawLine();
            switch (reportedSelected)
            {
                case 1:
                    foreach (var item in this.GetEvaluationList())
                    {
                        Console.WriteLine($"Alumno: {item.Alumno.Nombre} | {item.Nombre} Nota: {item.Nota}");
                    }

                    break;
                case 2:
                    foreach (var item in this.GetAsignaturaList())
                    {
                        Console.WriteLine($"Nombre: {item}");
                    }

                    break;
                case 3:
                    foreach (var asignatura in this.GetDictionaryEvaluaXAsig())
                    {
                        Printer.WriteTitle(asignatura.Key);
                        foreach (var evaluacion in asignatura.Value)
                        {
                            Console.WriteLine($"Alumno: {evaluacion.Alumno.Nombre} | {evaluacion.Nombre} Nota: {evaluacion.Nota}");
                        }
                        Printer.DrawLine();
                    }

                    break;
                case 4:
                    foreach (var asignatura in this.GetPromeStudentByAsignature())
                    {
                        Printer.WriteTitle($"Promedios {asignatura.Key}");
                        foreach (var average in asignatura.Value.Cast<AlumnoPromedio>())
                        {
                            Console.WriteLine($"Alumno: {average.AlumnoNombre} | Promedio: {average.Promedio}");
                        }
                    }

                    break;
                case 5:
                    Printer.WriteTitle("Top de mejores promedios");
                    Console.WriteLine("Por favor ingrese el maximo de mejores promedios que quieres que se liste");
                    var top = Console.ReadLine();
                    if (!string.IsNullOrEmpty(top))
                    {
                        var topList = this.GetAverageTopByMatter(int.Parse(top));
                        foreach (var matterAvg in topList)
                        {
                            Printer.WriteTitle($"Promedios {matterAvg.Key}");
                            foreach (var average in matterAvg.Value.Cast<AlumnoPromedio>())
                            {
                                Console.WriteLine($"Alumno: {average.AlumnoNombre} | Promedio: {average.Promedio}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error Parametro top vacio, debe ser ingresado, pulse cualquier tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();

                    }

                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
            Printer.DrawLine(50);
            Console.WriteLine("¿Desea Continuar? Pulse [Y] si desea continuar o cualquier tecla si no lo desea. ");
            var response = Console.ReadLine();
            return response.ToString();
        }

    }
}