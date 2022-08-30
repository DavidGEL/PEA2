using PEA2.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PEA2.Data
{
    public class ProductoData
    {
        string cadenaConexion = "server=localhost; database=Parcial;Integrated security=true";
        public List<Producto> Listar()
        {
            var listado = new List<Producto>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Producto", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if(lector!=null && lector.HasRows)
                        {
                            Producto producto;
                            while (lector.Read())
                            {
                                producto = new Producto();
                                producto.IdProducto = int.Parse(lector[0].ToString());
                                producto.Nombre = lector[1].ToString();
                                producto.Marca = lector[2].ToString();
                                producto.Precio = decimal.Parse(lector[3].ToString());
                                producto.Stock = int.Parse(lector[4].ToString());
                                producto.IdCategoria = int.Parse(lector[5].ToString());
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Producto BuscarId(int IdProducto)
        {
            Producto producto = new Producto();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("select *from Producto WHERE IdProducto =@IdProducto", conexion))
                {
                    comando.Parameters.AddWithValue("@IdProducto", IdProducto);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            producto = new Producto();
                            producto.IdProducto = int.Parse(lector[0].ToString());
                            producto.Nombre = lector[1].ToString();
                            producto.Marca = lector[2].ToString();
                            producto.Precio = int.Parse(lector[3].ToString());
                            producto.Stock = int.Parse(lector[4].ToString());
                            producto.IdCategoria = int.Parse(lector[5].ToString());

                        }
                    }
                }
            }
            return producto;
        }
        public bool Insertar(Producto producto)
        {
            int filasInsertadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "INSERT INTO Producto (Nombre, Marca, Precio, Stock,IdCategoria )" +
                            "VALUES(@Nombre, @Marca, @Precio, @Stock,@IdCategoria )";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);


                    filasInsertadas = comando.ExecuteNonQuery();
                }
            }
            return filasInsertadas > 0;
        }
        public bool Actualizar(Producto producto)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "UPDATE Producto SET Nombre = @Nombre, Marca = @Marca,Precio = @Precio, Stock = @Stock,IdCategoria=@IdCategoria " +
                   "WHERE IdProducto = @IdProducto";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    comando.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }
        public bool Eliminar(int IdProducto)
        {
            int filasEliminadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "delete from Producto WHERE IdProducto = @IdProducto";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdProducto", IdProducto);
                    filasEliminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEliminadas > 0;
        }
    }
}