using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test
        /// Comprueba que al intentar instanciar un objeto del tipo Profesor 
        /// cuando el numero de DNI no se encuentra en el rango esperado por su nacionalidad
        /// se debe lanzar la Exception : "NacionalidadInvalidaException"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void CompruebaInstanciaProfesorNacionalidadInvalida()
        {
            //Arrange
            Profesor p1 = null;

            //Act
            p1 = new Profesor(123, "Esteban", "Wick", "15432785", Persona.ENacionalidad.Extranjero);
            //Assert 

        }

        /// <summary>
        /// Test
        /// Comprueba que al intentar buscar un Profesor para dar una clase y no haya ninguno capaz de darla
        /// se debe lanzar una Exception "SinProfesorException"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void CompruebaxExcepcionSinProfesor()
        {
            //Arrange
            Universidad u = new Universidad();
            Universidad.EClases nuevaClase;
            Profesor p = null;

            //Act
            nuevaClase = Universidad.EClases.SPD;
            p = (u == nuevaClase);

            //Assert 
        }

        /// <summary>
        /// Comprueba al intentar instanciar un objeto de tipo Profesor(Persona) pasando
        /// por parametro de DNI una cadena de texto que no se pueda convertir a numero
        /// se debe lanzar la Exception "DNIInvalidoExcepcion"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DNIInvalidoExcepcion))]
        public void CompruebaFomatoDeDniInvalido()
        {
            //Arrange
            Profesor p1 = null;

            //Act
            p1 = new Profesor(1, "Santiago", "Gimennez", "83456jbc", Persona.ENacionalidad.Argentino);

            //Assert Exception.
        }

        /// <summary>
        /// Comprueba que se agrega una instancias de Alumno y otra de Profesor en las listas
        /// Comprueba que se agrega jornada y un alumno en ella.
        /// de la Universidad, efectivamente se ingresen a las respectivas listas.
        /// </summary>
        [TestMethod]

        public void CompruebaInstanciaListaDeAlumnosEnUniversidad()
        {
            //Arrange
            Universidad uni = new Universidad();
            Alumno a = new Alumno(1, "Federico", "Sanchez", "09345678",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Profesor p = new Profesor(2, "Samuel", "Corsaro", "29432542",
                Persona.ENacionalidad.Argentino);
            Jornada j = new Jornada(Universidad.EClases.Laboratorio, p);
            
            //Act
            uni += a;
            uni += p;
            j += a;
            //Assert Exception.
            Assert.AreEqual(1, uni.Alumnos.Count);
            Assert.AreEqual(1, uni.Instructores.Count);
            Assert.AreEqual(1, j.Alumnos.Count);
            Assert.AreEqual(j, j);
        }

    }
}
