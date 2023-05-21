using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Repositories
{
    public interface ICountryRepository
    {
        void Add(Country entity);
        IEnumerable<Country> Get();
        void Edit(int id, Country entity);
    }
}
