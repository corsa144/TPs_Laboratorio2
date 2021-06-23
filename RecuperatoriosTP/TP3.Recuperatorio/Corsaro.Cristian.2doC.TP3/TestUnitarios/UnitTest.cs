using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Valida que el precio sea mayor 0
        /// </summary>
        [TestMethod]
        public void ValidacionPrecioTest()
        {
            //arrange
            double precio=15;
            Producto producto = new Celular();
            //act
            producto.Costo = precio;
            //assert
            Assert.AreEqual(producto.Costo, 15);
        }

        /// <summary>
        /// Test
        /// Comprueba que al intentar instanciar un objeto del tipo Profesor 
        /// cuando el numero de DNI no se encuentra en el rango esperado por su nacionalidad
        /// se debe lanzar la Exception : "NacionalidadInvalidaException"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NombreProductoExeption))]
        public void CompruebaNombreDelProductoValido()
        {
            //Arrange
            Celular c = null;

            //Act
            c = new Celular(123, "456*!!!¿¿Lenovo123", 20000 ,Celular.SistemaOperativo.Android,true);
            //Assert 
            
        }
    }
}
