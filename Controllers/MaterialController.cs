using fantasy_life_i_material_API.Models;
using fantasy_life_i_material_API.Services.MaterialService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var material = await this._materialService.GetMaterialAsync(id);
            if (material is null)
            {
                return NotFound();
            }
            return Ok(material);
        }
        //[HttpPost]
        //public ActionResult<Material> AddMaterial(Material newMaterial)
        //{
        //    if(newMaterial is null)
        //    {
        //        return BadRequest();
        //    }
        //    //increment Id
        //    newMaterial.Id = materials.Max(m => m.Id) +1;
        //    materials.Add(newMaterial);
        //    return CreatedAtAction(nameof(GetMaterialById), new { id = newMaterial.Id }, newMaterial);
        //}
        //[HttpPut("{id}")]
        //public IActionResult UpdateMaterial (int id, Material updatedMaterial)
        //{
        //    var material = materials.FirstOrDefault(m => m.Id == id);
        //    if(material is null)
        //    {
        //        return NotFound();
        //    }
        //    material.Name = updatedMaterial.Name;
        //    material.Type = updatedMaterial.Type;
        //    material.Gatherable = updatedMaterial.Gatherable;
        //    material.GatheredFrom = updatedMaterial.GatheredFrom;
        //    material.LifeRequired = updatedMaterial.LifeRequired;
        //    material.Category = updatedMaterial.Category;

        //    return NoContent();
        //}
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
