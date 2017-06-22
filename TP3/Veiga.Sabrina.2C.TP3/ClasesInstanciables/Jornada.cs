using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos =value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        #endregion

        #region CONSTRUCTORES
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region SOBRECARGAS

        /// <summary>
        /// Una Jornada es igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool igualdad = false;
            foreach (Alumno alum in j._alumnos)
            {
                if (alum == j._clase)
                {
                    igualdad = true;
                    break;
                }
            }
            return igualdad;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega Alumnos a la clase, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno alum in j._alumnos)
            {
                if (alum == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            j._alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// Muestra todos los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<------------------------------------------------------------>");
            sb.AppendLine(string.Format("CLASE DE {0} POR {1}", this._clase, _instructor.ToString()));
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno alum in this._alumnos)
            {
                sb.AppendLine(alum.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region ARCHIVOS

        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Retorna los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string datos;
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out datos);
            return datos;
        }
        #endregion

    }
}
