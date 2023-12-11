using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ConsoleApp_ConsumirAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string baseUrl = "https://localhost:7092/";

            Console.WriteLine("Digite 1 para consultar e 2 para cadastrar: ");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    List<Pessoa>? pessoas = new();
                    HttpClient client = new();
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.GetAsync("api/entity/pessoas");

                    if (res.IsSuccessStatusCode)
                    {
                        var response = res.Content.ReadAsStringAsync().Result;

                        pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(response);

                        foreach (Pessoa item in pessoas)
                        {
                            Console.WriteLine(item.Id + " - " + item.Nome);
                        }
                    }

                    break;
                case 2:
                    Pessoa pessoa = new();
                    pessoa.Nome = "Post na API";
                    HttpClient clientPost = new();
                    HttpResponseMessage resPost = await clientPost.PostAsJsonAsync(
                        baseUrl + "api/entity/pessoas", pessoa);

                    if (resPost.IsSuccessStatusCode)
                    {
                        await Console.Out.WriteLineAsync("Cadastrado com sucesso.");
                    }
                    break;
            }
        }
    }
}
