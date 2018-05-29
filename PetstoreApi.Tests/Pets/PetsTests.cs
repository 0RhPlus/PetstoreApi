using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using PetstoreApi.Builder.Common;
using PetstoreApi.Client;
using PetstoreApi.Domain;
using PetstoreApi.DTO;
using PetstoreApi.Service;
using PetstoreApi.Utils;
using Xunit;

namespace PetstoreApi.Tests.Pets
{
    public class PetsTests
    {
		[Fact]
		public async Task PostPet_ShouldCreatePet()
		{
			// arrange
			var postBody = Build.PetDto
				.WithCategory(c => c.WithId(Generator.RandomInt()).WithName("category name"))
				.WithPhotoUrls(new[] { "photo url" })
				.WithTags(t => t.WithId(Generator.RandomInt()).WithName("tag name"))
				.WithStatus(Status.AVAILABLE)
				.Build();

			// act
			var response = await PetsService.Create(postBody);

			// assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			var pet = await response.Content.ReadAsJsonAsync<PetDto>();

			Assert.Equal(-9223372036854775808, pet.Id);
		}

		[Theory]
		[InlineData(Status.AVAILABLE)]
		[InlineData(Status.PENDING)]
		[InlineData(Status.SOLD)]
		public async Task GetPets_ByStatus_ShouldReturnPetsList(string status)
		{
			// arrange & act
			var response = await PetsService.GetByStatus(status);

			// assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			var listOfPets = await response.Content.ReadAsJsonAsync<List<PetDto>>();

			Assert.All(listOfPets, x => Assert.Contains(status, x.Status));
		}

		[Theory]
		[InlineData(567934457694)]
		public async Task GetPets_WithInvalidId_ShouldReturn404(long invalidId)
		{
			// arrange & act
			var response = await PetsService.GetById(invalidId);

			// assert
			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
		}
	}
}
