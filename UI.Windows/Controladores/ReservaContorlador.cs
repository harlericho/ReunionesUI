using App.Aplicacion.Servicios;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Windows.VistaModelo;

namespace UI.Windows.Controladores
{
    public class ReservaContorlador
    {
        readonly ReservaServicio _reservaServicio;
        public ReservaContorlador()
        {
            _reservaServicio = new ReservaServicio();
        }
        public bool AgregarReserva(ReservaVistaModelo reservaVistaModelo)
        {
            Reserva nuevo = new Reserva();
            try
            {
                nuevo.Fecha = reservaVistaModelo.Fecha_reserva;
                nuevo.HoraInicio = reservaVistaModelo.HoraInicio_reserva;
                nuevo.HoraFin = reservaVistaModelo.HoraFin_reserva;
                nuevo.IDSala = reservaVistaModelo.IDSala_reserva;
                nuevo.IDEmpleado = reservaVistaModelo.IDEmpleado_reserva;
                _reservaServicio.insertarReserva(nuevo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool ActualizarReserva(ReservaVistaModelo reservaVistaModelo)
        {
            Reserva actualizado = new Reserva();
            try
            {
                actualizado.ID = reservaVistaModelo.ID_reserva;
                actualizado.Fecha = reservaVistaModelo.Fecha_reserva;
                actualizado.HoraInicio = reservaVistaModelo.HoraInicio_reserva;
                actualizado.HoraFin = reservaVistaModelo.HoraFin_reserva;
                actualizado.IDSala = reservaVistaModelo.IDSala_reserva;
                actualizado.IDEmpleado = reservaVistaModelo.IDEmpleado_reserva;
                _reservaServicio.actualizarReserva(actualizado);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool EliminarReserva(int id)
        {
            try
            {
                _reservaServicio.eliminarReserva(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public IEnumerable<ReservaVistaModelo> ListarReserva()
        {
            List<ReservaVistaModelo> lista = new List<ReservaVistaModelo>();
            try
            {
                var reservas = _reservaServicio.obtenerReservas();
                foreach (var item in reservas)
                {
                    ReservaVistaModelo reserva = new ReservaVistaModelo();
                    reserva.ID_reserva = item.ID;
                    reserva.Fecha_reserva = item.Fecha;
                    reserva.HoraInicio_reserva = item.HoraInicio;
                    reserva.HoraFin_reserva = item.HoraFin;
                    reserva.IDSala_reserva = item.IDSala;
                    reserva.IDEmpleado_reserva = item.IDEmpleado;
                    lista.Add(reserva);
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return lista;
            }
        }
        public IEnumerable<dynamic> mostrarNombreSalaEmpleadoDynamic()
        {
            try
            {
                return _reservaServicio.mostrarNombreSalaEmpleadoDynamic();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
