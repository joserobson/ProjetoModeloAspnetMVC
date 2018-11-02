using ConsoleAppTeste.Model;
using Project.Layer.App.AppModels.Venda;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
            //client.BaseAddress = new Uri("http://comfacilweb.gearhostpreview.com/");

            client.BaseAddress = new Uri("http://localhost/ModeloAspNetMvc/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {

                //TestFechamentoDiarioResp();

                //TestResumoFinanceiroRest();

                //ObterFechamentosSqlServer();

                TestCadastrarResumoDebitosAReceberRest();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private async static void TestResumoFinanceiroRest()
        {


            var resumo = new ResumoFinanceiroMensalAppModel
            {
                MesAnoReferencia = "10/2015"
            };

            var resumos = new List<ResumoFinanceiroMensalAppModel>() { resumo };


            await SalvarResumosFinanceiros(resumos);


        }

        private async static void TestCadastrarResumoDebitosAReceberRest()
        {

            var resumo = new ResumoDebitosAReceberAppModel
            {
                DataReferencia = "01/10/1985",
                ValorAReceber = 10000,
                ValorRetroativo = 50
            };

            var resumos = new List<ResumoDebitosAReceberAppModel>() { resumo };


            var response = await SalvarResumosDebitosAReceber(resumos);

            var sucess = response.IsSuccessStatusCode;

        }

        private async static void TestObterResumoDebitosAReceberRest()
        {
            var dataReferencia = "01/10/2018";
            await GetResumoDebitosARecerAsync(dataReferencia);

        }

        private async static void TestFechamentoDiarioResp()
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

        static async Task<HttpResponseMessage> SalvarResumosFinanceiros(IEnumerable<ResumoFinanceiroMensalAppModel> resumos)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/vendaApi/CadastrarResumosFinanceiros", resumos);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response;
        }

        private async static void ObterFechamentosSqlServer()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://painelcomfacil.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/caixaapi/ObterFechamentos");

            if (response.IsSuccessStatusCode)
            {
                var fechamentos = await response.Content.ReadAsAsync<IEnumerable<FechamentoDiarioModel>>();

                foreach (var item in fechamentos)
                {
                    var resposta = await SalvarFechamentoDiario(item);

                    if (!resposta.IsSuccessStatusCode)
                    {
                        break;
                    }
                }
            }

        }

        static async Task<HttpResponseMessage> SalvarResumosDebitosAReceber(IEnumerable<ResumoDebitosAReceberAppModel> resumos)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/vendaApi/CadastrarResumoDebitosAReceber", resumos);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response;
        }

        static async Task<IEnumerable<ResumoDebitosAReceberAppModel>> GetResumoDebitosARecerAsync(string dataReferencia)
        {
            IEnumerable<ResumoDebitosAReceberAppModel> resumos = null;
            HttpResponseMessage response = await client.GetAsync($"api/vendaApi/ObterResumoDebitosAReceber?datareferencia={dataReferencia}");
            if (response.IsSuccessStatusCode)
            {
                resumos = await response.Content.ReadAsAsync<IEnumerable<ResumoDebitosAReceberAppModel>>();
            }
            return resumos;
        }

    }
}

