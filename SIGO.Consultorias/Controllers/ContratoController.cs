using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIGO.Domain.Common;
using SIGO.Domain.Consultorias;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace SIGO.Consultorias.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ContratoController : ControllerBase
    {
        private readonly ILogger<ContratoController> _logger;
        private readonly IRepository<Contrato> _contratoRepository;

        public ContratoController(ILogger<ContratoController> logger, IRepository<Contrato> contratoRepository)
        {
            _logger = logger;
            _contratoRepository = contratoRepository;
        }

        [SwaggerOperation(Summary = "Salva um contrato")]
        [HttpPost]
        public Contrato Post(Contrato model)
        {
            _contratoRepository.Save(model);
            return model;
        }

        [SwaggerOperation(Summary = "Obtém lista com todos os contratos")]
        [HttpGet]
        public IEnumerable<Contrato> Get()
        {
            return _contratoRepository.GetAll();
        }

        [SwaggerOperation(Summary = "Obtém contrato pelo id")]
        [HttpGet]
        [Route("{id}")]
        public Contrato Get(long id)
        {
            return _contratoRepository.GetById(id);
        }

        [SwaggerOperation(Summary = "Lista contratos que o campo {key} contenha o valor {value}")]
        [HttpGet]
        [Route("search/{key}/{value}/{strict?}")]
        public IEnumerable<Contrato> Search(string key, string value, bool strict = true)
        {
            var where = new Dictionary<string, object>
            {
                { key, value }
            };
            return _contratoRepository.Search(where, strict);
        }
    }
}
