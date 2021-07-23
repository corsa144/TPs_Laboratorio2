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
        /// Valida que el costo sea mayor 0
        /// </summary>
        [TestMethod]
        public void ValidacionCostoTest()
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
        /// Comprueba que al intentar instanciar un objeto del tipo Producto 
        /// cuando el nombre del mismo se no son solo letras
        /// se debe lanzar la Exception : "NombreProductoException"
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

        /// <summary>
        /// Valida que el formateo sea correcto.
        /// </summary>
        [TestMethod]
        public void FormatoCostoTest()
        {
            //arrange
            double costo = 16089.50;
            //act
            string resultado = ExtensionCosto.FormatearCosto(costo);
            //assert
            Assert.AreEqual(resultado, "16089.50");
        }
    }
}
