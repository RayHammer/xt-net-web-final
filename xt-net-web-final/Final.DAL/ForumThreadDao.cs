using Final.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Final.DAL
{
    public class ForumThreadDao : Interfaces.IForumThreadDao
    {
        private static string ConnectionString => DaoCommon.ConnectionString;

        public ForumThread Add(ForumThread thread)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO ForumThreads (AuthorId, Title, Message) VALUES (@AuthorId, @Title, @Message); SET @Id = SCOPE_IDENTITY();";
                    command.Parameters.Add(new SqlParameter("AuthorId", thread.AuthorId));
                    command.Parameters.Add(new SqlParameter("Title", thread.Title));
                    command.Parameters.Add(new SqlParameter("Message", thread.Message));
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "Id",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Output
                    });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            thread.Id = (int)command.Parameters["Id"].Value;
                        }
                    }

                    connection.Close();
                }
            }
            return thread;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ForumThread> GetAll()
        {
            var threads = new List<ForumThread>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[ForumThreads]";

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            threads.Add(new ForumThread()
                            {
                                Id = (int)reader["Id"],
                                AuthorId = (int)reader["AuthorId"],
                                Title = reader["Title"] as string,
                                Message = reader["Message"] as string
                            });
                        }
                    }

                    connection.Close();
                }
            }
            return threads;
        }

        public ForumThread GetById(int id)
        {
            ForumThread thread = null;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[ForumThreads] WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("Id", id));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            thread = new ForumThread()
                            {
                                Id = (int)reader["Id"],
                                AuthorId = (int)reader["AuthorId"],
                                Title = reader["Title"] as string,
                                Message = reader["Message"] as string
                            };
                        }
                    }

                    connection.Close();
                }
            }
            return thread;
        }

        public ForumThread Update(int id, ForumThread thread)
        {
            throw new System.NotImplementedException();
        }
    }
}