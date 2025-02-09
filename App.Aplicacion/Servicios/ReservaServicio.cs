using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using Infraestructura.AccesoDatos.Repositorio.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Aplicacion.Servicios
{
    public class ReservaServicio
    {
        readonly IReservaRepositorio _reservaRepositorio;

        public ReservaServicio()
        {
            _reservaRepositorio = new ReservaRepositorioImpl();
        }
        public void insertarReserva(Reserva reserva)
        {
            try
            {
                _reservaRepositorio.Add(reserva);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void actualizarReserva(Reserva reserva)
        {
            try
            {
                _reservaRepositorio.Modify(reserva);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminarReserva(int id)
        {
            try
            {
                _reservaRepositorio.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Reserva> obtenerReservas()
        {
            try
            {
                return _reservaRepositorio.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<dynamic> mostrarNombreSalaEmpleadoDynamic()
        {
            try
            {
                return _reservaRepositorio.mostrarNombreSalaEmpleadoDynamic();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
