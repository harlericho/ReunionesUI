using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Windows.VistaModelo
{
    public class ReservaVistaModelo
    {
        public int ID_reserva { get; set; }
        public int IDSala_reserva { get; set; }
        public int IDEmpleado_reserva { get; set; }
        public System.DateTime Fecha_reserva { get; set; }
        public System.TimeSpan HoraInicio_reserva { get; set; }
        public System.TimeSpan HoraFin_reserva { get; set; }

        // Agrega estas propiedades para nombres
        public string NombreSala_reserva { get; set; }
        public string NombreEmpleado_reserva { get; set; }
    }
}
