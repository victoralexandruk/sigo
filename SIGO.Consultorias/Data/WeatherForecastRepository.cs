using SIGO.Domain.Common;
using SIGO.Domain.Consultorias;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIGO.Consultorias.Data
{
    public class WeatherForecastRepository : IRepository<WeatherForecast>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public WeatherForecast GetById(long id)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }

        public void Save(WeatherForecast model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WeatherForecast> Search(IDictionary<string, object> where, bool strict = true)
        {
            throw new NotImplementedException();
        }
    }
}
