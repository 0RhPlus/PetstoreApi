using System;
using System.Net.Http;
using System.Threading.Tasks;
using PetstoreApi.Client;

namespace PetstoreApi.Service
{
	public class PetsService
	{
		private const string BaseUrl = "/v2/pet";
		private static readonly HttpClient Client = ApiClient.Instance;

		public static async Task<HttpResponseMessage> Create(object petDto)
		{
			if (petDto == null)
			{
				throw new ArgumentNullException(nameof(petDto));
			}

			return await Client.PostAsJsonAsync(BaseUrl, petDto);
		}

		public static async Task<HttpResponseMessage> GetByStatus(string status)
		{
			if (status == string.Empty)
			{
				throw new ArgumentNullException(nameof(status));
			}

			return await Client.GetAsync($"{BaseUrl}/findByStatus?status={status}");
		}

		public static async Task<HttpResponseMessage> GetById(long id)
		{
			if (id <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(id));
			}

			return await Client.GetAsync($"{BaseUrl}/{id}");
		}
	}
}
