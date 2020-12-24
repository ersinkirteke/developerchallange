using DeveloperChallange.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallange.Models
{
    public class Person : EntityBase<Person>, IEquatable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public Person()
        {

        }

        public Person(string firstName, string lastName, Address address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }

        public new static Person Find(string id)
        {
            PersonRepository repository = new PersonRepository();
            return repository.Find(id);
        }

        public override void Delete()
        {
            base.Delete();
            PersonRepository repository = new PersonRepository();
            repository.Delete(this);
            this.Id = null;
        }

        public override void Save()
        {
            base.Save();
            this.Id = Guid.NewGuid().ToString();
            PersonRepository repository = new PersonRepository();
            repository.Save(this);
        }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            if (person == null)
                return false;

            return (this.FirstName == person.FirstName && this.LastName == person.LastName && this.Address.Equals(person.Address));
        }

        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            return (this.FirstName == other.FirstName && this.LastName == other.LastName && this.Address.Equals(other.Address));
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.Address.GetHashCode();
        }
    }
}
