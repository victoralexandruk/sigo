using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIGO.Domain.Common;
using SIGO.Domain.Normas;
using System.Collections.Generic;

namespace SIGO.Normas.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class NormaController : ControllerBase
    {
        private readonly ILogger<NormaController> _logger;
        private readonly IRepository<Norma> _normaRepository;

        public NormaController(ILogger<NormaController> logger, IRepository<Norma> normaRepository)
        {
            _logger = logger;
            _normaRepository = normaRepository;
        }

        [HttpPost]
        public Norma Post(Norma model)
        {
            _normaRepository.Save(model);
            return model;
        }

        [HttpGet]
        public IEnumerable<Norma> Get()
        {
            return _normaRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Norma Get(long id)
        {
            return _normaRepository.GetById(id);
        }

        [HttpGet]
        [Route("search/{key}/{value}/{strict?}")]
        public IEnumerable<Norma> Search(string key, string value, bool strict = true)
        {
            var where = new Dictionary<string, object>
            {
                { key, value }
            };
            return _normaRepository.Search(where, strict);
        }
    }
}
