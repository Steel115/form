using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace form
{
    public class operaciones
    {
        private conexion conexionBD;

        public operaciones()
        {
            conexionBD = new conexion();   
        }

        public void InsertarPersona(string nombre, string departamento, string profesion, int edad)
        {
            using(var connection=conexionBD.ObtenerConexion())
            {
                string query = "INSERT INTO Personas(Nombre, Departamento, Profesion, Edad)" +
                    "VALUES(@Nombre, @Departamento, @Profesion, @Edad)";
                SqlCommand command=new SqlCommand(query, connection); //damos de alta que lea el cmoando
                command.Parameters.AddWithValue("@Nombre", nombre);//se agregan los parametro
                command.Parameters.AddWithValue("@Departamento", departamento);//se agregan los parametro
                command.Parameters.AddWithValue("@Profesion", profesion);//se agregan los parametro
                command.Parameters.AddWithValue("@Edad", edad);//se agregan los parametro
                connection.Open();//abrimos la conexion a la base de datos
                command.ExecuteNonQuery();//ejecuta la consulta insert
                connection.Close();//cerramos la conexion 



            }
        }
        public SqlDataReader MostrarPersonas()
        {
            SqlConnection connection = conexionBD.ObtenerConexion();
            string query = "SELECT * FROM Personas";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            return command.ExecuteReader();
        }
        public void ActualizandrPersonas(int id, string nombre, string departamento, string profesion, int edad)
        {
            using (var connection = conexionBD.ObtenerConexion())
            {
                string query = "UPDATE Personas SET Nombre=@Nombre,Departamento=@Departamento,Profesion=@Profesion,Edad=@Edad WHERE id=@Id";
                    SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Departamento", departamento);
                command.Parameters.AddWithValue("@Profesion", profesion);
                command.Parameters.AddWithValue("@Edad", edad);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void EliminarPersona(int id)
        {
            using (var connection = conexionBD.ObtenerConexion())
            {
                string query = "DELETE FROM Personas WHERE Id=@Id";
                SqlCommand command = new SqlCommand (query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


    }
}
