using System;

namespace PetstoreApi.Utils
{
	public static class Generator
	{
		public static string RandomString(int length = 10)
		{
			return Guid.NewGuid().ToString().Substring(0, length).Replace("-", "");
		}

		public static int RandomInt()
		{
			return new Random().Next(0, int.MaxValue);
		}
	}
}
