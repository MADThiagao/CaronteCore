using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CaronteCore.Utils
{
    public class RequestHelper
    {
        const string urlServidor = "http://localhost:10397/api/";

        public static async Task<T> PostAsync<T>(string uri, object obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlServidor);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent conteudo = new StringContent(JsonConvert.SerializeObject(obj));
                conteudo.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(uri, conteudo);
                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }

                return default(T);
            }
        }

        public static T Post<T>(string controller, string action, object obj)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlServidor);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent conteudo = new StringContent(JsonConvert.SerializeObject(obj));
                conteudo.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                try
                {
                    HttpResponseMessage response = client.PostAsync(ResolveUrl(controller, action), conteudo).Result;
                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }

                return default(T);
            }
        }
        
        public static async Task<T> GetAsync<T>(string controller, int idUsuario, string action, int? id = null)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlServidor);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync(ResolveUrl(controller, action, idUsuario, id));
                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }

                return default(T);
            }
        }

        public static T Get<T>(string controller, int idUsuario, string action, int? id = null)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlServidor);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = client.GetAsync(ResolveUrl(controller, action, idUsuario, id)).Result;

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }

                return default(T);
            }
        }

        public static string ResolveUrl(string controller, string action, int? idUsuario = null, int? id = null)
        {
            if (idUsuario.HasValue)
                if (id.HasValue)
                    return string.Concat(controller, "/", idUsuario, "/", action, "/", id);
                else
                    return string.Concat(controller, "/", idUsuario, "/", action);
            else
                return string.Concat(controller, "/", action);
        }
    }
}
