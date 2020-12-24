using DeveloperChallange.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallange.Models
{
    public class Company : EntityBase<Company>, IEquatable<Company>
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Company()
        {

        }

        public Company(string name, Address address)
        {
            this.Name = name;
            this.Address = address;
        }

        public new static Company Find(string id)
        {
            CompanyRepository repository = new CompanyRepository();
            return repository.Find(id);
        }

        public override void Delete()
        {
            base.Delete();
            CompanyRepository repository = new CompanyRepository();
            repository.Delete(this);
            this.Id = null;
        }

        public override void Save()
        {
            base.Save();
            this.Id = Guid.NewGuid().ToString();
            CompanyRepository repository = new CompanyRepository();
            repository.Save(this);
        }

        public override bool Equals(object obj)
        {
            Company company = obj as Company;
            if (company == null)
                return false;

            return (this.Name == company.Name && this.Address.Equals(company.Address));
        }

        public bool Equals(Company other)
        {
            if (other == null)
                return false;

            return (this.Name == other.Name && this.Address.Equals(other.Address));
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Address.GetHashCode();
        }
    }
}
