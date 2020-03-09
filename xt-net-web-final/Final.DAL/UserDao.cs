using Final.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Final.DAL
{
    public class UserDao : Interfaces.IUserDao
    {
        private static string ConnectionString => DaoCommon.ConnectionString;

        public User Add(User user)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO [dbo].[Users] (Username, PasswordHash) VALUES (@Username, @PasswordHash); SET @Id = SCOPE_IDENTITY();";
                    command.Parameters.Add(new SqlParameter("Username", user.Username));
                    command.Parameters.Add(new SqlParameter("PasswordHash", user.PasswordHash));
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "Id",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Output
                    });

                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        user.Id = (int)command.Parameters["Id"].Value;
                    }

                    connection.Close();
                }
            }
            return user;
        }

        public bool Delete(int id)
        {
            int rows = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE FROM [dbo].[Users] WHERE Id = @IId";
                    command.Parameters.Add(new SqlParameter("Id", id));

                    connection.Open();

                    rows = command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return rows > 0;
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[Users]";

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User()
                            {
                                Id = (int)reader["Id"],
                                Username = reader["Username"] as string,
                                PasswordHash = reader["PasswordHash"] as string
                            });
                        }
                    }

                    connection.Close();
                }
            }
            return users;
        }

        public User GetById(int id)
        {
            User user = null;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[Users] WHERE [Id] = @Id";
                    command.Parameters.Add(new SqlParameter("Id", id));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User()
                            {
                                Id = (int)reader["Id"],
                                Username = reader["Username"] as string,
                                PasswordHash = reader["PasswordHash"] as string
                            };
                        }
                    }

                    connection.Close();
                }
            }
            return user;
        }

        public User GetByUsername(string username)
        {
            User user = null;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[Users] WHERE [Username] = @Username";
                    command.Parameters.Add(new SqlParameter("Username", username));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User()
                            {
                                Id = (int)reader["Id"],
                                Username = reader["Username"] as string,
                                PasswordHash = reader["PasswordHash"] as string
                            };
                        }
                    }

                    connection.Close();
                }
            }
            return user;
        }

        public User Update(int id, User user)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE [dbo].[Users] (Username, PasswordHash) SET Username = @Username, " +
                        "PasswordHash = @PasswordHash WHERE Id = @Id;";
                    command.Parameters.Add(new SqlParameter("Username", user.Username));
                    command.Parameters.Add(new SqlParameter("PasswordHash", user.PasswordHash));
                    command.Parameters.Add(new SqlParameter("Id", id));

                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        user.Id = id;
                    }

                    connection.Close();
                }
            }
            return user;
        }
    }
}