public class Program
{
    /// <summary>
    /// Объявление делегата для события
    /// </summary>
    /// <param name="surnames"></param>
    public delegate void SortEventHandler(List<string> surnames, string sortType);

    /// <summary>
    /// Событие, которое будет вызвано для сортировки
    /// </summary>
    public static event SortEventHandler? OnSort;

    static void Main(string[] args)
    {
        List<string> surnames = new List<string>
        {
            "Сидоров",
            "Иванов",
            "Петров",
            "Смирнов",
            "Кузнецов"
        };

        try
        {
            Console.WriteLine("Выберите тип сортировки:");
            Console.WriteLine("1 - Сортировка А-Я");
            Console.WriteLine("2 - Сортировка Я-А");

            string? input = Console.ReadLine();

            // Проверка ввода пользователя
            if (input != "1" && input != "2")
            {
                throw new InvalidInputException("Введено некорректное значение. Пожалуйста, введите 1 или 2.");
            }

            // Подписываемся на событие
            OnSort += SortSurnames;

            // Вызываем событие и передаем тип сортировки
            OnSort(surnames, input);

            // Отображаем отсортированные фамилии
            Console.WriteLine("Отсортированные фамилии:");
            foreach (var surname in surnames)
            {
                Console.WriteLine(surname);
            }
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Завершение работы программы.");
        }
    }

    /// <summary>
    /// Метод для сортировки фамилий
    /// </summary>
    /// <param name="surnames"></param>
    /// <param name="sortType"></param>
    private static void SortSurnames(List<string> surnames, string sortType)
    {
        if (sortType == "1")
        {
            surnames.Sort(); // Сортировка А-Я
        }
        else
        {
            surnames.Sort((x, y) => string.Compare(y, x)); // Сортировка Я-А
        }
    }
}
