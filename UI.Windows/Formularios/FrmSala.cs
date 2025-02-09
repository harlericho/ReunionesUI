using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Windows.Controladores;
using UI.Windows.VistaModelo;

namespace UI.Windows.Formularios
{
    public partial class FrmSala : Form
    {
        readonly SalaControlador _salaControlador;
        private SalaVistaModelo _salaVistaModelo;
        public FrmSala()
        {
            InitializeComponent();
            _salaControlador = new SalaControlador();
            _salaVistaModelo = new SalaVistaModelo();
        }
        public void cargarDatos()
        {
            dgvLista.DataSource = _salaControlador.ListarSala();
        }
        public void guardarDatos()
        {
            _salaVistaModelo.Nombre_sala = txtNombre.Text;
            _salaVistaModelo.Capacidad_sala = int.Parse(txtCapacidad.Text);
            _salaVistaModelo.Ubicacion_sala = txtUbicacion.Text;
            bool resultado = _salaControlador.AgregarSala(_salaVistaModelo);
            if (resultado)
            {
                MessageBox.Show("Sala agregado correctamente");
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Error al agregar empleado");
            }
        }
        public void actualizarDatos()
        {
            _salaVistaModelo.ID_sala = Convert.ToInt32(txtId.Text);
            _salaVistaModelo.Nombre_sala = txtNombre.Text;
            _salaVistaModelo.Capacidad_sala = int.Parse(txtCapacidad.Text);
            _salaVistaModelo.Ubicacion_sala = txtUbicacion.Text;
            bool resultado = _salaControlador.ActualizarSala(_salaVistaModelo);
            if (resultado)
            {
                MessageBox.Show("Sala actualizado correctamente");
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar sala");
            }
        }
        public void eliminarDatos()
        {
            int id = Convert.ToInt32(txtId.Text);
            bool resultado = _salaControlador.EliminarSala(id);
            if (resultado)
            {
                MessageBox.Show("Sala eliminado correctamente");
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Error al eliminar empleado");
            }
        }
        public void limpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtCapacidad.Text = "";
            txtUbicacion.Text = "";
            dgvLista.AccessibilityObject.Value = "";
        }
        private void dgvLista_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvLista.SelectedRows.Count > 0)
            {
                txtId.Text = dgvLista.SelectedRows[0].Cells["ID_sala"].Value.ToString();
                txtNombre.Text = dgvLista.SelectedRows[0].Cells["Nombre_sala"].Value.ToString();
                txtCapacidad.Text = dgvLista.SelectedRows[0].Cells["Capacidad_sala"].Value.ToString();
                txtUbicacion.Text = dgvLista.SelectedRows[0].Cells["Ubicacion_sala"].Value.ToString();
                btnAceptar.Text = "Actualizar";
            }
            else
            {
                MessageBox.Show("Seleccione un empleado");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedRows.Count > 0)
            {
                eliminarDatos();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione un empleado");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            btnAceptar.Text = "Agregar";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                guardarDatos();
            }
            else
            {
                actualizarDatos();
            }
            limpiarCampos();
            btnAceptar.Text = "Agregar";
        }

        private void FrmSala_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
