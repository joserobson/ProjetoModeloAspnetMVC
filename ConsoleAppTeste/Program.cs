using ConsoleAppTeste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://comfacilweb.gearhostpreview.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                for (int i = 1; i <= 10; i++)
                {

                    var fechamento = new FechamentoDiarioModel
                    {

                        ValorEntrada = "298,13",
                        ValorDaSaida = "50,00",
                        Saldo = "0,97",
                        Status = "",
                        DiaFechamento = "15/11/2018",
                        CaixaFinalDoDia = "3.332,10",
                        CaixaInicioDoDia = "403,00",
                        ValorDaRetirada = "3.060,00",
                        Funcionario = "João pppp",
                        Entradas = ObterEntradas(),
                        Saidas = ObterSaidas()
                    };

                    await SalvarFechamentoDiario(fechamento);
                }

                //GetFechamentosDiarioAsync("api/caixaapi");

                // Create a new product
                //Product product = new Product
                //{
                //    Name = "Gizmo",
                //    Price = 100,
                //    Category = "Widgets"
                //};

                //var url = await CreateProductAsync(product);
                //Console.WriteLine($"Created at {url}");

                //// Get the product
                //product = await GetProductAsync(url.PathAndQuery);
                //ShowProduct(product);

                //// Update the product
                //Console.WriteLine("Updating price...");
                //product.Price = 80;
                //await UpdateProductAsync(product);

                //// Get the updated product
                //product = await GetProductAsync(url.PathAndQuery);
                //ShowProduct(product);

                //// Delete the product
                //var statusCode = await DeleteProductAsync(product.Id);
                //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static async Task<IEnumerable<FechamentoDiarioModel>> GetFechamentosDiarioAsync(string path)
        {
            IEnumerable<FechamentoDiarioModel> fechamentos = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                fechamentos = await response.Content.ReadAsAsync<IEnumerable<FechamentoDiarioModel>>();
            }
            return fechamentos;
        }

        static async Task<HttpResponseMessage> SalvarFechamentoDiario(FechamentoDiarioModel fechamento)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/caixaapi/CadastrarFechamentoDiario", fechamento);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response;
        }

        private static IEnumerable<MovimentoCaixaModel> ObterEntradas()
        {
            var entradas = new List<MovimentoCaixaModel>();

            var movimentoCaixa = new MovimentoCaixaModel
            {
                Descricao = "PAG. VENDA VISTA 123",
                Valor = "44,00"
            };

            entradas.Add(movimentoCaixa);

            return entradas;
        }

        private static IEnumerable<MovimentoCaixaModel> ObterSaidas()
        {
            var saidas = new List<MovimentoCaixaModel>();

            var movimentoCaixa = new MovimentoCaixaModel
            {
                Descricao = "Rifa",
                Valor = "55,00"
            };

            saidas.Add(movimentoCaixa);

            return saidas;
        }
    }
}

