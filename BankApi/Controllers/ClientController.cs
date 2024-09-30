using BankApi.Database;
using BankApi.Database.Entities;
using HelpLibrary;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
	/// <summary>
	/// Контроллер для клиентов.
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class ClientController : Controller
	{
		/// <summary>
		/// Экземпляр подключения к базе данных.
		/// </summary>
		public readonly DbContext _dbContext;

		/// <summary>
		/// Инициализация полей класса.
		/// </summary>
		/// <param name="configuration">Конфигурация.</param>
		/// <exception cref="ArgumentNullException">Пустая конфигурация.</exception>
		public ClientController(IConfiguration configuration)
		{
			DataValidator.ValidateTNullValue(configuration);

			_dbContext = new DbContext
				(
				configuration["ConnectionStrings:providerName"],
				configuration["ConnectionStrings:connectionString"]
				);
		}

		/// <summary>
		/// Запрос на получение всех клиентов.
		/// </summary>
		/// <returns>Результат запроса.</returns>
		[HttpGet("/GetClients")]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dbContext.Clients.ToList());
			}
			catch (BadHttpRequestException e)
			{
				return BadRequest(e);
			}
		}

		/// <summary>
		/// Запрос на добавление клиента.
		/// </summary>
		/// <param name="client">Клиент.</param>
		/// <returns>Результат запроса.</returns>
		[HttpPost("/PostClient")]
		public IActionResult Post(Client client)
		{
			DataValidator.ValidateTNullValue(client);

			client.ClientId = Guid.NewGuid();

			return Ok(_dbContext.Insert(client));
		}
	}
}
