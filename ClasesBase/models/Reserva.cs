using ClasesBase.DBConect;
using ClasesBase.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ClasesBase.models
{
    public class Reserva
    {
        private int idReserva;
        private DateTime fecha;
        private DateTime horaInicio;
        private DateTime horaFin;
        private int dniCliente;
        private int idCancha;

        public Reserva() { }
        public Reserva(DateTime fecha, DateTime horaInicio, DateTime horaFin, int dniCliente, int idCancha)
        {
            Fecha = fecha;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.dniCliente = dniCliente;
            this.idCancha = idCancha;
        }

        public int IdReserva
        {
            get { return idReserva; }
            set { idReserva = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public DateTime HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        public DateTime HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }

        public int DniCliente
        {
            get { return dniCliente; }
            set { dniCliente = value; }
        }

        public int IdCancha
        {
            get { return idCancha; }
            set { idCancha = value; }
        }

        public static bool RegistrarReserva(string nombre,int dni,long numeroTelefono,DateTime fecha, 
                                            string horaInicio,string horaFin,string tipoCancha)
        {
            Cliente cliente = new Cliente();
            if (!Cliente.VerificarCLiente(dni))            
               cliente= Cliente.RegistrarCliente(dni, nombre, numeroTelefono);
            
            Cancha cancha = CanchaABM.BuscarCanchaPorTipo(tipoCancha);
            Reserva reserva = new Reserva();
            reserva.horaInicio = DateTime.Parse(horaInicio);
            reserva.horaFin = DateTime.Parse(horaFin);
            reserva.dniCliente = cliente.Dni;
            reserva.idCancha = cancha.IdCacha;
            reserva.fecha = fecha;
            bool result2 = ReservaABM.RegistrarReserva(reserva);
            if (result2)
                 return true;            
           return false;
        }

        public static string VerificarDispinibilidad(DateTime fecha, DateTime horaInicio, 
                                                     DateTime horaFin, string tipoCancha)
        {
            if (Cancha.VerificarDisponibilidad(tipoCancha)=="v")
            {
                DataTable dt = ReservaABM.ListarReservas();
                List<Reserva> reservas = Conversion.DataTableALista(dt)
                                         .Where(reserva => reserva.Fecha.Date.Equals(fecha.Date) &&
                                                            VerificarTipo(reserva.idCancha, tipoCancha))
                                         .ToList();

                foreach (Reserva reserva in reservas)
                {
                    if (!DisponibleEnHorario(horaInicio, horaFin, reserva.horaInicio, reserva.horaFin))
                    { return "cndh"; }// cancha no disponible por horario
                }
                return "disponible";// disponible
            }
            return "cndm";// cancha no disponible
        }

        private static bool VerificarTipo(int idCancha, string tipoCancha)
        {
            Cancha cancha = CanchaABM.BuscarCanchaById(idCancha);
            Console.WriteLine("cancha: " + idCancha);
            if (cancha == null) return false;
            else return cancha.Tipo == tipoCancha;

        }

        private static bool DisponibleEnHorario(DateTime hi, DateTime hf, DateTime hi2, DateTime hf2)
        {
            return hi >= hf2 || hf <= hi2;
        }

     
        public static void ConfeccionarComprobante()
        {
            //Se Genera Comprobante Usando el paquete de ItextSharp
        }
       
        //Retorna si esta disponible en el horario
        /*  private bool DisponibleEnHorario(int hi,int hf,int hi2,int hf2)
          {
              return hi >= hf2 || hf <= hi2;
          }*/
    }
}
