using System.Linq;

namespace PetstoreApi.Utils
{
    public static class Converter
    {
		public static string ToQueryParams<T>(T model) where T :class
		{
			var keyValuePairs = model.GetType().GetProperties()
				.Where(x => x.GetValue(model) != null)
				.Select(x => x.Name + "=" + x.GetValue(model, null))
				.ToArray();

			return "?" + string.Join("&", keyValuePairs);
		}
	}
}
