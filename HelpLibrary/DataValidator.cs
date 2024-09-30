namespace HelpLibrary
{
	/// <summary>
	/// Валидация данных.
	/// </summary>
	public class DataValidator
	{
		/// <summary>
		/// Проверяет значение на null.
		/// </summary>
		/// <typeparam name="T">Любое nullable значение.</typeparam>
		/// <param name="value">Значение.</param>
		/// <exception cref="ArgumentNullException">Пустое значение.</exception>
		public static void ValidateTNullValue<T>(T value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("Пустое значение недопустимо.", nameof(value));
			}
		}
	}
}
