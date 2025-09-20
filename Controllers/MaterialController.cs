using fantasy_life_i_material_API.Models;
using fantasy_life_i_material_API.Services.MaterialService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fantasy_life_i_material_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            this._materialService = materialService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Material>>> GetAllAsync()
        {
            return Ok(await _materialService.ListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterialById(int id)
        {
            //var material = await materials.FirstOrDefault(m => m.Id == id);
            var material = await this._materialService.GetAsync(id);
            if (material is null)
            {
                return NotFound();
            }
            return Ok(material);
        }
        [HttpPost]
        public async Task<ActionResult<Material>> AddMaterial(Material newMaterial)
        {
            if(newMaterial is null)
            {
                return BadRequest();
            }
            await _materialService.SaveAsync(newMaterial);

            return CreatedAtAction(nameof(GetMaterialById), new { id = newMaterial.Id }, newMaterial);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial (int id, Material updatedMaterial)
        {
            var result  = await _materialService.UpdateAsync(id, updatedMaterial);
            if(result is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        //[HttpDelete("{id}")]
        //public IActionResult DeleteMaterial(int id) 
        //{
        //    var material = materials.FirstOrDefault(m => m.Id == id);
        //    if (material is null)
        //    {
        //        return NotFound();
        //    }
        //    materials.Remove(material);
        //    return NoContent();
        //}
    }
}
