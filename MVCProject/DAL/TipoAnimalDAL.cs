using MVCProject.Models;
using System.Data.SqlClient;

namespace MVCProject.DAL
{
    public class TipoAnimalDAL
    {
        private readonly string connectionString = "";

        public TipoAnimal GetById(int id)
        {
            TipoAnimal tipoAnimal = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TipoAnimal WHERE IdTipoAnimal = @IdTipoAnimal";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdTipoAnimal", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    tipoAnimal = new TipoAnimal
                    {
                        IdTipoAnimal = (int)reader["IdTipoAnimal"],
                        TipoDescripcion = reader["TipoDescripcion"].ToString()
                    };
                }
            }
            return tipoAnimal;
        }
    }
}
