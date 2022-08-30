using PEA2.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PEA2.Data
{
    public class CategoriaData
    {
        string cadenaConexion = "server=localhost; database=Parcial;Integrated security=true";
        public List<Categoria> Listar()
        {
            var listado = new List<Categoria>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("select * from Categoria", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Categoria categoria;
                            while (lector.Read())
                            {
                                categoria = new Categoria();
                                categoria.IdCategoria = int.Parse(lector[0].ToString());
                                categoria.CodigoCategoria = lector[1].ToString();
                                categoria.Nombre = lector[2].ToString();
                                categoria.Observacion = lector[3].ToString();
                                

                                listado.Add(categoria);
                            }
                        }
                    }
                }
            }
            return listado;
        }
    }

}

