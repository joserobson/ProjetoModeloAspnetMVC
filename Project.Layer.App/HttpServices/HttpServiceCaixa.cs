using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace Project.Layer.App.HttpServices
{
    public class HttpServiceCaixa
    {
        private static string UriString = WebConfigurationManager.AppSettings["URI_CAIXA"].ToString();


        public static HttpResponseMessage ObterFechamentos(int? numeroPagina, int? tamanhoPagina, string diaFechamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"ObterFechamentos?numeroPagina={numeroPagina}&tamanhoPagina={tamanhoPagina}&diaFechamento={diaFechamento}").Result;
            }
        }

        public static HttpResponseMessage ObterCountFechamentos(string diaFechamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"ObterCountFechamentos?diaFechamento={diaFechamento}").Result;
            }
        }

        public static HttpResponseMessage ObterEntradasDoDia(string diaFechamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"ObterEntradasDoCaixaPorDia?diaFechamento={diaFechamento}").Result;
            }
        }

        public static HttpResponseMessage ObterRetiradasDoDia(string diaFechamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"ObterRetiradasDoCaixaPorDia?diaFechamento={diaFechamento}").Result;
            }
        }

        internal static HttpResponseMessage ObterFechamentosDoMes(string mesAno)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"ObterFechamentosDoMes?mesAno={mesAno}").Result;
            }
        }
    }
}
