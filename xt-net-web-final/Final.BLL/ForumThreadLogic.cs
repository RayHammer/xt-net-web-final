using Final.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.DAL.Interfaces;

namespace Final.BLL
{
    public class ForumThreadLogic : Interfaces.IForumThreadLogic
    {
        private IForumThreadDao dao;

        public ForumThreadLogic(IForumThreadDao dao)
        {
            this.dao = dao;
        }

        public ForumThread Add(ForumThread thread)
        {
            if (!Validate(thread))
            {
                return null;
            }
            return dao.Add(thread);
        }

        public bool Delete(int id)
        {
            return dao.Delete(id);
        }

        public IEnumerable<ForumThread> GetAll()
        {
            return dao.GetAll();
        }

        public ForumThread GetById(int id)
        {
            return dao.GetById(id);
        }

        public ForumThread Update(int id, ForumThread thread)
        {
            if (!Validate(thread))
            {
                return null;
            }
            return dao.Update(id, thread);
        }

        public static bool Validate(ForumThread thread)
        {
            return thread.Title.Length > 0 && thread.Title.Length <= 50 &&
                thread.Message.Length > 0 && thread.Message.Length <= 4000;
        }
    }
}
