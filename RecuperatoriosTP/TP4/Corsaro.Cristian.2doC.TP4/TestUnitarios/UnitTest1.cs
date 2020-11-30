using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Valida que el formateo sea correcto.
        /// </summary>
        [TestMethod]        
        public void FormatoPrecioTest()
        {
            //arrange
            double precio = 6089.50;
            //act
            string resultado = ExtensionPrecio.FormatearPrecio(precio);
            //assert
            Assert.AreEqual(resultado, "$6089,50");
        }
        /// <summary>
        /// Valida que el precio sea mayor 0
        /// </summary>
        [TestMethod]
        public void ValidacionPrecioTest()
        {
            //arrange
            double precio=15;
            Producto producto = new Producto();
            //act
            producto.Precio = precio;
            //assert
            Assert.AreEqual(producto.Precio, 15);
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
            Producto p = null;

            //Act
            p = new Producto(123, "456Lenovo123", 20000 );
            //Assert 

        }
    }
}
