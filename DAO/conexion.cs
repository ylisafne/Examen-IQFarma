using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public  class conexion
    {
        public SqlConnection conectar()
        {
            SqlConnection conn = new SqlConnection(
                new SqlConnectionStringBuilder()
                    {
                            DataSource = "localhost",
                            InitialCatalog = "EMPRESA",
                            UserID = "sa",
                            Password = "123"
                        }.ConnectionString
                    );
            return conn;
        }
    }
}
