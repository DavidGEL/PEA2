using PEA2.Data;
using PEA2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PEA2.Logic
{
    public static class CategoriaBL
    {
        public static List<Categoria> Listar()
        {
            var categoriaData = new CategoriaData();
            return categoriaData.Listar();
        }
    }
}
