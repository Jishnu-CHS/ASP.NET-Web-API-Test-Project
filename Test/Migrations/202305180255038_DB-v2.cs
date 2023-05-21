namespace Test.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Test.Models;
    using Test.Context;

    public partial class DBv2 : DbMigration
    {
        public override void Up()
        {

            var cityInMaharashtra = new List<City> {
                new City {Name="Mumbai" },
                                new City {Name= "Pune" }
            };
            var cityInUttarPradesh = new List<City> {
                new City {Name="Lucknow" },
                                new City {Name="Banaras" }
            };
            var cityInTamilnadu = new List<City> {
                new City {Name="Bangaluru" },
                                new City {Name="Chennai" }
            };
            var cityInUttaranchal = new List<City> {
                new City {Name="Dehradun" },
                                new City {Name="Rishikesh" }
            };
            var cityInPanjab = new List<City> {
                new City {Name="Chandigarh" },
                                new City {Name="Ludhiana" }
            };
            var stateInIndia = new List<State> {
                new State {
                    Name="Maharashtra",City=cityInMaharashtra
                },
                new State {
                    Name="Uttar Pradesh",City=cityInUttarPradesh
                },
                new  State {
                    Name="Tamil nadu",City=cityInTamilnadu
                },
                new  State {
                    Name="Uttaranchal",City=cityInUttaranchal
                },
                new  State {
                    Name="Panjab",City=cityInPanjab
                }
            };
            Country country = new Country
            {
                Name = "India",
                State = stateInIndia
            };
            DatabaseContext context = new DatabaseContext();
            context.Countries.AddOrUpdate(country);
            context.SaveChanges();

        }

        public override void Down()
        {
        }
    }
}
