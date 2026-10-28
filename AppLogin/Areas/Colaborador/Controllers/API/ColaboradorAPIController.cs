using AppLogin.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppLogin.Areas.Colaborador.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorApiController : Controller
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorApiController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        // Listar todos os colaboradores
        [HttpGet]
        public IActionResult ListarColaboradores()
        {
            var colaboradores = _colaboradorRepository.ObterTodosColaboradores();
            return Ok(colaboradores);
        }

        // Cadastrar um novo colaborador
        [HttpPost]
        public IActionResult Post([FromBody] Models.Colaborador colaborador)
        {
            if (colaborador is null)
            {
                return BadRequest(new
                {
                    mensagem = "Os dados do colaborador são obrigatórios."
                });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _colaboradorRepository.Cadastrar(colaborador);

            return Ok(new
            {
                mensagem = "Cadastro realizado com sucesso.",
                colaborador = colaborador
            });
        }

        // Buscar colaborador por ID
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var colaborador = _colaboradorRepository.ObterColaborador(id);

            if (colaborador == null)
            {
                return NotFound(new
                {
                    mensagem = "Colaborador não encontrado"
                });
            }

            return Ok(colaborador);
        }

        // Atualizar um colaborador existente
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Models.Colaborador colaborador)
        {
            if (colaborador is null)
            {
                return BadRequest(new
                {
                    mensagem = "Os dados para atualização são obrigatórios."
                });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colaboradorExistente = _colaboradorRepository.ObterColaborador(id);
            if (colaboradorExistente == null)
            {
                return NotFound(new
                {
                    mensagem = "Colaborador não encontrado."
                });
            }

            colaborador.Id = id;
            _colaboradorRepository.Atualizar(colaborador);

            return Ok(new
            {
                mensagem = "Colaborador atualizado com sucesso."
            });
        }

        // Excluir um colaborador
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var colaborador = _colaboradorRepository.ObterColaborador(id);

            if (colaborador == null)
            {
                return NotFound(new
                {
                    mensagem = "Colaborador não encontrado."
                });
            }

            _colaboradorRepository.Excluir(id);

            return Ok(new
            {
                mensagem = "Colaborador excluído com sucesso."
            });
        }
    }
}