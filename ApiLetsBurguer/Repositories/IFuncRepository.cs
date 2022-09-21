using ApiLetsBurguer.Models;
using System;

namespace ApiLetsBurguer.Repositories
{
    public interface IFuncRepository
    {
        Task<IEnumerable<Func>> Get();

        Task<Func> Get(int Id);

        Task<Func> Create(Func func);

        Task Update(Func book);

        Task Delete (int Id);
    }
}
