using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandchips.Models
{
   public class ModelHotel
    {
       public int IdReservacionHotel { get; set; } 
        public string FechaIngreso { get; set; }
        public string FechaSalida { get; set; }
        public int IdClientes { get; set; }
        public string Clientes { get; set; }
        public double Precio { get; set; }
        public int IdHabitaciones { get; set; }
        public string Habitaciones { get; set; } 
        public int IdEstadoReservacion { get; set; }

    }
}
