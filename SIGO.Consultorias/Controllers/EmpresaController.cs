using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIGO.Domain.Common;
using SIGO.Domain.Consultorias;
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

        [HttpPost]
        public Empresa Post(Empresa model)
        {
            _empresaRepository.Save(model);
            return model;
        }

        [HttpGet]
        public IEnumerable<Empresa> Get()
        {
            return _empresaRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Empresa Get(long id)
        {
            return _empresaRepository.GetById(id);
        }

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
