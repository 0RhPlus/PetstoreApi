namespace PetstoreApi.Builder.Common
{
    public class Build
    {
		public static PetDtoBuilder PetDto { get { return new PetDtoBuilder(); } }
		public static CategoryDtoBuilder CategoryDto { get { return new CategoryDtoBuilder(); } }
		public static TagDtoBuilder TagDto { get { return new TagDtoBuilder(); } }
	}
}
