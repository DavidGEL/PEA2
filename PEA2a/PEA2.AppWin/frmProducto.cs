using PEA2.Domain;
using PEA2.Logic;
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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            var listado = ProductoBL.Listar();
            dgvDatos.Rows.Clear();
            foreach(var producto in listado)
            {
                dgvDatos.Rows.Add(producto.IdProducto,producto.Nombre,producto.Marca,producto.Precio,
                    producto.Stock,producto.IdCategoria);
            }
        }

        private void NuevoRegistro(object sender, EventArgs e)
        { 
        var nuevoProducto = new Producto();
        var frm = new frmProductoEdit(nuevoProducto);
            if(frm.ShowDialog()==DialogResult.OK)
            {
                var exito = ProductoBL.Insertar(nuevoProducto);
                if (exito)
                {
                    MessageBox.Show("El Producto ha sido registrado correctamente", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
    }
                else
                {
                    MessageBox.Show("El Producto no se ha registrado", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditarRegistro(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                int filaAcutal = dgvDatos.CurrentRow.Index;
                var idProducto = int.Parse(dgvDatos.Rows[filaAcutal].Cells[0].Value.ToString());
                var ProductoEditar = ProductoBL.BuscarPorId(idProducto);
                var frm = new frmProductoEdit(ProductoEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ProductoBL.Actualizar(ProductoEditar);
                    if (exito)
                    {
                        MessageBox.Show("El Producto ha sido Actualizado correctamente", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("El Producto no se ha Actualizado", "Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EliminarRegistro(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                int filaActual = dgvDatos.CurrentRow.Index;
                var idProducto = int.Parse(dgvDatos.Rows[filaActual].Cells[0].Value.ToString());
                var Nombre = dgvDatos.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("¿Realmente desea eliminar al Producto " + Nombre + "?", "Producto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    var exito = ProductoBL.Eliminar(idProducto);
                    if (exito)
                    {
                        MessageBox.Show("El Producto ha sido eliminado", "Producto", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
