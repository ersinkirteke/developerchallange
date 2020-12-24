using DeveloperChallange.Interfaces;
using DeveloperChallange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallange.Repositories
{
    class CompanyRepository : IRepository<Company>
    {
        private static List<Company> companies;

        public CompanyRepository()
        {
            if (companies == null)
                companies = new List<Company>();

        }

        public void Delete(Company entity)
        {
            companies.Remove(entity);
        }

        public Company Find(string id)
        {
            Company findedCompany = companies.FirstOrDefault(x => x.Id == id);
            Company company = null;
            Address address = null;

            if (findedCompany != null)
            {
                company = new Company();
                address = new Address();
                company.Id = findedCompany.Id;
                company.Name = findedCompany.Name;
                address.Id = findedCompany.Address.Id;
                address.PostalCode = findedCompany.Address.PostalCode;
                address.State = findedCompany.Address.State;
                address.Street = findedCompany.Address.Street;
                address.City = findedCompany.Address.City;
                company.Address = address;
            }

            return company;
        }

        public void Save(Company entity)
        {
            Company company = companies.Find(x => x.Id == entity.Id);

            if (company != null)
                company = entity;
            else
                companies.Add(entity);
        }
    }
}
