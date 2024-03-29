
using NUnit.Framework.Internal.Execution;

namespace EventApi.Controllers.Tests
{
    [TestFixture]
    public class EventTests
    {
        // Тест для проверки создания события с корректным форматом
        [Test]
        public void EventCreationWithCorrectFormat()
        {
            Console.WriteLine("Начинаем тестирование создания события с корректным форматом...");

            // Создание события с корректными данными
            var eventObj = new Event("15b9189c-fa43-4716-9a55-b396da96c8d8", "Test Event", "Description", DateTime.Parse("2024-03-13T12:00:00"), DateTime.Parse("2024-03-13T14:00:00"), 10.99m);

            // Проверка, что объект создан успешно и соответствует формату
            Assert.AreEqual("15b9189c-fa43-4716-9a55-b396da96c8d8", eventObj.Id);
            Assert.AreEqual("Test Event", eventObj.Title);
            Assert.AreEqual("Description", eventObj.Description);
            Assert.AreEqual(DateTime.Parse("2024-03-13T12:00:00"), eventObj.DateTimeStart);
            Assert.AreEqual(DateTime.Parse("2024-03-13T14:00:00"), eventObj.DateTimeEnd);
            Assert.AreEqual(10.99m, eventObj.Price);

            Console.WriteLine("Тест успешно завершен!");
        }

        // Тест для проверки создания события с некорректным форматом
        [Test]
        public void EventCreationWithIncorrectFormat()
        {
            Console.WriteLine("Начинаем тестирование создания события с некорректным форматом...");

            // Создание события с некорректными данными
            // В данном случае, мы можем предположить, что конструктор должен генерировать исключение

            // Создание события с некорректной датой начала
            Assert.Throws<ArgumentException>(() => new Event("15b9189c-fa43-4716-9a55-b396da96c8d8", "Test Event", "Description", DateTime.Parse("2024-03-13 12:00:00"), DateTime.Parse("2024-03-13T14:00:00"), 10.99m));
            Console.WriteLine("Тест на создание события с некорректной датой начала выполнен успешно.");

            // Создание события с отрицательной ценой
            Assert.Throws<ArgumentException>(() => new Event("15b9189c-fa43-4716-9a55-b396da96c8d8", "Test Event", "Description", DateTime.Parse("2024-03-13T12:00:00"), DateTime.Parse("2024-03-13T14:00:00"), -10.99m));
            Console.WriteLine("Тест на создание события с отрицательной ценой выполнен успешно.");

            // Создание события с пустым заголовком
            Assert.Throws<ArgumentException>(() => new Event("15b9189c-fa43-4716-9a55-b396da96c8d8", "", "Description", DateTime.Parse("2024-03-13T12:00:00"), DateTime.Parse("2024-03-13T14:00:00"), 10.99m));
            Console.WriteLine("Тест на создание события с пустым заголовком выполнен успешно.");

            Console.WriteLine("Тесты завершены!");
        }
    }
}
