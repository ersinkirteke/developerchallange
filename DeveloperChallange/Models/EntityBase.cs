using DeveloperChallange.Interfaces;
using DeveloperChallange.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallange.Models
{
    public abstract class EntityBase<T>
    {
        private string id;
        public string Id { get; set; }

        public static T Find(string id)
        {
            return default(T);
        }
        public virtual void Delete() { }
        public virtual void Save() { }
    }
}
