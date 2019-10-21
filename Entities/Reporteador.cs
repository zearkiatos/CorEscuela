using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entities.Enum;

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

        public IOrderedEnumerable<AlumnoPromedio> GetAverageTopByMatter(int top=5)
        {
             var request = new Dictionary<string, IEnumerable<object>>();


            return GetPromeStudentByAsignature().Cast<AlumnoPromedio>().Take(top).OrderByDescending(x=>x.Promedio);
        }
    }
}