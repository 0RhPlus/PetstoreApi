using System;
using System.Collections.Generic;
using System.Linq;
using PetstoreApi.Builder.Common;
using PetstoreApi.DTO;
using PetstoreApi.Utils;

namespace PetstoreApi.Builder
{
    public partial class PetDtoBuilder : Builder<PetDto>
    {
		protected override void Defaults()
		{
			dto.Id = Generator.RandomInt();
			dto.Name = "doggy";
			dto.Status = "available";
		}

		public PetDtoBuilder WithId(long id)
		{
			dto.Id = id;
			return this;
		}

		public PetDtoBuilder WithCategory(Action<CategoryDtoBuilder> categoryBuilder)
		{
			var builder = new CategoryDtoBuilder();
			categoryBuilder.Invoke(builder);
			dto.Category = builder.Build();
			return this;
		}

		public PetDtoBuilder Withname(string name)
		{
			dto.Name = name;
			return this;
		}
		public PetDtoBuilder WithPhotoUrls(IList<string> photoUrls)
		{
			dto.PhotoUrls = photoUrls;
			return this;
		}
		public PetDtoBuilder WithTags(List<TagDto> tags)
		{
			dto.Tags = tags;
			return this;
		}

		public PetDtoBuilder WithTags(params TagDto[] tags)
		{
			dto.Tags = tags.ToList();
			return this;
		}

		public PetDtoBuilder WithTags(params Action<TagDtoBuilder>[] builders)
		{
			var tags = new List<TagDto>();

			foreach (var builder in builders)
			{
				var b = new TagDtoBuilder();
				builder.Invoke(b);
				tags.Add(b.Build());
			}

			dto.Tags = tags;

			return this;
		}

		public PetDtoBuilder WithStatus(string status)
		{
			dto.Status = status;
			return this;
		}
	}
}
