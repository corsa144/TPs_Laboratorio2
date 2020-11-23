using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

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
    }
}
