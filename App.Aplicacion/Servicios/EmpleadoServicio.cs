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
    public class EmpleadoServicio
    {
        readonly IEmpleadoRepositorio _empleadoRepositorio;
        public EmpleadoServicio()
        {
            _empleadoRepositorio = new EmpleadoRepositorioImpl();
        }

        public void insertarEmpleado(Empleado empleado)
        {
            try
            {
                _empleadoRepositorio.Add(empleado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void actualizarEmpleado(Empleado empleado)
        {
            try
            {
                _empleadoRepositorio.Modify(empleado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminarEmpleado(int id)
        {
            try
            {
                _empleadoRepositorio.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Empleado> obtenerEmpleados()
        {
            try
            {
                return _empleadoRepositorio.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Empleado obtenerEmpleadoPorId(int id)
        {
            try
            {
                return _empleadoRepositorio.GetById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
