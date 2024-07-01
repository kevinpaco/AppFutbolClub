using ClasesBase.DBConect;
using ClasesBase.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCanchaClub
{
    [TestClass]
    public class UnitTest1
    {
        [Ignore]
        public void TestCanchaDisponible()
        {
           Cancha cancha = new Cancha();
            cancha.Tipo = "Futbol 6";
            bool disponible = Cancha.VerificarDisponibilidad(cancha.Tipo);
            Assert.AreEqual(disponible, false);
        }

        [Ignore]
        public void TestVerificarDisponibilidadReserva()
        {               
            DateTime hi = DateTime.Parse("2024-06-21 17:00:00");
            DateTime hf = DateTime.Parse("2024-06-21 18:00:00");
           
            
            string tipo = "Futbol 7";
            bool result = Reserva.VerificarDispinibilidad(DateTime.Now, hi, hf, tipo);
             if (result)
             {
                 Console.WriteLine("Disponible");
             }
             else
             {
                 Console.WriteLine("No Disponible");
             }

        }

        [Ignore]
        public void TestBuscarCanchaById()
        {
            Cancha buscar = CanchaABM.BuscarCanchaById(1);
            Console.WriteLine(buscar.Tipo);
            Assert.IsNotNull(buscar);
        }

        [TestMethod]
        public void TestRegistrarReserva()
        {
            bool result = Reserva.RegistrarReserva("Juan", 43234323, 3882343445, DateTime.Now, "17:00", "18:30", "Futbol 7");
            if (result)
            {
                Console.WriteLine("Si se guardo");
            }
            else
                Console.WriteLine("No se guardo");
        }
    }
}
