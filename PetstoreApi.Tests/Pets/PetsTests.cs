using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetstoreApi.Builder.Common;
using PetstoreApi.Domain;
using PetstoreApi.DTO;
using PetstoreApi.Service;
using PetstoreApi.Utils;
using Xunit;

namespace PetstoreApi.Tests.Users
{
    public class PetsTests
    {
		[Fact]
		public async Task PostUser_ShouldCreateUser()
		{
			// arrange
			var postBody = Build.PetDto
				.WithCategory(c => c.WithId(Generator.RandomInt()).WithName("category name"))
				.WithPhotoUrls(new[]{ "photo url" })
				.WithTags(t => t.WithId(Generator.RandomInt()).WithName("tag name"))
				.WithStatus(Status.AVAILABLE)
				.Build();

			// act
			var response = await PetsService.Create(postBody);

			// assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			var result = JsonConvert.DeserializeObject<PetDto>(
				await response.Content.ReadAsStringAsync());

			Assert.Equal(-9223372036854775808, result.Id);
		}
	}
}
