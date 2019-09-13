namespace CoreEscuela.Entities
{
    class Escuela
    {
        private string nombre;

        public string Nombre
        {
            get{ return nombre;}

            set{ nombre = value.toUpper();}
        }

        public int AnioDeCreacion{ get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public Escuela(string nombre, int anio)
        {
            this.nombre = nombre;
            this.AnioDeCreacion = anio;
        }
            

    }
}