using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIGO.Domain.Common;
using SIGO.Domain.Consultorias;
using System.Collections.Generic;

namespace SIGO.Consultorias.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ConsultoriaController : ControllerBase
    {
        private readonly ILogger<ConsultoriaController> _logger;
        private readonly IRepository<Consultoria> _consultoriaRepository;

        public ConsultoriaController(ILogger<ConsultoriaController> logger, IRepository<Consultoria> consultoriaRepository)
        {
            _logger = logger;
            _consultoriaRepository = consultoriaRepository;
        }

        [HttpPost]
        public Consultoria Post(Consultoria model)
        {
            _consultoriaRepository.Save(model);
            return model;
        }

        [HttpGet]
        public IEnumerable<Consultoria> Get()
        {
            return _consultoriaRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Consultoria Get(long id)
        {
            return _consultoriaRepository.GetById(id);
        }

        [HttpGet]
        [Route("search/{key}/{value}/{strict?}")]
        public IEnumerable<Consultoria> Search(string key, string value, bool strict = true)
        {
            var where = new Dictionary<string, object>
            {
                { key, value }
            };
            return _consultoriaRepository.Search(where, strict);
        }
    }
}
