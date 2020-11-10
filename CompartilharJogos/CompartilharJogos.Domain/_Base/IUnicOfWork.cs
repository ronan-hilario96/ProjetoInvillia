using System.Threading.Tasks;

namespace CompartilharJogos.Domain._Base
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
