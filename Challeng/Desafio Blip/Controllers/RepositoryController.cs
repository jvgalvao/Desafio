using Desafio_Blip.Models;
using Desafio_Blip.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Blip.Controllers
{
 [Route("Api/")]
 [ApiController]
public class RepositoryController: ControllerBase
    {
        private readonly IRepositoryRepository _repositoryRepository;
        public RepositoryController(IRepositoryRepository repositoryRepository)
        {
            _repositoryRepository = repositoryRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Repository>>> FindRepository()
        {
            var ListResponse =await _repositoryRepository.FindRepository();
            if (ListResponse == null)
            {
                return NotFound();
            }
            return Ok(ListResponse);
        }
        
    }
}
