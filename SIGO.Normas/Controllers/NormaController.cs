using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIGO.Domain.Common;
using SIGO.Domain.Normas;
using SIGO.Normas.Data;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SIGO.Normas.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class NormaController : ControllerBase
    {
        private readonly ILogger<NormaController> _logger;
        private readonly IRepository<Norma> _normaRepository;
        private readonly NormaStorage _normaStorage;

        public NormaController(ILogger<NormaController> logger, IRepository<Norma> normaRepository, NormaStorage normaStorage)
        {
            _logger = logger;
            _normaRepository = normaRepository;
            _normaStorage = normaStorage;
        }

        [SwaggerOperation(Summary = "Salva os detalhes de uma norma")]
        [HttpPost]
        public Norma Post(Norma model)
        {
            _normaRepository.Save(model);
            return model;
        }

        [SwaggerOperation(Summary = "Obtém lista com todas as normas")]
        [HttpGet]
        public IEnumerable<Norma> Get()
        {
            return _normaRepository.GetAll();
        }

        [SwaggerOperation(Summary = "Obtém norma pelo id")]
        [HttpGet]
        [Route("{id}")]
        public Norma Get(long id)
        {
            return _normaRepository.GetById(id);
        }

        [SwaggerOperation(Summary = "Lista normas que o campo {key} contenha o valor {value}")]
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

        [SwaggerOperation(Summary = "Salva arquivo pelo id da norma")]
        [HttpPost]
        [Route("arquivo/{id}")]
        public async Task<IActionResult> UploadFile(long id, IFormFile formFile)
        {
            var model = _normaRepository.GetById(id);
            if (formFile == null || model == null || model.Id == 0)
            {
                return BadRequest();
            }
            var fileName = $"{id}";
            model.TipoArmazenamento = TipoArmazenamento.BLOB;
            model.TipoArquivo = formFile.ContentType;
            model.CaminhoArquivo = fileName;
            using (var stream = formFile.OpenReadStream())
            {
                await _normaStorage.UploadFileAsync(fileName, stream);
            }
            _normaRepository.Save(model);
            return Ok();
        }

        [SwaggerOperation(Summary = "Exclui arquivo pelo id da norma")]
        [HttpDelete]
        [Route("arquivo/{id}")]
        public async Task<IActionResult> DeleteFile(long id)
        {
            var model = _normaRepository.GetById(id);
            if (model == null || model.Id == 0)
            {
                return BadRequest();
            }
            await _normaStorage.DeleteFileAsync(model.CaminhoArquivo);
            model.TipoArmazenamento = TipoArmazenamento.NONE;
            model.TipoArquivo = "";
            model.CaminhoArquivo = "";
            _normaRepository.Save(model);
            return Ok();
        }

        [SwaggerOperation(Summary = "Obtém arquivo pelo id da norma")]
        [HttpGet]
        [Route("arquivo/{id}")]
        public async Task<IActionResult> DownloadFile(long id)
        {
            var model = _normaRepository.GetById(id);
            if (model == null || model.Id == 0)
            {
                return BadRequest();
            }
            else if (model.TipoArmazenamento != TipoArmazenamento.BLOB)
            {
                return NotFound();
            }
            var stream = new MemoryStream();
            await _normaStorage.DownloadFileAsync(model.CaminhoArquivo, stream);
            stream.Position = 0;
            return File(stream, model.TipoArquivo);
        }
    }
}
