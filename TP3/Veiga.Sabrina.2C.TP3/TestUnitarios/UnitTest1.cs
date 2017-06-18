using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Corrobora que las listas de universidad estén correctamente instanciadas
        /// </summary>
        [TestMethod]
        public void ListaCorrecta()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
        }

        /// <summary>
        /// Verifica la validacion de dni con respecto a la nacionalidad argentina
        /// </summary>
        [TestMethod]
        public void ValidacionDniArgentino()
        {
            try
            {
                Alumno alumnito = new Alumno(12, "Juan", "Perez", "32243204", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
        /// <summary>
        /// Verifica la validacion de dni con respecto a la nacionalidad extranjera
        /// </summary>
        [TestMethod]
        public void ValidacionDniExtranjero()
        {
            try
            {
                Profesor profe = new Profesor(1, "Juan", "Lopez", "92234456", Persona.ENacionalidad.Argentino);
                Assert.Fail("Profesor argentino con DNI extranjero");
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        /// <summary>
        /// Verifica la excepcion por dni con longitud invalida
        /// </summary>
        [TestMethod]
        public void ValidacionDniLongitud()
        {
            try
            {
                Alumno alumnito = new Alumno(12, "Juan", "Perez", "322439204", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Verifica la excepcion por dni invalido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidacionDniLetras()
        {
            Alumno alumnito = new Alumno(12, "Juan", "Perez", "32a439204", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
        }

        /// <summary>
        /// Verifica que elimine correctamente los caracteres especiales
        /// </summary>
        [TestMethod]
        public void ValidacionDniCaracterEspecial()
        {
            string dniString = "32.292 404-";

            Alumno alumnito = new Alumno(12, "Juan", "Perez", dniString, Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            Assert.AreEqual(32292404, alumnito.DNI);
        }
    }

}

