using PetManager.Manager;
using PetManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace PetManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly PetServices _service;

        public PetController(PetServices service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> GetAllPets()
        {
            return Ok(_service.GetAllPets());
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetPetById(int id)
        {
            var Pet = _service.GetPetById(id);
            if (Pet == null)
            {
                return NotFound();
            }
            return Ok(Pet);
        }

        [HttpPost]
        public ActionResult AddPet(Pet Pet)
        {
            _service.AddPet(Pet);
            return CreatedAtAction(nameof(GetPetById), new { id = Pet.PetId }, Pet);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePet(int id, Pet Pet)
        {
            var existingPet = _service.GetPetById(id);
            if (existingPet == null)
            {
                return NotFound();
            }
            _service.UpdatePet(id, Pet);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id)
        {
            var Pet_to_delete = _service.GetPetById(id);
            if (Pet_to_delete == null)
            {
                return NotFound();
            }
            _service.DeletePet(id);
            return NoContent();
        }
    }
}
