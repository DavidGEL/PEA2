using PEA2.Data;
using PEA2.Domain;
using System.Collections.Generic;
using System.Text;

namespace PEA2.Logic
{
    public static class ProductoBL
    {
        public static List<Producto> Listar()
        {
            var productoData = new ProductoData();
            return productoData.Listar();
        }
        public static Producto BuscarPorId(int IdProducto)
        {
            var productoData = new ProductoData();
            return productoData.BuscarId(IdProducto);
        }
        public static bool Actualizar(Producto producto)
        {
            var productoData = new ProductoData();
            return productoData.Actualizar(producto);
        }
        public static bool Insertar(Producto producto)
        {
            var productoData = new ProductoData();
            return productoData.Insertar(producto);
        }
        public static bool Eliminar(int IdProducto)
        {
            var productoData = new ProductoData();
            return productoData.Eliminar(IdProducto);
        }
    }
}
