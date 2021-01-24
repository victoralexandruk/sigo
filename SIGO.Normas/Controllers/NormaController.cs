using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIGO.Domain.Common;
using SIGO.Domain.Normas;
using System.Collections.Generic;

namespace SIGO.Normas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NormaController : ControllerBase
    {
        private readonly ILogger<NormaController> _logger;
        private readonly IRepository<Norma> _normaRepository;

        public NormaController(ILogger<NormaController> logger, IRepository<Norma> normaRepository)
        {
            _logger = logger;
            _normaRepository = normaRepository;
        }

        [HttpGet]
        public IEnumerable<Norma> Get()
        {
            return _normaRepository.Get();
        }
    }
}
