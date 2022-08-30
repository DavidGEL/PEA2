using PEA2.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEA2.AppWin
{
    public partial class frmProductoEdit : Form
    {
        Producto producto;
        public frmProductoEdit(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
            if (producto.IdProducto > 0)
            {
                asignarControles();
            }
        }
        private void cargarDatos()
        {

        }

        private void GrabarDatos(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }
        private void asignarObjeto()
        {
            this.producto.Nombre = txtNombre.Text;
            this.producto.Marca = txtMarca.Text;
            this.producto.Precio = decimal.Parse(txtPrecio.Text.ToString());
            this.producto.Stock = int.Parse(txtStock.Text.ToString());
            this.producto.IdCategoria = int.Parse(txtCategoria.Text.ToString());
        }
        private void asignarControles()
        {
            txtNombre.Text = producto.Nombre;
            txtMarca.Text = producto.Marca;
            int.Parse(txtPrecio.Text = producto.Precio.ToString());
            int.Parse(txtStock.Text = producto.Stock.ToString());
            int.Parse(txtCategoria.Text = producto.IdCategoria.ToString());
        }
    }
}
