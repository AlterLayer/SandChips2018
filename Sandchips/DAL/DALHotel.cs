using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sandchips.Models;
using Sandchips;
using System.Windows.Forms;

namespace Sandchips.DAL
{
    public class DALHotel
    {
        public static int agregar(ModelHotel Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbdetreservacionhotel(FechaIngreso,FechaSalida, IdClientes,Precio, IdHabitaciones, IdEstadoReservacion)VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", Modelo.FechaIngreso, Modelo.FechaSalida, Modelo.IdClientes, Modelo.Precio, Modelo.IdHabitaciones, 1), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }
        public static int modificar(ModelHotel Modelo)
        {
            int retorno = 0;
            try
            {
                MySqlCommand consulta = new MySqlCommand(string.Format("UPDATE tbdetreservacionhotel SET FechaIngreso='{1}', FechaSalida='{2}', IdClientes='{3}', Precio='{4}', IdHabitaciones='{5}' WHERE IdReservacionHotel='{0}'", Modelo.IdReservacionHotel, Modelo.FechaIngreso, Modelo.FechaSalida, Modelo.IdClientes, Modelo.Precio, Modelo.IdHabitaciones), Conexion.obtenerconexion());
                retorno = consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar modificar registro. " + ex);
            }
            return retorno;
        }
        public static DataTable mostrartabla()
        {
            string instruccion;
            DataTable Consulta = new DataTable();
            try
            {
                instruccion = "SELECT * FROM tbdetreservacionhotel";
                MySqlDataAdapter adapter = new MySqlDataAdapter(instruccion, Conexion.obtenerconexion());
                adapter.Fill(Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return Consulta;
        }

        public static int eliminar(ModelHotel model)
        {
            int retorno = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM tbdetreservacionhotel WHERE IdReservacionHotel='{0}'", model.IdReservacionHotel), Conexion.obtenerconexion());
                retorno = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al intentar insertar registro. " + ex);
            }
            return retorno;
        }


        public static List<ModelHabitaciones> Obtener_Hab()
        {
            List<ModelHabitaciones> listabuscar = new List<ModelHabitaciones>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdHabitaciones, NumeroHabitacion FROM tbmaehabitaciones"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelHabitaciones()
                {
                    IdHabitacion = 0,
                    NumeroHabitacion = 0
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelHabitaciones()
                    {
                        IdHabitacion = reader.GetInt32(0),
                        NumeroHabitacion = reader.GetInt32(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }

        public static List<ModelClientes> ObtenerCliente()
        {
            List<ModelClientes> listabuscar = new List<ModelClientes>();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SELECT IdClientes, Nombre FROM tbmaeclientes"), Conexion.obtenerconexion());
                //* seleccione todo de la tabla..
                MySqlDataReader reader = comando.ExecuteReader();
                listabuscar.Add(new ModelClientes
                {
                    IdClientes = 0,
                    Nombre = "Seleccione una opción"
                });
                while (reader.Read())
                {
                    listabuscar.Add(new ModelClientes
                    {
                        IdClientes = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listabuscar;
        }
        //public static List<ModelHotel> buscar(string user)
        //{
        //    List<ModelHotel> listabuscar = new List<ModelHotel>();
        //    try
        //    {
        //        MySqlCommand comando = new MySqlCommand(string.Format("SELECT * FROM tbdetreservacionhotel WHERE Restaurante LIKE '%" + user + "%'"), Conexion.obtenerconexion());
        //        //* seleccione todo de la tabla..
        //        MySqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            listabuscar.Add(new ModelHotel()
        //            {
        //                IdRestaurante = reader.GetInt32(0),
        //                Restaurante = reader.GetString(1),
        //                NRC = reader.GetString(2)
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return listabuscar;

        //}

    }

}
 