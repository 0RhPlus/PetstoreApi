using System;

namespace PetstoreApi.Builder.Common
{
    public abstract class Builder<TDto>
    {
		protected TDto dto;

		public Builder()
		{
			dto = Activator.CreateInstance<TDto>();
			Defaults();
		}

		protected virtual void Defaults() { }

		public TDto Build()
		{
			return dto;
		}
	}
}
