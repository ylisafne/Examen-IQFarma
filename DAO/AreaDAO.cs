using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AreaDAO
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        conexion con = new conexion();
        SqlConnection cnx;
        public DataSet ListArea()
        {
            cnx = con.conectar();
            da = new SqlDataAdapter("SP_Area_list", cnx);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet dsx = new DataSet();
            da.Fill(dsx, "get");
            cnx.Close();
            return dsx;
        }



    }
}
