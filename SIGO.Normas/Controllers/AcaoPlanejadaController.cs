using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIGO.Domain.Common;
using SIGO.Domain.Normas;
using System.Collections.Generic;

namespace SIGO.Normas.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class AcaoPlanejadaController : ControllerBase
    {
        private readonly ILogger<AcaoPlanejadaController> _logger;
        private readonly IRepository<AcaoPlanejada> _acaoPlanejadaRepository;

        public AcaoPlanejadaController(ILogger<AcaoPlanejadaController> logger, IRepository<AcaoPlanejada> acaoPlanejadaRepository)
        {
            _logger = logger;
            _acaoPlanejadaRepository = acaoPlanejadaRepository;
        }

        [HttpPost]
        public AcaoPlanejada Post(AcaoPlanejada model)
        {
            _acaoPlanejadaRepository.Save(model);
            return model;
        }

        [HttpGet]
        public IEnumerable<AcaoPlanejada> Get()
        {
            return _acaoPlanejadaRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public AcaoPlanejada Get(long id)
        {
            return _acaoPlanejadaRepository.GetById(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            _acaoPlanejadaRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("search/{key}/{value}/{strict?}")]
        public IEnumerable<AcaoPlanejada> Search(string key, string value, bool strict = true)
        {
            var where = new Dictionary<string, object>
            {
                { key, value }
            };
            return _acaoPlanejadaRepository.Search(where, strict);
        }
    }
}
