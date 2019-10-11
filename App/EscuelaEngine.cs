using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entities;
using CorEscuela.Entities.Enum;

namespace CorEscuela.App
{

    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            this.Inicializate();
        }

        public void Inicializate()
        {
            Escuela = new Escuela("Escuela Platzi", 2006, TipoEscuelas.PreEscolar, pais: "Colombia", ciudad: "Bogotá");

            CargarCursos();

            CargarAsignaturas();

            CargarEvaluaciones();



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
            float result = (float)Math.Round(rand.NextDouble() * 5, 2);
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

        #endregion


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

        public Dictonary<string, IEnumerable<ObjetoEscuelaBase>> GetDictionaryObject()
        {
            var dictionary = new Dictionary<string, IEnumerable<ObjetoEscuelaBase>>();

            o = c.Cast<ObjetoEscuelaBase>();

            dictionary.Add("Escuela", new[]{Escuela});

            dictionary.Add("Cursos", Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            return dictionary;
        }
    }
}