using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    internal class RandomRecordRetriever
    {
        private readonly string connectionString;

        public RandomRecordRetriever(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public (int, string, string) GetRandomRecordFromDatabase()
        {
            int randomRecord1 = 0;
            string randomRecord2 = null;
            string randomRecord3 = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query1 = "SELECT TOP 1 id, Q1,Q2 FROM [Table] ORDER BY NEWID()";


                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                randomRecord1 = reader.GetInt32(0);
                                randomRecord2 = reader.GetString(1);
                                randomRecord3 = reader.GetString(2);

                            }
                        }
                    }
               
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении случайной записи из базы данных: {ex.Message}");
            }

            return (randomRecord1, randomRecord2, randomRecord3);
        }
    }
}
