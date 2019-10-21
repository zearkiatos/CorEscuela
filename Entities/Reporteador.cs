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
            if (dictionary.TryGetValue(LlaveDiccionario.Evaluaciones, out IEnumerable<ObjetoEscuelaBase> list))
            {
                return list.Cast<Evaluacion>();
            }
            else
            {
                return null;

                //Escribir en el log de auditoria
            }
        }

        public IEnumerable<string> GetAsignaturaList(out IEnumerable<Evaluacion> listEval)
        {
            listEval = GetEvaluationList();

            return (from Evaluacion ev in listEval
                    select ev.Asignatura.Nombre).Distinct();
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
                var dummy = from eval in asignatureConEval.Value
                            group eval by eval.Alumno.UniqueId
                            into evalStudentGroup
                            select new
                            {
                                StudentId = evalStudentGroup.Key,
                                Average = evalStudentGroup.Average(e => e.Nota)
                            };

            }

            return request;
        }
    }
}