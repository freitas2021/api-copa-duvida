using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCopaStone.Data;
using ApiCopaStone.Models;

namespace ApiCopaStone.Models

{
    [Route("selecao")]
    public class SelecaoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Selecao>>> Get(
            [FromServices] DataContext context
        )
        {
            var selecao = await context
                .Selecaos
                .AsNoTracking()
                .ToListAsync();
            return Ok(selecao);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Selecao>> GetSelecaoById(
            int id,
            [FromServices] DataContext context
        )
        {
            var selecao = await context
                .Selecaos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
                
            return Ok(selecao);              
        }
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Selecao>> CriaSelecao(
            [FromServices] DataContext context,
            [FromBody] Selecao model
        )
        {
            if(ModelState.IsValid)
            {
                context.Selecaos.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            else
            {
                return BadRequest(ModelState);
            }

        
        }
    


    }
}