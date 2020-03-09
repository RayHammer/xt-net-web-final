using Final.Entities;
using System.Collections.Generic;

namespace Final.DAL.Interfaces
{
    public interface IRoleDao
    {
        IEnumerable<Role> GetAll();

        Role GetById(int id);

        Role GetByName(string name);
    }
}
