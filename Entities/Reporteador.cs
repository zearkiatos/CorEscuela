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

        public IEnumerable<string> GetAsignaturaList()
        {
            var listEval = GetEvaluationList();

            return (from Evaluacion ev in listEval
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string,IEnumerable<Evaluacion>> GetDictionaryEvaluaXAsig()
        {
            Dictionary<string, IEnumerable<Evaluacion>> dictionaryRespuesta = new Dictionary<string, IEnumerable<Evaluacion>>();

            return dictionaryRespuesta;
        }
    }
}