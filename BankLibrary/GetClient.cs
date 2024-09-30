using System.Net;
using BankApi.Database.Entities;
using HelpLibrary;
using Newtonsoft.Json;

namespace BankLibrary
{
	/// <summary>
	/// Получение данных о клиентах.
	/// </summary>
	public class GetClient
	{
		/// <summary>
		/// Возвращает клиентов в json формате в виде строки.
		/// </summary>
		/// <param name="url">Ссылка.</param>
		/// <returns>Клиенты в формате string.</returns>
		public static string GetJsonClientString(string url)
		{
			DataValidator.ValidateTNullValue(url);

			using (var client = new WebClient { UseDefaultCredentials = true })
			{
				client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
				var response = client.DownloadString(url);

				return response;
			}
		}

		/// <summary>
		/// Возвращает коллекцию клиентов в формате <see cref="Client"/>
		/// </summary>
		/// <param name="url">Ссылка.</param>
		/// <returns>Коллекция клиентов.</returns>
		public static List<Client> GetClients(string url)
		{
			DataValidator.ValidateTNullValue(url);

			return JsonConvert.DeserializeObject<List<Client>>(GetJsonClientString(url));
		}
	}
}
