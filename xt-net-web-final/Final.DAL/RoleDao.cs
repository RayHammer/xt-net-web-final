using Final.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Final.DAL
{
    public class RoleDao : Interfaces.IRoleDao
    {
        private static string ConnectionString => DaoCommon.ConnectionString;

        public IEnumerable<Role> GetAll()
        {
            var roles = new List<Role>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[Roles]";

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new Role()
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"] as string
                            });
                        }
                    }

                    connection.Close();
                }
            }
            return roles;
        }

        public Role GetById(int id)
        {
            Role role = null;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[Roles] WHERE [Id] = @Id";
                    command.Parameters.Add(new SqlParameter("Id", id));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role = new Role()
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"] as string
                            };
                        }
                    }

                    connection.Close();
                }
            }
            return role;
        }

        public Role GetByName(string name)
        {
            Role role = null;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[Roles] WHERE [Name] = @Name";
                    command.Parameters.Add(new SqlParameter("Name", name));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role = new Role()
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"] as string
                            };
                        }
                    }

                    connection.Close();
                }
            }
            return role;
        }
    }
}