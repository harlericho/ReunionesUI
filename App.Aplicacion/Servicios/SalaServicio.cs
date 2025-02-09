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
    public class SalaServicio
    {
        readonly ISalaRepositorio _salaRepositorio;
        public SalaServicio()
        {
            _salaRepositorio = new SalaRepositorioImpl();
        }

        public void insertarSala(Sala sala)
        {
            try
            {
                _salaRepositorio.Add(sala);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void actualizarSala(Sala sala)
        {
            try
            {
                _salaRepositorio.Modify(sala);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminarSala(int id)
        {
            try
            {
                _salaRepositorio.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<Sala> obtenerSalas()
        {
            try
            {
                return _salaRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
