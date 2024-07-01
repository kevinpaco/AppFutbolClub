using ClasesBase.DBConect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase.models
{
    public class Cliente
    {
        private int dni;
        private string nombre;
        private long numeroTelefono;

        public Cliente() { }

        public Cliente(int dni,string nombre, long numeroTelefono)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.numeroTelefono = numeroTelefono;
        }

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        public long NumeroTelefono
        {
            get { return numeroTelefono; }
            set { numeroTelefono = value; }
        }
   
       public static Cliente RegistrarCliente(int dni,string nombre,long numeroTelefono)
        {
            Cliente cliente = new Cliente(dni,nombre,numeroTelefono);
            bool result= ClienteABM.RegistrarCliente(cliente); 
            
            return cliente;
            
        }

        public static bool VerificarCLiente(int dni)
        {
            bool result = ClienteABM.ExisteCliente(dni);

            return result;
        }
    }
}
