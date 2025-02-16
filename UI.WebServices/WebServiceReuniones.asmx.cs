using App.Aplicacion.Servicios;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UI.WebServices.VistaModelo;

namespace UI.WebServices
{
    /// <summary>
    /// Descripción breve de WebServiceReuniones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceReuniones : System.Web.Services.WebService
    {
        private EmpleadoServicio _empleadoServicio;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public bool AgregarEmpleado(EmpleadoVistaModelo empleadoVistaModelo)
        {
            _empleadoServicio = new EmpleadoServicio();
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
        [WebMethod]
        public bool ActualizarEmpleado(EmpleadoVistaModelo empleadoVistaModelo)
        {
            _empleadoServicio = new EmpleadoServicio();
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
        [WebMethod]
        public bool EliminarEmpleado(int id)
        {
            _empleadoServicio = new EmpleadoServicio();
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
        [WebMethod]
        public List<EmpleadoVistaModelo> ListarEmpleados()
        {
            _empleadoServicio = new EmpleadoServicio();
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
    }
}
