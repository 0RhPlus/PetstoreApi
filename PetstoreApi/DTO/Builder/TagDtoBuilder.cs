using PetstoreApi.Builder.Common;
using PetstoreApi.DTO;

namespace PetstoreApi.Builder
{
    public partial class TagDtoBuilder : Builder<TagDto>
    {
		public TagDtoBuilder WithId(int id)
		{
			dto.Id = id;
			return this;
		}

		public TagDtoBuilder WithName(string name)
		{
			dto.Name = name;
			return this;
		}
	}
}
