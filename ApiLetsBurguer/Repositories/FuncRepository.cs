using ApiLetsBurguer.Models;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;


namespace ApiLetsBurguer.Repositories
{
    public class FuncRepository : IFuncRepository
    {
        public readonly FuncContext _context;

        public FuncRepository(FuncContext context)
        {
            _context = context;
        }


        public async Task<Func> Create(Func func)
        {
            _context.Funcionarios.Add(func);
          await  _context.SaveChangesAsync();

            return func;
        }

        public async Task Delete(int id)
        {
            var funcToDelete = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcToDelete);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Func>> Get()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<Func> Get(int id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }

        public async Task Update(Func func)
        {
            _context.Entry(func).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
