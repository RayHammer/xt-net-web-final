using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Final.DAL
{
    public class UserRolesDao : Interfaces.IUserRolesDao
    {
        private static string ConnectionString => DaoCommon.ConnectionString;

        public bool AddLink(int userId, int roleId)
        {
            bool result = false;

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO [dbo].[UserRoles] (UserId, RoleId) VALUES (@UserId, @RoleId);";
                    command.Parameters.Add(new SqlParameter("UserId", userId));
                    command.Parameters.Add(new SqlParameter("RoleId", roleId));

                    connection.Open();

                    result = command.ExecuteNonQuery() > 0;

                    connection.Close();
                }
            }

            return result;
        }

        public bool CheckLink(int userId, int roleId)
        {
            bool result = false;

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[UserRoles] WHERE UserId = @UserId AND RoleId = @RoleId;";
                    command.Parameters.Add(new SqlParameter("UserId", userId));
                    command.Parameters.Add(new SqlParameter("RoleId", roleId));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }

                    connection.Close();
                }
            }

            return result;
        }

        public IEnumerable<int> GetLinksFor(int userId)
        {
            var roleIds = new List<int>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[UserRoles] WHERE UserId = @UserId";
                    command.Parameters.Add(new SqlParameter("UserId", userId));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roleIds.Add((int)reader["RoleId"]);
                        }
                    }

                    connection.Close();
                }
            }
            return roleIds;
        }
    }
}