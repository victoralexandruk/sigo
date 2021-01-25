using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIGO.Domain.Common;
using SIGO.Domain.Consultorias;
using System.Collections.Generic;

namespace SIGO.Consultorias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<WeatherForecast> _weatherRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<WeatherForecast> weatherRepository)
        {
            _logger = logger;
            _weatherRepository = weatherRepository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherRepository.GetAll();
        }
    }
}
