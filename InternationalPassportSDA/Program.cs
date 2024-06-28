using System;

public class ForeignPassport
{
    // Поля класса
    public string PassportNumber { get; private set; }
    public string FullName { get; private set; }
    public DateTime DateOfIssue { get; private set; }
    public DateTime DateOfExpiry { get; private set; }
    public string IssuingAuthority { get; private set; }
    public string Nationality { get; private set; }

    // Конструктор класса с проверками
    public ForeignPassport(string passportNumber, string fullName, DateTime dateOfIssue, DateTime dateOfExpiry, string issuingAuthority, string nationality)
    {
        // Проверка номера паспорта
        if (string.IsNullOrWhiteSpace(passportNumber))
            throw new ArgumentException("Номер паспорта не может быть пустым или содержать только пробелы.");

        // Проверка ФИО
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("ФИО не может быть пустым или содержать только пробелы.");

        // Проверка даты выдачи
        if (dateOfIssue > DateTime.Now)
            throw new ArgumentException("Дата выдачи не может быть в будущем.");

        // Проверка даты окончания
        if (dateOfExpiry <= dateOfIssue)
            throw new ArgumentException("Дата окончания должна быть позже даты выдачи.");

        // Проверка органа выдачи
        if (string.IsNullOrWhiteSpace(issuingAuthority))
            throw new ArgumentException("Орган выдачи не может быть пустым или содержать только пробелы.");

        // Проверка национальности
        if (string.IsNullOrWhiteSpace(nationality))
            throw new ArgumentException("Национальность не может быть пустой или содержать только пробелы.");

        // Инициализация полей
        PassportNumber = passportNumber;
        FullName = fullName;
        DateOfIssue = dateOfIssue;
        DateOfExpiry = dateOfExpiry;
        IssuingAuthority = issuingAuthority;
        Nationality = nationality;
    }

    // Переопределение метода ToString для удобного отображения информации о паспорте
    public override string ToString()
    {
        return $"Номер паспорта: {PassportNumber}\n" +
               $"ФИО: {FullName}\n" +
               $"Дата выдачи: {DateOfIssue.ToShortDateString()}\n" +
               $"Дата окончания: {DateOfExpiry.ToShortDateString()}\n" +
               $"Орган выдачи: {IssuingAuthority}\n" +
               $"Национальность: {Nationality}";
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Пример создания экземпляра класса ForeignPassport
            ForeignPassport passport = new ForeignPassport(
                "123456789",
                "Иванов Иван Иванович",
                new DateTime(2020, 1, 15),
                new DateTime(2030, 1, 14),
                "Министерство внутренних дел",
                "Россия"
            );

            // Вывод информации о паспорте
            Console.WriteLine(passport);
        }
        catch (Exception ex)
        {
            // Обработка исключений
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}