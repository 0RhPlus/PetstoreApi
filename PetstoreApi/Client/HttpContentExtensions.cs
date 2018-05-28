using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PetstoreApi.Client
{
    public static class HttpContentExtensions
    {
		public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
			where T : class
		{
			return JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync());
		}
	}
}
