using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCopaStone.Data;
using ApiCopaStone.Models;

namespace WepApiBalta.Controllers
{
    [Route("fasecopa")]
    public class FaseCopaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Jogo>>> ListarFaseCopa(
            [FromServices] DataContext context
        )
        {
            var faseCopa = await context
                .FaseCopas
                .AsNoTracking()
                .ToListAsync();
            return Ok(faseCopa);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<FaseCopa>> PegaFaseCopaById(
            int id,
            [FromServices] DataContext context
        )
        {
            var faseCopa = await context
                .FaseCopas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.FaseCopaId == id);

            return Ok(faseCopa);
        }

        [Route("")]
        public async Task<ActionResult<FaseCopa>> CriaFaseCopa(
            [FromServices] DataContext context,
            [FromBody] FaseCopa model
        )
        {
            if (ModelState.IsValid)
            {
                context.FaseCopas.Add(model);
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
        public async Task<ActionResult<List<FaseCopa>>> AtualizaFaseCopa(
           int id,
           [FromBody] FaseCopa model,
           [FromServices] DataContext context
       )
        {
            if (id != model.FaseCopaId)
            {
                return NotFound(new { message = "Fase da copa não encontrada" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                context.Entry<FaseCopa>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este Registro já foi atualizado" });
            }
            catch
            {
                return BadRequest(new { message = "Não Foi possível atualizar a fase da copa" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Admin>>> ApagaFaseCopa(
            int id,
            [FromServices] DataContext context
        )
        {
            var faseCopa = await context.FaseCopas.FirstOrDefaultAsync(x => x.FaseCopaId == id);
            {
                if (faseCopa == null)
                {
                    return NotFound(new { message = "Fase da copa não encontrada!" });
                }
            }
            try
            {
                context.FaseCopas.Remove(faseCopa);
                await context.SaveChangesAsync();
                return Ok(new { message = "Fase da copa removida com sucesso!" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível a fase da copa!" });
            }
        }

    }
}