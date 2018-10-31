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

        public static HttpResponseMessage ObterEntradasDoDia(int idFechamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"ObterEntradasDoDia?idFechamento={idFechamento}").Result;
            }
        }

        public static HttpResponseMessage ObterRetiradasDoDia(int idFechamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetAsync($"ObterRetiradasDoDia?idFechamento={idFechamento}").Result;
            }
        }
    }
}
