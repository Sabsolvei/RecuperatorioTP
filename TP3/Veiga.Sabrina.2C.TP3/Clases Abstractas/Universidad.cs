using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public class Universidad
    {
/////////Atributos Alumnos (lista de inscriptos), Profesores (lista de quienes pueden dar clases) y Jornadas.
/////////Se accederá a una Jornada específica a través de un indexador.
/////////Un Universidad será igual a un Alumno si el mismo está inscripto en él.
/////////Un Universidad será igual a un Profesor si el mismo está dando clases en él.
/////////La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. Sino, lanzará la Excepción SinProfesorException. El distinto retornará el primer Profesor que no pueda dar la clase.
//Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
/////////Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.

//MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante ToString.
//Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
//Leer de clase retornará un Universidad con todos los datos previamente serializados. Archivos:
//Generar una interfaz con las firmas para guardar y leer.
//Implementar la interfaz en las clases Xml y Texto, a fin de poder guardar y leer archivos de esos tipos.
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        #region CONSTRUCTORES
        public Universidad()
        { }
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
            get { return _jornada[i]; }
            set { _jornada[i] = value; }
        }
        #endregion

        #region METODOS SOBRECARGAS

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool igualdad = false;
            foreach (Alumno alum in g._alumnos)
            {
                if (a == alum)
                {
                    igualdad = true;
                    break;
                } 
            }
            return igualdad;  
        }

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

        public static bool operator !=(Universidad g, Alumno a)
        { return !(g == a); }

        public static bool operator !=(Universidad g, Profesor i)
        { return !(g == i); }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor prof in g._profesores)
            {
                if (prof != clase)
                {
                    return prof;
                }
            }
            throw new SinProfesorException(); //AGREGAR VALIDACION ACORDE
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g._alumnos.Add(a);
            }
            else 
            {
                throw new AlumnoRepetidoException();
            }
            return g; 
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (!(g == i))
            {
                g._profesores.Add(i);
            }
            return g; 
        }

        //Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
        //un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
        public static Universidad operator +(Universidad g, EClases clase)
        { 
            return g; 
        }

        private string MostrarDatos()
        { 
            return ""; 
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
        
        #region METODOS

        public bool Guardar(Universidad gim)
        {
            return true;
        }
        
        #endregion


    }
}
