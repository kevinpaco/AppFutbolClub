using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClasesBase.models;

namespace ClasesBase.DBConect
{
    public class CanchaABM
    {
       public static DataTable ListarCanchas()
        {
            using(SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conection))
            {
                string sentencia = "SELECT * FROM Cancha";
                using(SqlDataAdapter da = new SqlDataAdapter(sentencia,cnn))
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }catch (SqlException ex)
                    { 
                        Console.WriteLine("Error al listar Canchas: {0}",ex.Message);
                        return null;
                    }catch(Exception ex)
                    {
                        Console.WriteLine("Error Inesperado: {0}", ex.Message);
                        return null;
                    }
                }
            }
        }

        public static Cancha BuscarCanchaById(int idCancha)
        {
            using(SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conection))
            {
                string sentence = "SELECT * FROM Cancha WHERE idCancha=@idC";
                using(SqlCommand cmd =new SqlCommand()) 
                {
                    try
                    {
                        cmd.CommandText = sentence;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = cnn;

                        cmd.Parameters.AddWithValue("@idC", idCancha);

                        cnn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        Cancha cancha = new Cancha();
                        if (reader.Read())
                        {
                            cancha.IdCacha = int.Parse(reader["idCancha"].ToString());
                            cancha.Tipo = reader["tipo"].ToString();
                            cancha.Estado = reader["idCancha"].ToString();
                            cancha.Precio = float.Parse(reader["precio"].ToString());
                        }
                        return cancha;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al buscar Canchas: {0}", ex.Message);
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Inesperado: {0}", ex.Message);
                        return null;
                    }
                    finally { cnn.Close(); }
                }
            }
        }

        public static Cancha BuscarCanchaPorTipo(string tipoCancha)
        {
            using(SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conection))
            {
                string sentece = "SELECT * FROM Cancha WHERE tipo=@tipoC";
                using(SqlCommand cmd =new SqlCommand())
                {
                    try
                    {
                        cmd.CommandText = sentece;
                        cmd.CommandType= CommandType.Text;
                        cmd.Connection= cnn;

                        cmd.Parameters.AddWithValue("@tipoC",tipoCancha);
                        cnn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        Cancha cancha = new Cancha();
                        if(reader.Read())
                        {
                            cancha.IdCacha = int.Parse(reader["idCancha"].ToString());
                            cancha.Tipo = reader["tipo"].ToString();
                            cancha.Estado =reader["estado"].ToString();
                            cancha.Precio = float.Parse(reader["precio"].ToString());
                        }
                        return cancha;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al buscar Cancha: {0}", ex.Message);
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Inesperado: {0}", ex.Message);
                        return null;
                    }
                    finally { cnn.Close(); }
                }
            }
        }
    }
}
