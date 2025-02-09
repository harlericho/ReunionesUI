using Dominio.Modelo.Abstracciones;
using Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.AccesoDatos.Repositorio.Implementacion
{
    public class ReservaRepositorioImpl: BaseRepositorioImpl<Reserva>, IReservaRepositorio
    {
        public IEnumerable<dynamic> mostrarNombreSalaEmpleadoDynamic()
        {
            try
            {
                using (var context = new DBReunionesEntities())
                {
                    var query = from r in context.Reservas
                                join s in context.Salas on r.IDSala equals s.ID
                                join e in context.Empleados on r.IDEmpleado equals e.ID
                                select new
                                {
                                    r.ID,
                                    r.Fecha,
                                    r.HoraInicio,
                                    r.HoraFin,
                                    NombreSala = s.Nombre,
                                    NombreEmpleado = e.Nombre
                                };
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
