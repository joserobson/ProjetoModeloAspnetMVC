using Project.Layer.App.AppModels;
using System.Net.Http;

namespace Project.Layer.App.Helper
{
    public class HttpServiceHelper
    {
        public static string ObterMensagemHttpResponse(HttpResponseMessage httpResponse)
        {
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var messagemViewModel = httpResponse.Content.ReadAsAsync<RespostaAppViewModel>().Result;
                return messagemViewModel.Message;
            }

            return httpResponse.Content.ReadAsStringAsync().Result;
        }
    }
}
