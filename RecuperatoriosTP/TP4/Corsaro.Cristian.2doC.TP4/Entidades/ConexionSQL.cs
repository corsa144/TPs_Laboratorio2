using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class ConexionSQL
    {
        private SqlConnection sqlConnection;
        private string connectionString;

        public ConexionSQL()
        {
            this.connectionString = "Server=.;Database=Corsaro.Cristian.2do.TP4;Trusted_Connection=True";
            this.sqlConnection = new SqlConnection(connectionString); //Se encarga de realizar la conexion.
        }

        /// <summary>
        /// Se encarga de insertar en la tabla abriendo previamente la conexion al sql
        /// </summary>
        /// <param name="info">Recibe la informacion que va a insertar</param>
        public void GuardarProducto(Producto info)
        {
            try
            {
                string command = "INSERT INTO Producto (codigo,nombre, precio) " +
                    "VALUES (@codigo, @nombre,@precio)";

                //Para insertar secuencias INSERT en base de datos.
                //Ejecuta comandos en la base de datos.
                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);

                sqlCommand.Parameters.AddWithValue("codigo", info.Codigo); 
                sqlCommand.Parameters.AddWithValue("nombre",info.Nombre);
                sqlCommand.Parameters.AddWithValue("precio", info.Precio);
                //sqlCommand.Parameters.AddWithValue("tipo", info.Tipo);

                //Abrimos la conexion
                this.sqlConnection.Open();

                //Ejecutar sentencias que no son Querys.
                sqlCommand.ExecuteNonQuery(); 
            }
            finally
            {
                if (this.sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Lee un producto de la tabla
        /// </summary>
        /// <returns>Retorna el producto leido</returns>
        public string LeerProducto()
        {
            StringBuilder datos = new StringBuilder();

            try
            {
                string command = "SELECT * FROM Producto";
                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);

                this.sqlConnection.Open();

                SqlDataReader read = sqlCommand.ExecuteReader(); //No se instancia, lo hace el execute. Como el nonquery, pero para leer.
                                                                 //El execute trae los datos y los encapsula en el reader.

                while (read.Read()) //Devuelve true si hay filas, si pudo leer
                { 

                    datos.AppendLine(read.GetString(0));
                }
            }
            finally
            {
                if (this.sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }

            return datos.ToString();
        }

        /// <summary>
        /// Se encarga de insertar en la tabla abriendo previamente la conexion al sql
        /// </summary>
        /// <param name="info">Recibe la informacion que va a insertar</param>
        public void GuardarVenta(Venta info)
        {
            try
            {
                string command = "INSERT INTO Venta (nombreCliente,codigo,nombreProducto,precioProducto) " +
                    "VALUES (@nombreCliente,@codigo,@nombreProducto,@precioProducto)";

                //Para insertar secuencias INSERT en base de datos.
                //Ejecuta comandos en la base de datos.
                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);
                //Lo que esta aca lo va a interpretar como un valor si o si, y no como una secuencia SQL.
                //Lo que pasaria si pusieramos directamente la propiedad.
                sqlCommand.Parameters.AddWithValue("nombreCliente", info.NombreCliente);
                sqlCommand.Parameters.AddWithValue("codigo", info.Codigo);
                sqlCommand.Parameters.AddWithValue("nombreProducto", info.NombreProducto);
                sqlCommand.Parameters.AddWithValue("precioProducto", info.PrecioProducto);

                //Abrimos la conexion
                this.sqlConnection.Open();

                //Ejecutar sentencias que no son Querys.
                sqlCommand.ExecuteNonQuery(); 
            }
            finally
            {
                if (this.sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Lee un venta de la tabla
        /// </summary>
        /// <returns>Retorna el venta leida</returns>
        public Venta LeerVenta()
        {
            Venta datos = new Venta();

            try
            {
                string command = "SELECT * FROM Venta";
                SqlCommand sqlCommand = new SqlCommand(command, this.sqlConnection);

                this.sqlConnection.Open();

                SqlDataReader read = sqlCommand.ExecuteReader(); //No se instancia, lo hace el execute. Como el nonquery, pero para leer.
                                                                 //El execute trae los datos y los encapsula en el reader.

                while (read.Read()) //Devuelve true si hay filas, si pudo leer
                {
                    datos.NombreCliente = read.GetString(0);
                    datos.Codigo = read.GetInt32(1);
                    datos.NombreProducto = read.GetString(2);
                    datos.PrecioProducto = read.GetDouble(3);
                }
            }
            finally
            {
                if (this.sqlConnection != null && this.sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    this.sqlConnection.Close();
                }
            }

            return datos;
        }
    }
}
