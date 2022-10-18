using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCopaStone.Data;
using ApiCopaStone.Models;
//1:00 hora
namespace ApiCopaStone.Controllers
{

    [Route("admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Admin>>> Get(
            [FromServices] DataContext context
        )
        {
            var admins = await context.Admins.AsNoTracking().ToListAsync();
            return Ok(admins);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Admin>> GetById(
            int id,
            [FromServices] DataContext context
        )
        {
            var admins = await context.Admins.AsNoTracking().FirstOrDefaultAsync(x => x.AdminId == id);
            return Ok(admins);                
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Admin>>> CriaAdmin(
            [FromBody] Admin model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
            context.Admins.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
            }
            catch 
            {
                return BadRequest(new { message = "Não foi possível criar o Administrador"});
            }
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Admin>>> Put(
            int id, 
            [FromBody] Admin model,
            [FromServices]DataContext context
        )
        {
            if (id != model.AdminId)
            {
                return NotFound(new { message = "Administrador não encontrado" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                context.Entry<Admin>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new {message = "Este Registro já foi atualizado"});
            }
            catch
            {
                return BadRequest(new { message = "Não Foi possível atualizar o Administrador"});
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Admin>>> Delete(
            int id,
            [FromServices]DataContext context
        )
        {
            var admin = await context.Admins.FirstOrDefaultAsync(x => x.AdminId == id);
            {
                if (admin == null)
                {
                    return NotFound( new { message = "Administrador não encontrado!"});
                }
            }
            try
            {
                context.Admins.Remove(admin);
                await context.SaveChangesAsync();
                return Ok(new { message = "Admnistrador removido com sucesso!"});
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível remover o Administrador!"});
            }
        }
    }
}