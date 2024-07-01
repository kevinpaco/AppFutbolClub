using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase.models
{
    public class Alquiler
    {
        private float monto;
        private int cantHoras;
        private string medioPago;
        private DateTime fecha;
        private int idReserva;

        public Alquiler() { }

        public Alquiler(float monto, int cantHoras, string medioPago, DateTime fecha, int idReserva)
        {
            this.monto = monto;
            this.cantHoras = cantHoras;
            this.medioPago = medioPago;
            this.fecha = fecha;
            this.idReserva = idReserva;
        }

        public float Monto { 
            get { return monto; }
            set { monto = value; }
        }

        public int CantHoras
        {
            get { return cantHoras; }
            set { cantHoras = value; }
        }

        public string MedioPago
        {
            get { return medioPago; }
            set { medioPago = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int IdReserva
        {
            get { return idReserva; }
            set { idReserva = value; }
        }
    }
}
