using Final.Entities;
using System.Collections.Generic;

namespace Final.DAL.Interfaces
{
    public interface IForumThreadDao
    {
        IEnumerable<ForumThread> GetAll();
    }
}