﻿using Final.Entities;
using System.Collections.Generic;

namespace Final.DAL.Interfaces
{
    public interface IForumThreadDao
    {
        ForumThread Add(ForumThread thread);

        bool Delete(int id);

        IEnumerable<ForumThread> GetAll();

        ForumThread GetById(int id);

        ForumThread Update(int id, ForumThread thread);
    }
}