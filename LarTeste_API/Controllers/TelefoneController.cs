using LarTeste_API.Data;
using LarTeste_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LarTeste_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Telefone>> GetTelefones()
        {
            return Ok(TelefoneData.telefoneList);
        }

        [HttpGet("{id:int}", Name = "GetTelefone")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Telefone> GetTelefone(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var telefone = TelefoneData.telefoneList.FirstOrDefault(u => u.Id == id);
            
            if (telefone == null)
            {
                return NotFound();
            }

            return Ok(telefone);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Telefone> CreateTelefone([FromBody] Telefone telefone)
        {
            if(TelefoneData.telefoneList.FirstOrDefault(u => u.Numero.ToLower() == telefone.Numero.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Este Número de Telefone Já Está Cadastrado!");
                return BadRequest(ModelState);
            }

            if (telefone == null)
            {
                return BadRequest(telefone);
            }
            if (telefone.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            telefone.Id = TelefoneData.telefoneList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            TelefoneData.telefoneList.Add(telefone);

            return CreatedAtRoute("GetTelefone", new { id = telefone.Id }, telefone); ;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteTelefone")]
        public IActionResult DeleteTelefone(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var telefone = TelefoneData.telefoneList.FirstOrDefault(u => u.Id == id);
            if (telefone == null)
            {
                return NotFound();
            }
            TelefoneData.telefoneList.Remove(telefone);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateTelefone")]
        public IActionResult UpdateTelefone(int id, [FromBody]Telefone telefone)
        {
            if (telefone == null || id != telefone.Id)
            {
                return BadRequest();
            }
            var telefoneUpdate = TelefoneData.telefoneList.FirstOrDefault(u => u.Id == id);

            telefoneUpdate.Numero = telefone.Numero;
            telefoneUpdate.Tipo = telefone.Tipo;
            telefoneUpdate.IsWhatsApp = telefone.IsWhatsApp;
            telefoneUpdate.PessoaId = telefone.PessoaId;

            return NoContent();
        }
    }
}
