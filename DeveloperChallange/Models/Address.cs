using DeveloperChallange.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallange.Models
{
    public class Address : EntityBase<Address>, IEquatable<Address>
    {
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public Address()
        {

        }

        public Address(string street, string city, string state, string postalCode)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Street = street;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
        }

        public new static Address Find(string id)
        {
            AddressRepository repository = new AddressRepository();
            return repository.Find(id);
        }

        public override void Delete()
        {
            base.Delete();
            AddressRepository repository = new AddressRepository();
            repository.Delete(this);
        }

        public override void Save()
        {
            base.Save();
            AddressRepository repository = new AddressRepository();
            repository.Save(this);
        }

        public override bool Equals(object obj)
        {
            Address address = obj as Address;
            if (address == null)
                return false;

            return (this.City == address.City && this.PostalCode == address.PostalCode && this.State == address.State && this.Street == address.Street);
        }

        public bool Equals(Address other)
        {
            if (other == null)
                return false;

            return (this.City == other.City && this.PostalCode == other.PostalCode && this.State == other.State && this.Street == other.Street);
        }

        public override int GetHashCode()
        {
            return this.City.GetHashCode() ^ this.PostalCode.GetHashCode() ^ this.State.GetHashCode() ^ this.Street.GetHashCode();
        }
    }
}
