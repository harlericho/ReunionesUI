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
    public partial class FrmReserva : Form
    {

        readonly ReservaContorlador _reservacionControlador;
        readonly EmpleadoControlador _empleadoControlador;
        readonly SalaControlador _salaControlador;
        readonly ReservaContorlador _reservaCointrolador;
        private ReservaVistaModelo _reservaVistaModelo;
        public FrmReserva()
        {
            InitializeComponent();
            _reservacionControlador = new ReservaContorlador();
            _reservaVistaModelo = new ReservaVistaModelo();
            _reservacionControlador = new ReservaContorlador();
            _empleadoControlador = new EmpleadoControlador();
            _salaControlador = new SalaControlador();
        }
        public void cargarDatos()
        {
            dgvLista.DataSource = _reservacionControlador.mostrarNombreSalaEmpleadoDynamic();
        }
        public void cargarListaEmpleados()
        {
            cmbEmpleado.DataSource = _empleadoControlador.mostrarListadosEmpeladosCombo();
            cmbEmpleado.DisplayMember = "Id_nombre_empleado";
            cmbEmpleado.ValueMember = "ID_empleado";
        }
        public void cargarListaSalas()
        {
            cmbSala.DataSource = _salaControlador.mostrarListadosSalasCombo();
            cmbSala.DisplayMember = "Id_nombre_sala";
            cmbSala.ValueMember = "ID_sala";
        }
        private void dgvLista_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvLista.SelectedRows.Count > 0)
            {
                txtId.Text = dgvLista.SelectedRows[0].Cells["ID"].Value.ToString();
                dtpFecha.Text = dgvLista.SelectedRows[0].Cells["Fecha"].Value.ToString();
                dtpHoraInicio.Text = dgvLista.SelectedRows[0].Cells["HoraInicio"].Value.ToString();
                dtpHoraFin.Text = dgvLista.SelectedRows[0].Cells["HoraFin"].Value.ToString();
                cmbSala.Text = dgvLista.SelectedRows[0].Cells["NombreSala"].Value.ToString();
                cmbEmpleado.Text = dgvLista.SelectedRows[0].Cells["NombreEmpleado"].Value.ToString();
                btnAceptar.Text = "Actualizar";
            } else
            {
                MessageBox.Show("Seleccione una reserva");
            }
        }

        private void FrmReserva_Load(object sender, EventArgs e)
        {
            cargarDatos();
            cargarListaEmpleados();
            cargarListaSalas();
        }
        public void guardarDatos()
        {
            dtpHoraFin.Value = dtpHoraInicio.Value.AddMinutes(30);

            _reservaVistaModelo.Fecha_reserva = Convert.ToDateTime(dtpFecha.Text);
            _reservaVistaModelo.HoraInicio_reserva = dtpHoraInicio.Value.TimeOfDay;
            _reservaVistaModelo.HoraFin_reserva = dtpHoraFin.Value.TimeOfDay;
            _reservaVistaModelo.IDSala_reserva = Convert.ToInt32(cmbSala.SelectedValue);
            _reservaVistaModelo.IDEmpleado_reserva = Convert.ToInt32(cmbEmpleado.SelectedValue);
            bool resultado = _reservacionControlador.AgregarReserva(_reservaVistaModelo);
            if (resultado)
            {
                MessageBox.Show("Reserva agregado correctamente");
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Error al agregar reserva");
            }
        }
        public void actualizarDatos()
        {
            dtpHoraFin.Value = dtpHoraInicio.Value.AddMinutes(30);
            _reservaVistaModelo.ID_reserva = Convert.ToInt32(txtId.Text);
            _reservaVistaModelo.Fecha_reserva = Convert.ToDateTime(dtpFecha.Text);
            _reservaVistaModelo.HoraInicio_reserva = dtpHoraInicio.Value.TimeOfDay;
            _reservaVistaModelo.HoraFin_reserva = dtpHoraFin.Value.TimeOfDay;
            _reservaVistaModelo.IDSala_reserva = Convert.ToInt32(cmbSala.SelectedValue);
            _reservaVistaModelo.IDEmpleado_reserva = Convert.ToInt32(cmbEmpleado.SelectedValue);
            bool resultado = _reservacionControlador.ActualizarReserva(_reservaVistaModelo);
            if (resultado)
            {
                MessageBox.Show("Reserva actualizado correctamente");
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Error al actualizar reserva");
            }
        }
        public void eliminarDatos()
        {
            int id = Convert.ToInt32(txtId.Text);
            bool resultado = _reservacionControlador.EliminarReserva(id);
            if (resultado)
            {
                MessageBox.Show("Reserva eliminado correctamente");
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Error al eliminar reserva");
            }
        }
        public void limpiarCampos()
        {
            txtId.Text = "";
            dtpFecha.Value = DateTime.Now;
            dtpHoraInicio.Value = DateTime.Now;
            dtpHoraFin.Value = DateTime.Now;
            cmbSala.SelectedIndex = 0;
            cmbEmpleado.SelectedIndex = 0;
            dgvLista.AccessibilityObject.Value = "";
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
