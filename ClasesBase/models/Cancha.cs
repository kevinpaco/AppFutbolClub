using ClasesBase.DBConect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase.models
{
    public class Cancha
    {
        private int idCancha;
        private string tipo;
        private string estado;
        private float precio;

        public Cancha() { }
        public Cancha(int idCancha, string tipo, string estado, float precio)
        {
            this.idCancha = idCancha;
            this.tipo = tipo;
            this.estado = estado;
            this.precio = precio;
        }

        public int IdCacha
        {
            get { return idCancha; }
            set { idCancha = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public static string VerificarDisponibilidad(string tipoCancha)
        {
            Cancha cancha= CanchaABM.BuscarCanchaPorTipo(tipoCancha);
            if(cancha.estado == "Disponible")
                return "v";
            else
                return "f";
        }
    }
}
