using System;
using System.Linq;
using System.Web.Http;
using Test.Context;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private readonly ICountryRepository _repository;

        public TestController(ICountryRepository repository)
        {
            this._repository = repository;
        }

        public TestController(){}

        [HttpPost]
        public IHttpActionResult Post(Country country)
        {
            try
            {
                this._repository.Add(country);
                return Ok(this._repository.Get());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Country country)
        {
            try
            {
                this._repository.Edit(id, country);
                return Ok(this._repository.Get());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned
                return InternalServerError();
            }

        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(this._repository.Get());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned
                return InternalServerError();
            }
        }
    }
}
