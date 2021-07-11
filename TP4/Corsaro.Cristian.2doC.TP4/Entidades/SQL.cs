using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SQL
    {
        private SqlConnection sqlConnection;
        private string connectionString;

        public SQL()
        {
            this.connectionString = "Server=.;Database=Corsaro.Cristian.TPFinal;Trusted_Connection=True";
            this.sqlConnection = new SqlConnection(connectionString); //Se encarga de realizar la conexion.
        }

        public bool GuardarSQL(List<Producto> productos)
        {
            //string connectionString = "Server=.;Database=Corsaro.Cristian.TPFinal;Trusted_Connection=True";
            bool seGuardo = false;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string command = "INSERT INTO dbo.productos(id,nombre, costo, calidad,tipoComputadora, sistemaComputadora,sistemaCelular,tipoClase) VALUES ";
                foreach(Producto p in productos)
                {
                    if (p is Celular)
                    {
                        sb.Append($"({p.Codigo},");
                        sb.Append($"'{p.Nombre}',");
                        sb.Append($"{p.Costo},");
                        if (p.PasoControlCalidad)
                        {
                            sb.Append("1,");
                        }
                        else
                        {
                            sb.Append("0,");
                        }
                        sb.Append("NULL,");
                        sb.Append("NULL,");
                        if(((Celular)p).Sistema == Celular.SistemaOperativo.Android)
                        {
                            sb.Append("0,");
                        }
                        else
                        {
                            sb.Append("1,");
                        }
                        sb.Append("1),");//Como voy a identificar a este parametro.
                    }
                    else if (p is Computadora)
                    {
                        sb.Append($"({p.Codigo},");
                        sb.Append($"'{p.Nombre}',");
                        sb.Append($"{ p.Costo},");
                        if (p.PasoControlCalidad)
                        {
                            sb.Append("1,");
                        }
                        else
                        {
                            sb.Append("0,");
                        }
                        if (((Computadora)p).Tipo == Computadora.TipoComputadora.Escritorio)
                        {
                            sb.Append("0,");
                        }
                        else
                        {
                            sb.Append("1,");
                        }
                        if(((Computadora)p).SistemaOperativo == Computadora.ESistemaOperativo.Linux)
                        {
                            sb.Append("0,");
                        }else if(((Computadora)p).SistemaOperativo == Computadora.ESistemaOperativo.OSX)
                        {
                            sb.Append("1,");
                        }else if(((Computadora)p).SistemaOperativo == Computadora.ESistemaOperativo.SinSistemaOperativo)
                        {
                            sb.Append("2,");
                        }
                        else
                        {
                            sb.Append("3,");
                        }
                        sb.Append("NULL,");
                        sb.Append("0),");//Como voy a identificar a este parametro.
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(";");
                command += sb.ToString();
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    seGuardo = true;
                }
                catch (Exception)
                {
                    seGuardo = false;
                }
                return seGuardo;
            }
        }

        public List<Producto> LeerSQL()
        {
            //string connectionString = "Server=.;Database=Corsaro.Cristian.TPFinal;Trusted_Connection=True";
            //StringBuilder log = new StringBuilder();
            List<Producto> p = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string command = "SELECT * FROM dbo.productos";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                //sqlCommand.Parameters.Contains("tipo")
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {

                    //if(!ReferenceEquals(reader,null))
                    if(reader.GetSqlInt32(7) == 1)
                    {
                        bool calidad;
                        if (reader.GetInt32(3) == 0)
                        {
                            calidad = false;
                        }
                        else
                        {
                            calidad = true;
                        }
                        Celular.SistemaOperativo sistemaOperativo;
                        if (reader.GetInt32(6) == 0)
                        {
                            sistemaOperativo = Celular.SistemaOperativo.Android;
                        }
                        else
                        {
                            sistemaOperativo = Celular.SistemaOperativo.IOS;
                        }
                        Celular c = new Celular(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2),
                            sistemaOperativo,calidad);
                        p.Add(c);
                    }else 
                    {
                        bool calidad;
                        if (reader.GetInt32(3) == 0)
                        {
                            calidad = false;
                        }
                        else
                        {
                            calidad = true;
                        }
                        Computadora.TipoComputadora tipo;
                        if (reader.GetInt32(4) == 0)
                        {
                            tipo = Computadora.TipoComputadora.Escritorio;
                        }
                        else
                        {
                            tipo=Computadora.TipoComputadora.Notebook;
                        }
                        Computadora.ESistemaOperativo eSistema;
                        if (reader.GetInt32(5) == 0)
                        {
                            eSistema=Computadora.ESistemaOperativo.Windows;
                        }
                        else if (reader.GetInt32(5) == 1)
                        {
                            eSistema = Computadora.ESistemaOperativo.OSX;
                        }
                        else if (reader.GetInt32(5) == 2)
                        {
                            eSistema = Computadora.ESistemaOperativo.Linux;
                        }
                        else
                        {
                            eSistema = Computadora.ESistemaOperativo.SinSistemaOperativo;
                        }
  
                        Computadora c = new Computadora(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2),
                           tipo, eSistema, calidad);
                        p.Add(c);
                    }
                }
            }
            return p;
            //MessageBox.Show(log.ToString());
        }
    }
}
