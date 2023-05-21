using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Test.Context;
using System.Data.Entity;
using System.Linq;
using Test.Models;
using System.Web.Http.Results;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity.Migrations;

namespace Test.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CountryRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public void Add(Country entity)
        {
            _databaseContext.Countries.Add(entity);
            _databaseContext.SaveChanges();
        }

        public void Edit(int id, Country entity)
        {
            entity.CountryId = id;
            
            var countries = _databaseContext.Countries.Include(_ => _.State.Select(s => s.City)).FirstOrDefault(_ => _.CountryId == id);

            if (countries == null)
            {
                return;
            }

            List<City> cities = new List<City>();
            if (entity.State != null)
            {
                foreach(var element in entity.State)
                {
                    foreach(var city in element.City)
                    {
                        cities.Add(city);
                    }
                }
            }

            
            countries.Name = entity.Name;
            entity.State.ForEach(_ => _.CountryId = id);

            _databaseContext.States.AddRange(entity.State);
            _databaseContext.Cities.AddRange(cities);

            _databaseContext.SaveChanges();
        }

        public IEnumerable<Country> Get()
        {
            var result = _databaseContext.Countries.Include(_ => _.State.Select(s => s.City)).ToList();

            return result;
        }
    }
}