using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fantasy_life_i_material_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        static private List<Material> materials = new List<Material>
        {
            new Material
            {
                Id = 1,
                Name = "Starry Log",
                Type = "Log",
                Gatherable = true,
                GatheredFrom = ["Starry Tree","Great Starry Tree"],
                LifeRequired = "Woodcuter",
                Category="Carpentry Material"
            },
            new Material
            {
                Id = 2,
                Name = "Swolean Gold",
                Type = "Ore",
                Gatherable = true,
                GatheredFrom = [
                    "Gold Deposit","Great Gold Deposit",
                    "Superior Gold Deposit","Amazing Gold Deposit"
                    ],
                LifeRequired = "Miner",
                Category="Smithing Material"
            },
            new Material
            {
                Id = 3,
                Name = "Sunny Puff",
                Type = "Plant",
                Gatherable = true,
                GatheredFrom = ["Ground"],
                LifeRequired = null,
                Category="Tailoring Material"
            },
            new Material
            {
                Id = 4,
                Name = "Red Anthurium",
                Type = "Plant",
                Gatherable = true,
                GatheredFrom = ["Ground"],
                LifeRequired = null,
                Category="Artistry Material"
            }
        };
        [HttpGet]
        public ActionResult<List<Material>> GetMaterials()
        {
            return Ok(materials);
        }
        [HttpGet("{id}")]
        public ActionResult<Material> GetMaterialById(int id)
        {
            var material = materials.FirstOrDefault(m => m.Id == id);
            if (material is null)
            {
                return NotFound();
            }
            return Ok(material);
        }
        [HttpPost]
        public ActionResult<Material> AddMaterial(Material newMaterial)
        {
            if(newMaterial is null)
            {
                return BadRequest();
            }
            //increment Id
            newMaterial.Id = materials.Max(m => m.Id) +1;
            materials.Add(newMaterial);
            return CreatedAtAction(nameof(GetMaterialById), new { id = newMaterial.Id }, newMaterial);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMaterial (int id, Material updatedMaterial)
        {
            var material = materials.FirstOrDefault(m => m.Id == id);
            if(material is null)
            {
                return NotFound();
            }
            material.Name = updatedMaterial.Name;
            material.Type = updatedMaterial.Type;
            material.Gatherable = updatedMaterial.Gatherable;
            material.GatheredFrom = updatedMaterial.GatheredFrom;
            material.LifeRequired = updatedMaterial.LifeRequired;
            material.Category = updatedMaterial.Category;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(int id) 
        {
            var material = materials.FirstOrDefault(m => m.Id == id);
            if (material is null)
            {
                return NotFound();
            }
            materials.Remove(material);
            return NoContent();
        }
    }
}
