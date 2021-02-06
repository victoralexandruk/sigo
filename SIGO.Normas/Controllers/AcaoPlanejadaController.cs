using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIGO.Domain.Common;
using SIGO.Domain.Normas;
using Swashbuckle.AspNetCore.Annotations;
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

        [SwaggerOperation(Summary = "Salva uma ação planejada")]
        [HttpPost]
        public AcaoPlanejada Post(AcaoPlanejada model)
        {
            _acaoPlanejadaRepository.Save(model);
            return model;
        }

        [SwaggerOperation(Summary = "Obtém lista com todas as ações planejadas")]
        [HttpGet]
        public IEnumerable<AcaoPlanejada> Get()
        {
            return _acaoPlanejadaRepository.GetAll();
        }

        [SwaggerOperation(Summary = "Obtém ação planejada pelo id")]
        [HttpGet]
        [Route("{id}")]
        public AcaoPlanejada Get(long id)
        {
            return _acaoPlanejadaRepository.GetById(id);
        }

        [SwaggerOperation(Summary = "Exclui ação planejada pelo id")]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            _acaoPlanejadaRepository.Delete(id);
            return Ok();
        }

        [SwaggerOperation(Summary = "Lista ações planejadas que o campo {key} contenha o valor {value}")]
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
