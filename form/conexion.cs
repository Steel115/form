using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;

namespace form
{
    public class conexion
    {
        private string connectionString = "Server=localhost; Database=SISTEMAS; Integrated Security=True;";
        public SqlConnection ObtenerConexion()
        {
            SqlConnection connection=new SqlConnection(connectionString);
            return connection;
        }
    }
}
