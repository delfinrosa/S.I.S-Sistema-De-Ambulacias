using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace cslUtileriasBD
{
    public class clsSQLServer
    {

        public static DataTable getDatatable(string sqlConexion, string sqlQuery, ref string error)
        {
            SqlConnection con = new SqlConnection(sqlConexion);
            SqlCommand cmd = new SqlCommand(sqlQuery,con);
            SqlDataAdapter sdp = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            try
            {
                sdp.Fill(tabla);
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            return tabla;
        }
        public static int exeQuery(string sqlConexion, string sqlQuery, ref string error)
        {
            SqlConnection con = new SqlConnection(sqlConexion);
            SqlCommand cmd = new SqlCommand(sqlQuery,con);
            int registrosAfectados = 0;
            try
            {
                con.Open();
                registrosAfectados = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Close();
                    error = ex.Message;

                }
            }
            return registrosAfectados;
        }

    }
}
