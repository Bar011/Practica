using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practica.Server.Data;
using Practica.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Practica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodegaController : ControllerBase
    {
        // La base de datos.
        private readonly ApplicationDataContext _dataContext;

        // El constructor
        public BodegaController(ApplicationDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // Peticion para obtener las bodegas
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Bodega>>> GetBodegas()
        {
            // Retornar lista con todas las personas
            return await _dataContext.Bodegas.ToListAsync();
        }

        [HttpGet("Get/{idBodega}")]
        public async Task<IActionResult> GetBodega(int? IdBodega)
        {
            Bodega bodega = await _dataContext.Bodegas.FirstOrDefaultAsync(b => b.ID_Bodega == IdBodega);

            if (bodega == null)
            {
                return NotFound($"La bodega con la id {IdBodega} no existe");
            }

            return Ok(bodega);

        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBodega([FromBody] Bodega nuevaBodega)
        {
            try
            {
                // Validar si el objecto viene vacio
                if (nuevaBodega == null)
                {
                    return BadRequest("Error: Modelo Bodega vacio");
                }

                // Validar si no posee la misma id que otro objecto
                if (await _dataContext.Bodegas
                    .AsNoTracking()
                    .AnyAsync(bodega => bodega.ID_Bodega == nuevaBodega.ID_Bodega)) 
                {
                    return BadRequest("Error: El id no es valido");
                }

                // Validar si no posee el mismo nombre que otra ciudad
                if (await _dataContext.Bodegas.AsNoTracking().AnyAsync(bodegas => bodegas.NombreBodega.ToLower() == nuevaBodega.NombreBodega.ToLower()))
                {
                    return BadRequest("Error: Ya existe una ciudad con el mismo nombre");
                }

                // Pasa las validaciones y se guarda en la base de datos
                _dataContext.Add(nuevaBodega);
                await _dataContext.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete("Delete/{idBodega}")]
        public async Task<IActionResult> DeleteBodega(int? idBodega)
        {
            Bodega bodega= await _dataContext.Bodegas
                .FirstOrDefaultAsync(b => b.ID_Bodega == idBodega);

            if (bodega == null)
            {
                return BadRequest("La bodega no existe");
            }
            else
            {
                _dataContext.Remove(bodega);
                await _dataContext.SaveChangesAsync();
                return Ok("bodega");
            }
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> UpdateBodega([FromRoute] int idBodega, [FromBody] Bodega bodega)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dataContext.Entry(bodega).State = EntityState.Modified;

            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodegaExist(idBodega))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        private bool BodegaExist(int idBodega)
        {
            return _dataContext.Bodegas.Any(b => b.ID_Bodega == idBodega);
        }
    }
}
       