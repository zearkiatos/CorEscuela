using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entities;
using CorEscuela.Entities.Enum;
using CorEscuela.Utils;

namespace CorEscuela.App
{

    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            this.Inicializate();
        }

        private string[] ReportList { get; set; }

        public void Inicializate()
        {
            Escuela = new Escuela("Escuela Platzi", 2006, TipoEscuelas.PreEscolar, pais: "Colombia", ciudad: "Bogotá");

            CargarCursos();

            CargarAsignaturas();

            CargarEvaluaciones();

            CargarMenuDeReportes();



        }

        #region Metodos de Carga
        private void CargarEvaluaciones(int qty = 5)
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {

                    foreach (var alumno in curso.Alumnos)
                    {
                        alumno.Evaluaciones = new List<Evaluacion>();
                        for (int i = 0; i < qty; i++)
                        {
                            Evaluacion evaluacion = new Evaluacion
                            {
                                Alumno = alumno,
                                Asignatura = asignatura,
                                Nombre = $"Curso {curso.Nombre} Evaluación {i + 1} {asignatura.Nombre}",
                                Nota = NoteSimulator()
                            };
                            alumno.Evaluaciones.Add(evaluacion);
                        }
                    }



                }

            }

        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Educación Física"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerateRandomAlumnos(int qty)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás", "Zoy" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera", "Cerra" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro", "Labe" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   Nombre = $"{n1} {n2} {a1}"
                               };

            return listaAlumnos.OrderBy((a) => a.UniqueId).Take(qty).ToList();



        }

        private float NoteSimulator()
        {
            var rand = new Random();
            float result = (float)MathF.Round((float)rand.NextDouble() * 5, 2);
            return result;
        }


        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre = "101", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "201", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "301", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "401", Jornada = TipoJornadas.Tarde},
                new Curso(){Nombre = "501", Jornada = TipoJornadas.Maniana},
                new Curso(){Nombre = "502", Jornada = TipoJornadas.Tarde}
            };
            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int qtyRandom = rnd.Next(5, 20);
                c.Alumnos = GenerateRandomAlumnos(qtyRandom);
            }
        }

        private void CargarMenuDeReportes()
        {
            ReportList = new string[]{
                "Lista de Evaluaciones",
                "Lista de Asignaturas",
                "Lista de Evaluaciones por Asignatura",
                "Lista de Promedios por Asignatura",
                "Top de Mejores promedio por Asignatura",
                "Captura de una Evaluación",
                "Salir"

            };
        }

        #endregion

        public string[] GetReportMenu(){
            return this.ReportList;
        }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int countEvaluations, out int countStudents, out int countAsignatures, out int countCourse,
                bool traeEvaluaciones = true, bool traeAlumnos = true, bool traeAsignaturas = true, bool traeCursos = true)
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            countEvaluations = countCourse = countAsignatures = countStudents = 0;
            listaObj.Add(Escuela);

            if (traeCursos)
                listaObj.AddRange(Escuela.Cursos);

            countCourse = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                if (traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                countAsignatures += curso.Asignaturas.Count;

                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                countStudents += curso.Alumnos.Count;

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        countEvaluations += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(bool traeEvaluaciones = true, bool traeAlumnos = true, bool traeAsignaturas = true, bool traeCursos = true)
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int countEvaluations, bool traeEvaluaciones = true, bool traeAlumnos = true, bool traeAsignaturas = true, bool traeCursos = true)
        {
            return GetObjetosEscuela(out countEvaluations, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int countEvaluations, out int countStudents, bool traeEvaluaciones = true, bool traeAlumnos = true, bool traeAsignaturas = true, bool traeCursos = true)
        {
            return GetObjetosEscuela(out countEvaluations, out countStudents, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int countEvaluations, out int countStudents, out int countAsignatures, bool traeEvaluaciones = true, bool traeAlumnos = true, bool traeAsignaturas = true, bool traeCursos = true)
        {
            return GetObjetosEscuela(out countEvaluations, out countStudents, out countAsignatures, out int dummy);
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDictionaryObject()
        {

            var dictionary = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            dictionary.Add(LlaveDiccionario.Escuela, new[] { Escuela });

            dictionary.Add(LlaveDiccionario.Cursos, Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            var tempList = new List<Evaluacion>();
            var tempListAsignatura = new List<Asignatura>();
            var tempListAlumno = new List<Alumno>();
            foreach (var curso in Escuela.Cursos)
            {
                tempListAsignatura.AddRange(curso.Asignaturas);
                tempListAlumno.AddRange(curso.Alumnos);
                foreach (var alumno in curso.Alumnos)
                {
                    tempList.AddRange(alumno.Evaluaciones);
                }

            }
            dictionary.Add(LlaveDiccionario.Asignaturas, tempListAsignatura.Cast<ObjetoEscuelaBase>());
            dictionary.Add(LlaveDiccionario.Alumnos, tempListAlumno.Cast<ObjetoEscuelaBase>());
            dictionary.Add(LlaveDiccionario.Evaluacion, tempList.Cast<ObjetoEscuelaBase>());
            return dictionary;
        }

        public void PrintDictionary(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dictionary, bool printEvaluacion = false)
        {
            foreach (var obj in dictionary)
            {
                Printer.WriteTitle(obj.Key.ToString());
                Console.WriteLine(obj);
                foreach (var val in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if (printEvaluacion)
                                Console.WriteLine(val);
                            break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine("Escuela: " + val);
                            break;
                        case LlaveDiccionario.Alumnos:
                            Console.WriteLine("Alumno: " + val.Nombre);
                            break;
                        case LlaveDiccionario.Cursos:
                            var cursoTemp = val as Curso;
                            if (cursoTemp != null)
                            {
                                int count = ((Curso)val).Alumnos.Count;
                                Console.WriteLine("Curso: " + val.Nombre + " Cantidad de Alumnos: " + count);
                            }
                            break;
                        default:
                            Console.WriteLine(val);
                            break;
                    }

                }
            }
        }
    }
}