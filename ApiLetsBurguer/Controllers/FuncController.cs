using ApiLetsBurguer.Models;
using ApiLetsBurguer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiLetsBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncController : ControllerBase
    {
        private readonly IFuncRepository _funcRepository;
        public FuncController(IFuncRepository funcRepository)
        {
            _funcRepository = funcRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Func>> GetFuncionarios()
        {
            return await _funcRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Func>> GetFuncionarios(int id)
        {
            return await _funcRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Func>> PostFuncionarios([FromBody] Func func)
        {
            var newFunc = await _funcRepository.Create(func);
            return CreatedAtAction(nameof(GetFuncionarios), new { id = newFunc.Id }, newFunc);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _funcRepository.Get(id);

            if (bookToDelete == null)
                return NotFound();

            await _funcRepository.Delete(bookToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult?> PutFunc(int id, [FromBody] Func func)
        {
            if (id != func.Id)
                return BadRequest();

                await _funcRepository.Update(func);
            return NoContent();
        }

    }
}
