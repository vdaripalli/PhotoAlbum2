using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PhotoAlbum.Application
{
    public interface IBaseHttpClient
    {
        Task<T> Get<T>(string url);
    }

    public class BaseHttpClient : IBaseHttpClient
    {
        public async Task<T> Get<T>(string url)
        {
            T output = default(T);
            using (var client = GetClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    output =  await response.Content.ReadAsAsync<T>().ConfigureAwait(false);
                }
            }
            return output;
        }

        public static HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
