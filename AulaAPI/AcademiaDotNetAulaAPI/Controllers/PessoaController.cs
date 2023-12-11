using Microsoft.AspNetCore.Mvc;

namespace AcademiaDotNetAulaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        [Route("pessoa")]
        public string GetPessoaNome()
        {
            return "Meu nome é Lucas";
        }

        [HttpGet]
        [Route("pessoa/{idade}")]
        public string GetPessoaIdade([FromRoute] int idade)
        {
            return idade.ToString();
        }

        [HttpPost]
        [Route("pessoa")]
        public string PostPessoaNome([FromBody] string nome)
        {
            return "Meu nome é " + nome;
        }

        [HttpPost]
        [Route("pessoa/{idade}")]
        public string PostPessoaIdade([FromRoute] int idade, [FromBody] string nome)
        {
            return "Meu nome é " + nome + " e tenho " + idade + " anos";
        }
    }
}
