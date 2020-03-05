using Final.Entities;
using System.Collections.Generic;

namespace Final.DAL.Interfaces
{
    public interface IThreadPost
    {
        IEnumerable<ThreadPost> GetAllFor(int threadId);
    }
}