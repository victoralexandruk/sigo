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
    public class EmpresaController : ControllerBase
    {
        private readonly ILogger<EmpresaController> _logger;
        private readonly IRepository<Empresa> _empresaRepository;

        public EmpresaController(ILogger<EmpresaController> logger, IRepository<Empresa> empresaRepository)
        {
            _logger = logger;
            _empresaRepository = empresaRepository;
        }

        [SwaggerOperation(Summary = "Salva uma empresa")]
        [HttpPost]
        public Empresa Post(Empresa model)
        {
            _empresaRepository.Save(model);
            return model;
        }

        [SwaggerOperation(Summary = "Obtém lista com todas as empresas")]
        [HttpGet]
        public IEnumerable<Empresa> Get()
        {
            return _empresaRepository.GetAll();
        }

        [SwaggerOperation(Summary = "Obtém empresa pelo id")]
        [HttpGet]
        [Route("{id}")]
        public Empresa Get(long id)
        {
            return _empresaRepository.GetById(id);
        }

        [SwaggerOperation(Summary = "Lista empresas que o campo {key} contenha o valor {value}")]
        [HttpGet]
        [Route("search/{key}/{value}/{strict?}")]
        public IEnumerable<Empresa> Search(string key, string value, bool strict = true)
        {
            var where = new Dictionary<string, object>
            {
                { key, value }
            };
            return _empresaRepository.Search(where, strict);
        }
    }
}
