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
    public class SucursalController : ControllerBase
    {
        private readonly ApplicationDataContext _dataContext;

        public SucursalController(ApplicationDataContext dataContext)
        {
            _dataContext = dataContext;

        }
            // Peticion para obtener las  sucursales
            [HttpGet("GetAll")]
            public async Task<ActionResult<List<Sucursal>>> GetSucursales()
            {
            // Retornar lista con todas las sucursales
            return await _dataContext.Sucursales.ToListAsync();
            }

        [HttpGet("Get/{idSucursal}")]
        public async Task<IActionResult> GetSucursal(int? idSucursal)
            {
                Sucursal sucursal= await _dataContext.Sucursales.FirstOrDefaultAsync(s => s.IdSucursal == idSucursal);

                if (sucursal == null)
                {
                    return NotFound($"La sucursal con la id {idSucursal} no existe");
                }

                return Ok(sucursal);

        }

        [HttpPost("Create")]
            public async Task<IActionResult> CreateSucursal([FromBody] Sucursal nuevaSucursal)
            {
                try
                {
                    // Validar si el objecto viene vacio
                    if (nuevaSucursal == null)
                    {
                        return BadRequest("Error: Modelo de Sucursal está vacio");
                    }

                    // Validar si no posee la misma id que otro objecto
                    if (await _dataContext.Sucursales
                        .AsNoTracking()
                        .AnyAsync(s =>s.IdSucursal  == nuevaSucursal.IdSucursal))
                    {
                        return BadRequest("Error: El id no es valido");
                    }

                    // Validar si no posee el mismo nombre que otra sucursal
                    if (await _dataContext.Sucursales.AsNoTracking().AnyAsync(s => s.NombreSucursal.ToLower() == nuevaSucursal.NombreSucursal.ToLower()))
                    {
                        return BadRequest("Error: Ya existe una sucursal con el mismo nombre");
                    }

                    // Pasa las validaciones y se guarda en la base de datos
                    _dataContext.Add(nuevaSucursal);
                    await _dataContext.SaveChangesAsync();

                    return Ok();
                }
                catch
                {
                    return BadRequest("Error");
                }
            }

            [HttpDelete("Delete/{idSucursal}")]
            public async Task<IActionResult> BorrarSucursal(int? idSucursal)
            {
                Sucursal sucursal= await _dataContext.Sucursales.FirstOrDefaultAsync(s => s.IdSucursal== idSucursal);

                if (sucursal == null)
                {
                    return BadRequest("La sucursal no existe");
                }
                else
                {
                    _dataContext.Remove(sucursal);
                    await _dataContext.SaveChangesAsync();
                    return Ok("Sucursal eliminada");
                }
            }

            [HttpPut("Edit/{idSucursal}")]
            public async Task<IActionResult> UpdateSucursal([FromRoute] int idSucursal, [FromBody] Sucursal sucursal)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dataContext.Entry(sucursal).State = EntityState.Modified;

                try
                {
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalExists(idSucursal))
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

            private bool SucursalExists(int idSucursal)
            {
                return _dataContext.Sucursales.Any(s => s.IdSucursal == idSucursal);
            }
        }
    }

