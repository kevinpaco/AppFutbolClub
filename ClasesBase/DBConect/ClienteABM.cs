using ClasesBase.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace ClasesBase.DBConect
{
    public class ClienteABM
    {
        public static bool RegistrarCliente(Cliente cli)
        {
            using(SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conection))
            {
                string sentence = "INSERT INTO Cliente(dni,nombre,numeroTelefono) Values(@dni,@nom,@numTel)";
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sentence;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;

                    cmd.Parameters.AddWithValue("@dni", cli.Dni);
                    cmd.Parameters.AddWithValue("nom",cli.Nombre);
                    cmd.Parameters.AddWithValue("numTel",cli.NumeroTelefono);
                    try
                    {
                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            cnn.Close();
                            return true;                        
                    }catch(SqlException ex)
                    {
                        Console.WriteLine("Error al guardar: {0}",ex.Message);
                        return false;
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Error Inesperado: {0}", ex.Message);
                        return false;
                    }
                    finally
                    {
                        cnn.Close();
                    }
                } 
            }
        }

        public static bool ExisteCliente(int dni)
        {
            using(SqlConnection cnn =new SqlConnection(ClasesBase.Properties.Settings.Default.conection))
            {
                string sentence = "Select * From Cliente WHERE dni=@dni";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sentence;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;

                    cmd.Parameters.AddWithValue("@dni", dni);
                    try
                    {
                        cnn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();                       
                        if (dr.Read())                        
                            return true;                        
                        else
                            return false;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al buscar cliente: {0}", ex.Message);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Inesperado al buscar: {0}", ex.Message);
                        return false;
                    }
                    finally
                    {
                        cnn.Close();
                    }
                }

            }
        }
    }
}
