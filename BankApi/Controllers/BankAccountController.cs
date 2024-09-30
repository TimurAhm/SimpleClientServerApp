using BankApi.Database;
using BankApi.Database.Entities;
using HelpLibrary;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
	/// <summary>
	/// Контроллер для банковских счетов.
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class BankAccountController : Controller
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
		public BankAccountController(IConfiguration configuration)
		{
			DataValidator.ValidateTNullValue(configuration);

			_dbContext = new DbContext
				(
				configuration["ConnectionStrings:providerName"],
				configuration["ConnectionStrings:connectionString"]
				);
		}

		/// <summary>
		/// Запрос на получение всех банковских счетов.
		/// </summary>
		/// <returns>Результат операции.</returns>
		[HttpGet("/GetBankAccounts")]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dbContext.BankAccounts.ToList());
			}
			catch (BadHttpRequestException e)
			{
				return BadRequest(e);
			}
		}

		/// <summary>
		/// Запрос на добавление банковского счета.
		/// </summary>
		/// <param name="bankAccount"></param>
		/// <returns>Результат операции.</returns>
		[HttpPost("/PostBankAccount")]
		public IActionResult Post(BankAccount bankAccount)
		{
			DataValidator.ValidateTNullValue(bankAccount);

			bankAccount.BankAccountId = Guid.NewGuid();

			return Ok(_dbContext.Insert(bankAccount));
		}

	}
}
