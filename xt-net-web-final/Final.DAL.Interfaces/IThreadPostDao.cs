using Final.Entities;
using System.Collections.Generic;

namespace Final.DAL.Interfaces
{
    public interface IThreadPostDao
    {
        ThreadPost Add(ThreadPost post);

        bool Delete(int id);

        int DeleteUserReference(int userId);

        IEnumerable<ThreadPost> GetAllFor(int threadId);

        ThreadPost Update(int id, ThreadPost post);
    }
}