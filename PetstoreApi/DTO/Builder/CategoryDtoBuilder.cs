using PetstoreApi.Builder.Common;
using PetstoreApi.DTO;

namespace PetstoreApi.Builder
{
	public partial class CategoryDtoBuilder : Builder<CategoryDto>
	{
		public CategoryDtoBuilder WithId(int id)
		{
			dto.Id = id;
			return this;
		}

		public CategoryDtoBuilder WithName(string name)
		{
			dto.Name = name;
			return this;
		}
	}
}