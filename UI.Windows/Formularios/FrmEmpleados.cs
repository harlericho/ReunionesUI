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
    public partial class FrmEmpleados : Form
    {
        readonly EmpleadoControlador _empleadoControlador;
        private EmpleadoVistaModelo _empleadoVistaModelo;
        public FrmEmpleados()
        {
            InitializeComponent();
            _empleadoControlador = new EmpleadoControlador();
            _empleadoVistaModelo = new EmpleadoVistaModelo();
        }
        public void cargarDatos()
        {
            dgvLista.DataSource = _empleadoControlador.ListarEmpleados();
        }
        public void guardarDatos()
        {
            _empleadoVistaModelo.Nombre_empleado = txtNombre.Text;
            _empleadoVistaModelo.Departamento_empleado = txtDepartamento.Text;
            _empleadoVistaModelo.CorreoElectronico_empleado = txtCorreo.Text;
            bool resultado = _empleadoControlador.AgregarEmpleado(_empleadoVistaModelo);
            if (resultado)
            {
                MessageBox.Show("Empleado agregado correctamente");
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Error al agregar empleado");
            }
        }
        public void actualizarDatos()
        {
            _empleadoVistaModelo.ID_empleado = Convert.ToInt32(txtId.Text);
            _empleadoVistaModelo.Nombre_empleado = txtNombre.Text;
            _empleadoVistaModelo.Departamento_empleado = txtDepartamento.Text;
            _empleadoVistaModelo.CorreoElectronico_empleado = txtCorreo.Text;
            bool resultado = _empleadoControlador.ActualizarEmpleado(_empleadoVistaModelo);
            if (resultado)
            {
                MessageBox.Show("Empleado actualizado correctamente");
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar empleado");
            }
        }
        public void eliminarDatos()
        {
            int id = Convert.ToInt32(txtId.Text);
            bool resultado = _empleadoControlador.EliminarEmpleado(id);
            if (resultado)
            {
                MessageBox.Show("Empleado eliminado correctamente");
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
            txtDepartamento.Text = "";
            txtCorreo.Text = "";
            dgvLista.AccessibilityObject.Value = "";
        }
        private void dgvLista_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvLista.SelectedRows.Count > 0)
            {
                txtId.Text = dgvLista.SelectedRows[0].Cells["ID_empleado"].Value.ToString();
                txtNombre.Text = dgvLista.SelectedRows[0].Cells["Nombre_empleado"].Value.ToString();
                txtDepartamento.Text = dgvLista.SelectedRows[0].Cells["Departamento_empleado"].Value.ToString();
                txtCorreo.Text = dgvLista.SelectedRows[0].Cells["CorreoElectronico_empleado"].Value.ToString();
                btnAceptar.Text = "Actualizar";
            }
            else
            {
                MessageBox.Show("Seleccione un empleado");
            }
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            cargarDatos();
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
    }
}
