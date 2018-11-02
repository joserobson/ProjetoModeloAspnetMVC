using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace Project.Layer.App.HttpServices
{
    public class HttpServiceVenda
    {
        private static string UriString = WebConfigurationManager.AppSettings["URI_VENDA"].ToString();

        public static HttpResponseMessage ObterDebitosDosClientesAReceber(string dataDeReferencia)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"ObterDebitosAReceber?dataReferencia={dataDeReferencia}").Result;
            }
        }


        public static HttpResponseMessage ObterResumoFinanceiroDoMes(string mesAno)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"ObterResumoFinanceiroMensal?mesAno={mesAno}").Result;
            }
        }
    }
}
