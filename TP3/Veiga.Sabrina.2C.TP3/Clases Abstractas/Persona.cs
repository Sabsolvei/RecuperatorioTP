using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    [Serializable()]
    [XmlInclude(typeof(Universitario))]
    //[XmlInclude(typeof(Alumno)), XmlInclude(typeof(Profesor))]
    public abstract class Persona
    {
        #region ATRIBUTOS / ENUM

        /// <summary>
        /// Enumerado de nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        string _nombre;
        string _apellido;
        int _dni;
        ENacionalidad _nacionalidad;

        #endregion

        #region CONSTRUCTORES
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region PROPIEDADES
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = Persona.ValidarNombreApellido(value);
            }
        }
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = Persona.ValidarNombreApellido(value);
            }
        }


        #endregion

        #region VALIDACIONES
        /// <summary>
        /// Validará que el DNI esté dentro de los rangos permitidos
        /// </summary>
        /// <param name="dato">DNI numérico a validar</param>
        /// <returns>DNI validado si está todo OK, o 0 (cero) en caso de error</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException(dato.ToString());
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Validará que el DNI sea solo numérico y tenga la longitud correcta
        /// </summary>
        /// <param name="dato">DNI string a validar</param>
        /// <returns>Retorna DNI validado si está todo OK, de lo contrario lanza una excepción</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numeroDni;
            dato = dato.Replace(".", "");
            dato = dato.Replace("-", "");
            dato = dato.Replace(",", "");
            dato = dato.Replace(" ", "");

            if ((dato.Length < 1 || dato.Length > 8) || !(int.TryParse(dato, out numeroDni)))
            {
                throw new DniInvalidoException(dato.ToString());
            }

            return Persona.ValidarDni(nacionalidad, numeroDni);
        }

        /// <summary>
        /// Validará que el nombre esté compuesto solo por caracteres latinos a-z A-Z
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar</param>
        /// <returns>Nombre o apellido validado si está todo OK, o un string vacio en caso de error</returns>
        private static string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");
            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        }
        #endregion


        /// <summary>
        /// Retorna los datos de Persona en string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("NOMBRE COMPLETO: {1}, {0}", this._nombre, this._apellido));
            sb.AppendLine(string.Format("NACIONALIDAD: {0}", this._nacionalidad));
            return sb.ToString();
        }
    }
}
