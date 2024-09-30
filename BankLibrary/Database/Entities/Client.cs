using LinqToDB.Mapping;

namespace BankApi.Database.Entities
{
	/// <summary>
	/// Клиент.
	/// </summary>
	[Table(Name = "Client")]
	public class Client
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		[PrimaryKey]
		[Column(Name = "ClientId"), NotNull]
		public Guid ClientId { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Column(Name = "Surname"), NotNull]
		public string Surname { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[Column(Name = "Name"), NotNull]
		public string Name { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		[Column(Name = "Patronymic")]
		public string? Patronymic { get; set; }

		/// <summary>
		/// Мобильный.
		/// </summary>
		[Column(Name = "Phone")]
		public long Phone { get; set; }

		/// <summary>
		/// Дата начала сотрудничества.
		/// </summary>
		[Column(Name = "ServiceStartDay"), NotNull]
		public DateTime ServiceStartDay { get; set; }

		/// <summary>
		/// Инициализация полей класса.
		/// </summary>
		/// <param name="clientId">Уникальный идентификатор.</param>
		/// <param name="surname">Фамилия.</param>
		/// <param name="name">Имя.</param>
		/// <param name="patronymic">Отчество.</param>
		/// <param name="phone">Мобильный.</param>
		/// <param name="serviceStartDay">Дата начала сотрудничества.</param>
		public Client(Guid clientId, string surname, string name,
			string patronymic, long phone, DateTime serviceStartDay)
		{
			ClientId = clientId;
			Surname = surname;
			Name = name;
			Patronymic = patronymic;
			Phone = phone;
			ServiceStartDay = serviceStartDay;
		}

		/// <summary>
		/// Представление класса.
		/// </summary>
		/// <returns>Строка.</returns>
		public override string ToString()
		{
			return
				$"\nId клиента - {ClientId}" +
				$"\nФамилия - {Surname}" +
				$"\nИмя - {Name}" +
				$"\nОтчество - {Patronymic}" +
				$"\nМобильный - {Phone}" +
				$"\nДата подписания контракта - {ServiceStartDay}";
		}
	}
}
