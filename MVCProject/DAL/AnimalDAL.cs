using MVCProject.Models;
using System.Data.SqlClient;

namespace MVCProject.DAL
{
    public class AnimalDAL
    {
        private readonly string connectionString =
            "Data Source=85.208.21.117,54321;" +
            "Initial Catalog=DavidSanzAnimales;" +
            "User ID=sa;" +
            "Password=Sql#123456789";

        public List<Animal> GetAll()
        {
            List<Animal> animales = new List<Animal>();
            TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Animal";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Animal animal = new Animal()
                    {
                        IdAnimal = Convert.ToInt32(reader["IdAnimal"]),
                        NombreAnimal = reader["NombreAnimal"].ToString(),
                        Raza = reader["Raza"].ToString(),
                        RIdTipoAnimal = Convert.ToInt32(reader["RIdTipoAnimal"]),
                        FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]),
                        TipoDeAnimal = tipoAnimalDAL.GetById(Convert.ToInt32(reader["RIdTipoAnimal"]))
                    };
                    animales.Add(animal);
                }
            }

            return animales;
        }

        public Animal GetById(int idAnimal)
        {
            Animal animal = null;
            TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Animal WHERE IdAnimal = @IdAnimal";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdAnimal", idAnimal);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        animal = new Animal
                        {
                            IdAnimal = Convert.ToInt32(reader["IdAnimal"]),
                            NombreAnimal = reader["NombreAnimal"].ToString(),
                            Raza = reader["Raza"].ToString(),
                            RIdTipoAnimal = Convert.ToInt32(reader["RIdTipoAnimal"]),
                            FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]),
                            TipoDeAnimal = tipoAnimalDAL.GetById(Convert.ToInt32(reader["RIdTipoAnimal"]))
                        };
                    }
                }
            }

            return animal;
        }

    }
}
