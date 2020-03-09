using Final.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Final.DAL
{
    public class ThreadPostDao : Interfaces.IThreadPostDao
    {
        private static string ConnectionString => DaoCommon.ConnectionString;

        public ThreadPost Add(ThreadPost post)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO [dbo].[ThreadPosts] (AuthorId, ThreadId, Message) " +
                        "VALUES (@AuthorId, @ThreadId, @Message); SET @Id = SCOPE_IDENTITY();";
                    command.Parameters.Add(new SqlParameter("AuthorId", post.AuthorId));
                    command.Parameters.Add(new SqlParameter("ThreadId", post.ThreadId));
                    command.Parameters.Add(new SqlParameter("Message", post.Message));
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "Id",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Output
                    });

                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        post.Id = (int)command.Parameters["Id"].Value;
                    }

                    connection.Close();
                }
            }
            return post;
        }

        public bool Delete(int id)
        {
            int rows = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE FROM [dbo].[ThreadPosts] WHERE Id = @IId";
                    command.Parameters.Add(new SqlParameter("Id", id));

                    connection.Open();

                    rows = command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return rows > 0;
        }

        public IEnumerable<ThreadPost> GetAllFor(int threadId)
        {
            var posts = new List<ThreadPost>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM [dbo].[ThreadPosts] WHERE ThreadId = @ThreadId";
                    command.Parameters.Add(new SqlParameter("ThreadId", threadId));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            posts.Add(new ThreadPost()
                            {
                                Id = (int)reader["Id"],
                                ThreadId = (int)reader["ThreadId"],
                                AuthorId = (int)reader["AuthorId"],
                                Message = reader["Message"] as string
                            });
                        }
                    }

                    connection.Close();
                }
            }
            return posts;
        }

        public ThreadPost Update(int id, ThreadPost post)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE [dbo].[ThreadPosts] SET AuthorId = @AuthorId, ThreadId = @ThreadId, " +
                        "Message = @Message WHERE Id = @Id;";
                    command.Parameters.Add(new SqlParameter("AuthorId", post.AuthorId));
                    command.Parameters.Add(new SqlParameter("ThreadId", post.ThreadId));
                    command.Parameters.Add(new SqlParameter("Message", post.Message));
                    command.Parameters.Add(new SqlParameter("Id", id));

                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        post.Id = id;
                    }

                    connection.Close();
                }
            }
            return post;
        }
    }
}