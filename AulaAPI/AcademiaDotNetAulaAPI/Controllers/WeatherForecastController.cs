using Microsoft.AspNetCore.Mvc;

namespace AcademiaDotNetAulaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        [Route("hello")]
        public string HelloWorld()
        {
            return "Hello world atos UFN 2023";
        }

        [HttpPost]
        [Route("hello")]
        public string HelloWorld([FromBody] string nome)
        {
            return "Hello world atos UFN 2023" + nome;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

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
