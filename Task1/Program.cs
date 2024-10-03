class Program
{
    static void Main()
    {
        // 2. Создание массива исключений
        Exception[] exceptions = new Exception[]
        {
            new ArgumentNullException("Аргумент не должен быть null"),   // Исключение ArgumentNullException
            new DivideByZeroException("Попытка деления на ноль"),        // Исключение DivideByZeroException
            new IndexOutOfRangeException("Выход за пределы массива"),    // Исключение IndexOutOfRangeException
            new InvalidOperationException("Недопустимая операция"),      // Исключение InvalidOperationException
            new CustomException("Собственное исключение")                // Наше собственное исключение
        };

        // 3. Перебор каждого исключения в массиве
        foreach (var ex in exceptions)
        {
            try
            {
                // Явно выбрасываем текущее исключение
                throw ex;
            }
            catch (Exception e)  // Ловим любое исключение
            {
                // Выводим сообщение исключения в консоль
                Console.WriteLine($"Произошло исключение: {e.Message}");
            }
            finally
            {
                // Необязательный блок finally
                Console.WriteLine("Блок finally завершен.\n");
            }
        }

        Console.WriteLine("Все исключения обработаны.");
    }
}