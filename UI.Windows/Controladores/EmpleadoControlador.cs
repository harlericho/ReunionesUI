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
    public class EmpleadoControlador
    {
        readonly EmpleadoServicio _empleadoServicio;
        public EmpleadoControlador()
        {
            _empleadoServicio = new EmpleadoServicio();
        }

        public bool AgregarEmpleado(EmpleadoVistaModelo empleadoVistaModelo)
        {
            Empleado nuevo = new Empleado();
            try
            {
                nuevo.Nombre = empleadoVistaModelo.Nombre_empleado;
                nuevo.Departamento = empleadoVistaModelo.Departamento_empleado;
                nuevo.CorreoElectronico = empleadoVistaModelo.CorreoElectronico_empleado;
                _empleadoServicio.insertarEmpleado(nuevo);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool ActualizarEmpleado(EmpleadoVistaModelo empleadoVistaModelo)
        {
            Empleado actualizado = new Empleado();
            try
            {
                actualizado.ID = empleadoVistaModelo.ID_empleado;
                actualizado.Nombre = empleadoVistaModelo.Nombre_empleado;
                actualizado.Departamento = empleadoVistaModelo.Departamento_empleado;
                actualizado.CorreoElectronico = empleadoVistaModelo.CorreoElectronico_empleado;
                _empleadoServicio.actualizarEmpleado(actualizado);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool EliminarEmpleado(int id)
        {
            try
            {
                _empleadoServicio.eliminarEmpleado(id);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
 
        public IEnumerable<EmpleadoVistaModelo> ListarEmpleados()
        {
            var lista = _empleadoServicio.obtenerEmpleados();
            List<EmpleadoVistaModelo> vista = new List<EmpleadoVistaModelo>();
            foreach (var item in lista)
            {
                EmpleadoVistaModelo empleado = new EmpleadoVistaModelo();
                empleado.ID_empleado = item.ID;
                empleado.Nombre_empleado = item.Nombre;
                empleado.Departamento_empleado = item.Departamento;
                empleado.CorreoElectronico_empleado = item.CorreoElectronico;
                vista.Add(empleado);
            }
            return vista;
        }
        public IEnumerable<EmpleadoVistaModelo> mostrarListadosEmpeladosCombo()
        {
            var lista = _empleadoServicio.obtenerEmpleados();
            List<EmpleadoVistaModelo> listaVista = new List<EmpleadoVistaModelo>();
            foreach (var item in lista)
            {
                EmpleadoVistaModelo empleado = new EmpleadoVistaModelo();
                empleado.ID_empleado = item.ID;
                empleado.Id_nombre_empleado = item.ID + " - " + item.Nombre;
                listaVista.Add(empleado);
            }
            return listaVista;
        }
    }
}
