using ClasesBase.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase.utils
{
    public class Conversion
    {
        public static List<Reserva> DataTableALista(DataTable dataTable)
        {
            List<Reserva> list = new List<Reserva>();
           foreach (DataRow dr in dataTable.Rows)
            {
                Reserva reserva = new Reserva();
                reserva.IdReserva = int.Parse(dr["idReserva"].ToString());
                reserva.HoraInicio = DateTime.Parse(dr["horaInicio"].ToString());
                reserva.HoraFin = DateTime.Parse(dr["horaFinalizacion"].ToString());
                reserva.DniCliente = int.Parse(dr["dni"].ToString());
                reserva.IdCancha = int.Parse(dr["idCancha"].ToString());
                reserva.Fecha = DateTime.Parse(dr["fecha"].ToString());
                list.Add(reserva);
            }
           return list;
        }
    }
}
