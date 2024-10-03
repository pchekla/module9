/// <summary>
/// Определение собственного типа исключения
/// </summary>
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}