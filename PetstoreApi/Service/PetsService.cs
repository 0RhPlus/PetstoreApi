using System;
using System.Net.Http;
using System.Threading.Tasks;
using PetstoreApi.Client;
using PetstoreApi.DTO;

namespace PetstoreApi.Service
{
	public class PetsService
	{
		private const string BaseUrl = "/v2/pet";
		private static readonly HttpClient Client = ApiClient.Instance;

		public static async Task<HttpResponseMessage> Create(PetDto petDto)
		{
			if (petDto == null)
			{
				throw new ArgumentNullException(nameof(petDto));
			}

			return await Client.PostAsJsonAsync(BaseUrl, petDto);
		}

		public static async Task<HttpResponseMessage> GetByStatus(string status)
		{
			if (status == String.Empty)
			{
				throw new ArgumentNullException(nameof(status));
			}

			return await Client.GetAsync($"{BaseUrl}/findByStatus?status={status}");
		}
	}
}
