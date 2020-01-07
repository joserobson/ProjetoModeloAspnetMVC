using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace Project.Layer.App.HttpServices
{
    public class HttpServiceGlobal
    {
        private static string UriString = WebConfigurationManager.AppSettings["Endereco_WebService_Global"].ToString();

        public static HttpResponseMessage ObterNomeDoFuncionario(string IdFuncionario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"api/funcionario/BuscarFuncionarioPorId?Id={IdFuncionario}").Result;
            }
        }

        internal static HttpResponseMessage ObterTodosOsFuncionarios()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"api/funcionario/BuscarTodosOsFuncionarios").Result;
            }
        }

        public static HttpResponseMessage ObterClientes(string nome)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"api/cliente/ObterClientes?Nome={nome}").Result;
            }
        }
    }
}
    