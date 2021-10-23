using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;

namespace GAME_TRACKER
{
    public class DataAccess
    {
        private static string Connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Games;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void writeGame(int gameId, string name, string system, int year)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection connect = new SqlConnection(Connection))
                {
                    String query = "INSERT INTO dbo.Games (GameID,Name,System,Year) VALUES (@GameID,@Name,@System, @Year)";
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.AddWithValue("GameID", SqlDbType.Int).Value = gameId;
                        command.Parameters.AddWithValue("Name", SqlDbType.NVarChar).Value = name;
                        command.Parameters.AddWithValue("System", SqlDbType.NVarChar).Value = system;
                        command.Parameters.AddWithValue("Year", SqlDbType.Int).Value = year;

                        connect.Open();
                        scope.Complete();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }

                }

            }
            
        }

        public List<Game> Game()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection connect = new SqlConnection(Connection))
                {
                    String query = "select * from Games ORDER BY name ASC";
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        connect.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        scope.Complete();

                        List<Game> game = new List<Game>();
                        while (reader.Read())
                        {
                            game.Add(new Game(
                                reader.GetInt32(reader.GetOrdinal("GameID")),
                                reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetString(reader.GetOrdinal("System")),
                                reader.GetInt32(reader.GetOrdinal("Year"))));
                        }

                        return game;
                    }
                }
            }
        }


       
    }
}
