using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCopaStone.Data;
using ApiCopaStone.Models;

namespace ApiCopaStone.Controllers
{
    [Route("jogo")]
    public class JogoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Jogo>>> PegaJogos(
            [FromServices] DataContext context
        )
        {
            var jogo = await context
                .Jogos      
                .AsNoTracking()
                .ToListAsync();
            return Ok(jogo);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Jogo>> PegaJogoById(
            int id,
            [FromServices] DataContext context
        )
        {
            var jogo = await context
                .Jogos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(jogo);
        }
        //1:49 Se quisermos fazer um filtro
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Jogo>>> CriaJogo(
            [FromServices] DataContext context,
            [FromBody] Jogo model
        )
        {
            if (ModelState.IsValid)
            {
                context.Jogos.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Jogo>>> AtualizaJogo(
           int id,
           [FromBody] Jogo model,
           [FromServices] DataContext context
       )
        {
            if (id != model.Id)
            {
                return NotFound(new { message = "Jogo não encontrado" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                context.Entry<Jogo>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este Registro já foi atualizado" });
            }
            catch
            {
                return BadRequest(new { message = "Não Foi possível atualizar o jogo" });
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Admin>>> ApagaJogo(
            int id,
            [FromServices] DataContext context
        )
        {
            var jogo = await context.Jogos.FirstOrDefaultAsync(x => x.Id == id);
            {
                if (jogo == null)
                {
                    return NotFound(new { message = "Jogo não encontrado!" });
                }
            }
            try
            {
                context.Jogos.Remove(jogo);
                await context.SaveChangesAsync();
                return Ok(new { message = "Jogo removido com sucesso!" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível remover o jogo!" });
            }
        }

    }
}