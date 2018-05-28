using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PetstoreApi.Client
{
	public static class ApiClient
	{
		private static readonly object Padlock = new object();
		private static HttpClient _instance;

		public static HttpClient Instance
		{
			get
			{
				lock (Padlock)
				{
					if (_instance != null)
					{
						return _instance;
					}

					_instance = new HttpClient
					{
						BaseAddress = new Uri("http://petstore.swagger.io")
					};
					_instance.DefaultRequestHeaders.Accept.Clear();
					_instance.DefaultRequestHeaders.Accept.Add(
						new MediaTypeWithQualityHeaderValue("application/json"));

					return _instance;
				}
			}
		}
	}
}
