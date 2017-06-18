using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public sealed class Alumno : Universitario
    {

//Atributos ClaseQueToma del tipo EClase y EstadoCuenta del tipo EEstadoCuenta.
//Sobreescribirá el método MostrarDatos con todos los datos del alumno.
//ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
//ToString hará públicos los datos del Alumno.
//Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
//Un Alumno será distinto a un EClase sólo si no toma esa clase.

        public enum EEstadoCuenta { Becado, Deudor, AlDia }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat(ParticiparEnClase());
            sb.AppendFormat("ESTADO DE CUENTA: {0}", this._estadoCuenta);
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + this._claseQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool igualdad = false;
            if (object.ReferenceEquals(a, null) && object.ReferenceEquals(clase, null))
                return false;
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                igualdad = true;
            }
            return igualdad;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a._claseQueToma != clase;
        }
    }
}
