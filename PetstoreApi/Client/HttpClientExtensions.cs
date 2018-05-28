using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PetstoreApi.Client
{
    public static class HttpClientExtensions
    {
		public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string url, T value) 
			where T : class
		{
			var content = new StringContent(JsonConvert.SerializeObject(value));
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			return await client.PostAsync(url, content);
		}
	}
}
