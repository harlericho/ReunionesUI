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
    public class SalaControlador
    {
        readonly SalaServicio _salaServicio;
        public SalaControlador()
        {
            _salaServicio = new SalaServicio();
        }
        public bool AgregarSala(SalaVistaModelo salaVistaModelo)
        {
            Sala nuevo = new Sala();
            try
            {
                nuevo.Nombre = salaVistaModelo.Nombre_sala;
                nuevo.Capacidad = salaVistaModelo.Capacidad_sala;
                nuevo.Ubicacion = salaVistaModelo.Ubicacion_sala;
                _salaServicio.insertarSala(nuevo);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool ActualizarSala(SalaVistaModelo salaVistaModelo)
        {
            Sala actualizado = new Sala();
            try
            {
                actualizado.ID = salaVistaModelo.ID_sala;
                actualizado.Nombre = salaVistaModelo.Nombre_sala;
                actualizado.Capacidad = salaVistaModelo.Capacidad_sala;
                actualizado.Ubicacion = salaVistaModelo.Ubicacion_sala;
                _salaServicio.actualizarSala(actualizado);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool EliminarSala(int id)
        {
            try
            {
                _salaServicio.eliminarSala(id);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<SalaVistaModelo> ListarSala()
        {
            var lista = _salaServicio.obtenerSalas();
            List<SalaVistaModelo> vista = new List<SalaVistaModelo>();
            foreach (var item in lista)
            {
                SalaVistaModelo sala = new SalaVistaModelo();
                sala.ID_sala = item.ID;
                sala.Nombre_sala = item.Nombre;
                sala.Capacidad_sala = item.Capacidad;
                sala.Ubicacion_sala = item.Ubicacion;
                vista.Add(sala);
            }
            return vista;
        }
        public IEnumerable<SalaVistaModelo> mostrarListadosSalasCombo()
        {
            var lista = _salaServicio.obtenerSalas();
            List<SalaVistaModelo> vista = new List<SalaVistaModelo>();
            foreach (var item in lista)
            {
                SalaVistaModelo sala = new SalaVistaModelo();
                sala.ID_sala = item.ID;
                sala.Id_nombre_sala = item.ID + " - " + item.Nombre;
                vista.Add(sala);
            }
            return vista;
        }
    }
}
