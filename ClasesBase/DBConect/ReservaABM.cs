using ClasesBase.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase.DBConect
{
    public class ReservaABM
    {
        public static bool RegistrarReserva(Reserva reserva)
        {
            using(SqlConnection cnn =new SqlConnection(ClasesBase.Properties.Settings.Default.conection))
            {
                string sentence = "INSERT INTO Reserva(horaInicio,HoraFinalizacion,dni,idCancha,fecha)";
                sentence += " values(@hi,@hf,@dni,@can,@fecha)";
                using(SqlCommand cmd =new SqlCommand())
                {
                    try
                    {
                        cmd.CommandText = sentence;
                        cmd.CommandType= CommandType.Text;
                        cmd.Connection = cnn;

                        cmd.Parameters.AddWithValue("@hi",reserva.HoraInicio);
                        cmd.Parameters.AddWithValue("@hf", reserva.HoraFin);
                        cmd.Parameters.AddWithValue("@dni", reserva.DniCliente);
                        cmd.Parameters.AddWithValue("@can", reserva.IdCancha);
                        cmd.Parameters.AddWithValue("@fecha", reserva.Fecha);

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al registrar Reserva: {0}", ex.Message);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Inesperado: {0}", ex.Message);
                        return false;
                    }finally { cnn.Close(); }
                }
            }
        }

        public static DataTable ListarReservas()
        {
            using(SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conection))
            {
                string sentece = "SELECT * FROM Reserva";
                using(SqlDataAdapter da = new SqlDataAdapter(sentece, cnn))
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }catch(SqlException ex)
                    {
                        Console.WriteLine("Error al listar Reservas: {0}",ex.Message);
                        return null;
                    }catch (Exception ex2)
                    {
                        Console.WriteLine("Error inesperado: {0}", ex2.Message);
                        return null;
                    }
                }
            }
        }
    }
}
