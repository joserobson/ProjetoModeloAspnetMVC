using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace Project.Layer.App.HttpServices
{
    public class HttpServiceEstoque
    {
        private static string UriString = WebConfigurationManager.AppSettings["Endereco_WebService_Estoque"].ToString();

        public static HttpResponseMessage ObterRelatorioDeProdutos()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"api/produto/ObterProdutosParaRelatorio").Result;
            }
        }
    }
}
