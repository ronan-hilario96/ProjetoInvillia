using CompartilharJogos.Data.Context;
using CompartilharJogos.Domain._Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CompartilharJogos.Data.Repository
{
    public class RepositoryBase<TEntidade> : IRepository<TEntidade> where TEntidade : Entity
    {
        protected readonly ApplicationDbContext Context;
        public RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Save(TEntidade entity)
        {
            Context.Set<TEntidade>().Add(entity);
        }

        public virtual async Task<ICollection<TEntidade>> Consult()
        {
            return await Context.Set<TEntidade>().ToListAsync();
        }

        public virtual TEntidade GetById(int id)
        {
            var entitys = Context.Set<TEntidade>()
                .Where(iten => iten.Id == id);

            return entitys.Any() ? entitys.First() : null;
        }

        public void Delete(int id)
        {
            Context.Set<TEntidade>().Remove(Context.Set<TEntidade>().Find(id));
        }
    }
}
