using BankApi.Database.Entities;
using LinqToDB;
using LinqToDB.Data;

namespace BankApi.Database
{
	/// <summary>
	/// Экземпляр подключения к базе данных.
	/// </summary>
	public class DbContext : DataConnection
	{
		// <summary>
		/// Инициализация полей.
		/// </summary>
		/// <param name="provider">Название провайдера.</param>
		/// <param name="connectionString">Строка подключения.</param>
		public DbContext(string provider, string connectionString)
			: base(provider, connectionString)
		{ }

		/// <summary>
		/// Таблица клиентов.
		/// </summary>
		public ITable<Client> Clients => this.GetTable<Client>();

		/// <summary>
		/// Таблица банковских счетов.
		/// </summary>
		public ITable<BankAccount> BankAccounts => this.GetTable<BankAccount>();
	}
}
