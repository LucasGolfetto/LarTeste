using LarTeste_API.Data;
using LarTeste_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LarTeste_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Pessoa>> GetPessoas()
        {
            return Ok(PessoaData.pessoaList);
        }

        [HttpGet("{id:int}", Name = "GetPessoa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pessoa> GetPessoa(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }

            var pessoa = PessoaData.pessoaList.FirstOrDefault(u => u.Id == id);
            if(pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pessoa> CreatePessoa([FromBody]Pessoa pessoa)
        {            
            if (pessoa == null)
            {
                return BadRequest(pessoa);
            }
            if (pessoa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            pessoa.Id = PessoaData.pessoaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            PessoaData.pessoaList.Add(pessoa);

            return CreatedAtRoute("GetPessoa", new { id = pessoa.Id }, pessoa);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeletePessoa")]
        public IActionResult DeletePessoa(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var pessoa = PessoaData.pessoaList.FirstOrDefault(u => u.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            PessoaData.pessoaList.Remove(pessoa);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdatePessoa")]
        public IActionResult UpdatePessoa(int id, [FromBody] Pessoa pessoa)
        {
            if (pessoa == null || id != pessoa.Id)
            {
                return BadRequest();
            }
            var pessoaUpdate = PessoaData.pessoaList.FirstOrDefault(u => u.Id == id);

            pessoaUpdate.Nome = pessoa.Nome;
            pessoaUpdate.CPF = pessoa.CPF;
            pessoaUpdate.DataNascimento = pessoa.DataNascimento;
            pessoaUpdate.EstaAtivo = pessoa.EstaAtivo;

            return NoContent();
        }
    }
}
