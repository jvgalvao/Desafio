using Desafio_Blip.Models;

namespace Desafio_Blip.Repositories.Interfaces

{
    public interface IRepositoryRepository
    {
        Task<List<Repository>> FindRepository();
    }
}
