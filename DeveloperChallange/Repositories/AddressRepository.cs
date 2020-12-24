using DeveloperChallange.Interfaces;
using DeveloperChallange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallange.Repositories
{
    class AddressRepository : IRepository<Address>
    {
        private static List<Address> addresses;

        public AddressRepository()
        {
            if (addresses == null)
                addresses = new List<Address>();
        }

        public void Delete(Address entity)
        {
            addresses.Remove(entity);
        }

        public Address Find(string id)
        {
            return addresses.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Address entity)
        {
            Address address = addresses.Find(x => x.Id == entity.Id);

            if (address != null)
                address = entity;
            else
                addresses.Add(entity);
        }
    }
}
