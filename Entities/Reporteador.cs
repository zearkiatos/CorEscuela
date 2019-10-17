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

        public IEnumerable<Escuela> GetEvaluationList()
        {
            IEnumerable<Escuela> response;
            if (dictionary.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> list))
            {
                response = list.Cast<Escuela>();
            }
            else
            {
                response = null;

                //Escribir en el log de auditoria
            }
            return list.Cast<Escuela>();
        }
    }
}