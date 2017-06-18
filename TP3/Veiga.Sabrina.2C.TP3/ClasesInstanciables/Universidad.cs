using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesAbstractas;
using Archivos;
using System.Xml.Serialization;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region ATRIBUTOS / ENUM

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        #endregion

        #region CONSTRUCTORES

        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();

        }
        #endregion

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return _jornada; }
            set { _jornada = value; }
        }

        public List<Profesor> Instructores
        {
            get { return _profesores; }
            set { _profesores = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i < 0 || i > this._jornada.Count)
                    return null;
                else
                    return this._jornada[i];
            }
            set 
            {
                if (i >= 0 && i < this._jornada.Count)
                    this._jornada[i] = value;
                else if (i == this._jornada.Count)
                    this._jornada.Add(value);
            }
        }
        #endregion

        #region SOBRECARGAS

        /// <summary>
        /// Un Universidad es igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool igualdad = false;
            foreach (Alumno alum in g._alumnos)
            {
                if (alum == a)
                {
                    igualdad = true;
                    break;
                }
            }
            return igualdad;
        }

        /// <summary>
        /// Un Universidad es igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool igualdad = false;
            foreach (Profesor prof in g._profesores)
            {
                if (i == prof)
                {
                    igualdad = true;
                    break;
                }
            }
            return igualdad;
        }

        public static bool operator !=(Universidad g, Alumno a)
        { return !(g == a); }

        public static bool operator !=(Universidad g, Profesor i)
        { return !(g == i); }

        /// <summary>
        /// Agrega un alumno a Universidad validando que no estén previamente cargado
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();

            }
            g._alumnos.Add(a);
            return g;
        }
        /// <summary>
        /// Agrega un profesor a Universidad validando que no estén previamente cargado
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (!(g == i))
            {
                g._profesores.Add(i);
            }
            return g;
        }

        /// <summary>
        /// Retorna el primer Profesor capaz de dar esa clase. Sino, lanza la Excepción SinProfesorException
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor prof in g._profesores)
            {
                if (prof == clase)
                {
                    return prof;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor prof in g._profesores)
            {
                if (prof != clase)
                {
                    return prof;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Genera y agrega nueva jornada a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, (g == clase));

            foreach (Alumno alum in g._alumnos)
            {
                if (alum == clase)
                {
                    j = j + alum;
                }
            }
            g._jornada.Add(j);
            return g;
        }

        public override bool Equals(object obj)
        {
            return this == ((Universidad)obj);
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Retorna string con los datos de Universidad
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad u)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADAS:");
            foreach (Jornada j in u._jornada)
            {
                sb.AppendFormat(j.ToString());

            }

            return sb.ToString();
        }

        /// <summary>
        /// Publica los datos de Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region ARCHIVOS

        /// <summary>
        /// Serializa todos los datos de la clase Universidad en un XML.
        /// </summary>
        /// <param name="gim">Universidad</param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xmlSerializar = new Xml<Universidad>();
            xmlSerializar.Guardar("Universidad.xml", gim);
            return true;
        }

        /// <summary>
        /// Deserializa los datos previamente serializados y retorna una Universidad
        /// </summary>
        /// <returns></returns>
        public static bool Leer(out Universidad univ)
        {
            bool retorno = false;
            Xml<Universidad> xmlDeserializar = new Xml<Universidad>();
            retorno = xmlDeserializar.Leer("Universidad.xml", out univ);
            return retorno;
        }

        #endregion
    }
}
