using LinqToDB.Mapping;

namespace BankApi.Database.Entities
{
	/// <summary>
	/// Банковский счет.
	/// </summary>
	[Table(Name = "BankAccount")]
	public class BankAccount
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		[Column(Name = "BankAccountId"), PrimaryKey, NotNull]
		public Guid BankAccountId { get; set; }

		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		[Column(Name = "ClientId"), NotNull]
		public Guid ClientId { get; set; }

		/// <summary>
		/// Дата открытия.
		/// </summary>
		[Column(Name = "OpenDate"), NotNull]
		public DateTime OpenDate { get; set; }

		/// <summary>
		/// Дата закрытия.
		/// </summary>
		[Column(Name = "CloseDate")]
		public DateTime CloseDate { get; set; }

		/// <summary>
		/// Процент по вкладу.
		/// </summary>
		[Column(Name = "DepositPercent")]
		public float DepositPercent { get; set; }

		/// <summary>
		/// Баланс.
		/// </summary>
		[Column(Name = "Balance")]
		public decimal Balance { get; set; }

		/// <summary>
		/// Связь по ключу.
		/// </summary>
		[Association(ThisKey = nameof(ClientId), OtherKey = nameof(Client.ClientId))]
		public Client client;

		/// <summary>
		/// Инициализация полей класса.
		/// </summary>
		/// <param name="bankAccountId">Уникальный идентификатор.</param>
		/// <param name="clientId">Уникальный идентификатор клиента.</param>
		/// <param name="openDate">Дата открытия.</param>
		/// <param name="closeDate">Дата закрытия.</param>
		/// <param name="depositPercent">Процент по депозиту.</param>
		/// <param name="balance">Баланс.</param>
		public BankAccount(Guid bankAccountId, Guid clientId, DateTime openDate,
			DateTime closeDate, float depositPercent, decimal balance)
		{
			BankAccountId = bankAccountId;
			ClientId = clientId;
			OpenDate = openDate;
			CloseDate = closeDate;
			DepositPercent = depositPercent;
			Balance = balance;
		}

		/// <summary>
		/// Представление класса.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return
				$"\nId счета - {BankAccountId}" +
				$"\nId клиента - {ClientId}" +
				$"\nДата открытия - {OpenDate}" +
				$"\nДата закрытия - {CloseDate}" +
				$"\nПроцент по вкладу - {DepositPercent}" +
				$"\nБаланс - {Balance}";
		}
	}
}
