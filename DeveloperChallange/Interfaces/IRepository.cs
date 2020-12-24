using DeveloperChallange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallange.Interfaces
{
    public interface IRepository<T> where T : EntityBase<T>
    {

        T Find(string id);

        void Save(T entity);

        void Delete(T entity);
    }
}
