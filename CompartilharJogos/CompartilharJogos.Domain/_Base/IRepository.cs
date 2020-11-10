using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompartilharJogos.Domain._Base
{
    public interface IRepository<TEntidade>
    {
        TEntidade GetById(int id);
        Task<ICollection<TEntidade>> Consult();
        void Save(TEntidade entity);
        void Delete(int id);
    }
}
