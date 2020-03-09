using Final.DAL.Interfaces;
using Final.Entities;
using System.Collections.Generic;

namespace Final.BLL
{
    public class ThreadPostLogic : Interfaces.IThreadPostLogic
    {
        private readonly IThreadPostDao dao;

        public ThreadPostLogic(IThreadPostDao dao)
        {
            this.dao = dao;
        }

        public static bool Validate(ThreadPost post)
        {
            return post.Message.Length > 0 && post.Message.Length <= 4000;
        }

        public ThreadPost Add(ThreadPost post)
        {
            if (!Validate(post))
            {
                return null;
            }
            return dao.Add(post);
        }

        public bool Delete(int id)
        {
            return dao.Delete(id);
        }

        public int DeleteUserReference(int userId)
        {
            return dao.DeleteUserReference(userId);
        }

        public IEnumerable<ThreadPost> GetAllFor(int threadId)
        {
            return dao.GetAllFor(threadId);
        }

        public ThreadPost Update(int id, ThreadPost post)
        {
            if (!Validate(post))
            {
                return null;
            }
            return dao.Update(id, post);
        }
    }
}