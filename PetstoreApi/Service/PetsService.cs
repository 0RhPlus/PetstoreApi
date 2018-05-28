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
				throw new System.ArgumentNullException(nameof(petDto));
			}

			return await Client.PostAsJsonAsync(BaseUrl, petDto);
		}
	}
}
