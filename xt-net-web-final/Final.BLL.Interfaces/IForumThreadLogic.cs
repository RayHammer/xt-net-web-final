using Final.Entities;
using System.Collections.Generic;

namespace Final.BLL.Interfaces
{
    public interface IForumThreadLogic
    {
        ForumThread Add(ForumThread thread);

        bool Delete(int id);

        IEnumerable<ForumThread> GetAll();

        ForumThread GetById(int id);

        ForumThread Update(int id, ForumThread thread);
    }
}