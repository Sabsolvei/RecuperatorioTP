using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace EntidadesAbstractas
{
    public class Jornada
    {
//Atributos Profesor, Clase y Alumnos que toman dicha clase.
//Se inicializará la lista de alumnos en el constructor por defecto.
//Una Jornada será igual a un Alumno si el mismo participa de la clase.
//Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
//ToString mostrará todos los datos de la Jornada.
//Guardar de clase guardará los datos de la Jornada en un archivo de texto.
//Leer de clase retornará los datos de la Jornada como texto.

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }
        
        public Profesor Instructor
        {
            get { return _instructor; }
            set { _instructor = value; }
        }
        #endregion

        #region CONSTRUCTORES
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region METODOS SOBRECARGAS
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a != j._clase);
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno alum in j._alumnos)
            {
                if (alum == a)
                    return j;
            }
            j._alumnos.Add(a);
            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this._clase, _instructor.ToString());
            foreach (Alumno alum in this._alumnos)
            {
                sb.AppendFormat(alum.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region ARCHIVOS

        public bool Guardar(Jornada jornada)
        {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "ListaUniversitario.txt"))
            {
                sw.WriteLine(jornada);
            }
            return true;
        }

        public string Leer()
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "ListaUniversitario.txt"))
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "ListaUniversitario.txt"))
                {
                    sb.AppendFormat(sr.ReadToEnd());
                }
            }
            return sb.ToString();
        }

        #endregion

    }
}
