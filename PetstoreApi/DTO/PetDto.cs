using System.Collections.Generic;

namespace PetstoreApi.DTO
{
	public class PetDto
	{
		public long Id { get; set; }
		public CategoryDto Category { get; set; }
		public string Name { get; set; }
		public IList<string> PhotoUrls { get; set; }
		public IList<TagDto> Tags { get; set; }
		public string Status { get; set; }
	}
}
