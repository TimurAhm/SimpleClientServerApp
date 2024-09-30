using BankLibrary;
using System.Configuration;

namespace BankConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintClients();
		}

		/// <summary>
		/// Вывод клиентов.
		/// </summary>
		private static void PrintClients()
		{
			var clients = GetClient.GetClients(ConfigurationManager.AppSettings["GetClientsUrl"]);

			foreach (var client in clients)
			{
				Console.WriteLine(client.ToString());
			}
		}
	}
}