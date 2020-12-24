using DeveloperChallange.Interfaces;
using DeveloperChallange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallange.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private static List<Person> persons;

        public PersonRepository()
        {
            if (persons == null)
                persons = new List<Person>();
        }

        public void Delete(Person entity)
        {
            persons.Remove(entity);
        }

        public Person Find(string id)
        {
            Person findedPerson = persons.FirstOrDefault(x => x.Id == id);
            Person person = null;
            Address address = null;

            if (findedPerson != null)
            {
                person = new Person();
                address = new Address();
                person.FirstName = findedPerson.FirstName;
                person.LastName = findedPerson.LastName;
                address.Id = findedPerson.Address.Id;
                address.PostalCode = findedPerson.Address.PostalCode;
                address.State = findedPerson.Address.State;
                address.Street = findedPerson.Address.Street;
                address.City = findedPerson.Address.City;
                person.Address = address;
                person.Id = findedPerson.Id;
            }

            return person;
        }

        public void Save(Person entity)
        {
            Person person = persons.Find(x => x.Id == entity.Id);

            if (person != null)
                person = entity;
            else
                persons.Add(entity);
        }
    }
}
