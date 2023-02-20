using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAO
{
    public class UsuarioDAO
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        conexion con = new conexion();
        SqlConnection cnx;
        public DataSet ListUsuario()
        {
            cnx = con.conectar();
            da = new SqlDataAdapter("SP_Usuario_List", cnx);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet dsx = new DataSet();
            da.Fill(dsx, "get");
            cnx.Close();
            return dsx;
        }
        public int InsertUsuario(UsuarioBE e)
        {
            int vnReturn = 0;
            try
            {
                cnx = con.conectar();
                cmd = new SqlCommand("SP_Usuario_Reg", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Usuari", e.Usuari));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", e.Contrasena));
                cmd.Parameters.Add(new SqlParameter("@CodigoArea", e.CodigoArea));
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ed)
            {
                vnReturn = -1;
            }
            finally
            {
                cmd.Dispose();
                cnx.Close();
            }
            return vnReturn;
        }
    }
}
