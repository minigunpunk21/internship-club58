
using NUnit.Framework.Internal.Execution;

namespace EventApi.Controllers.Tests
{
    [TestFixture]
    public class EventTests
    {
        // ���� ��� �������� �������� ������� � ���������� ��������
        [Test]
        public void EventCreationWithCorrectFormat()
        {
            Console.WriteLine("�������� ������������ �������� ������� � ���������� ��������...");

            // �������� ������� � ����������� �������
            var eventObj = new Event("15b9189c-fa43-4716-9a55-b396da96c8d8", "Test Event", "Description", DateTime.Parse("2024-03-13T12:00:00"), DateTime.Parse("2024-03-13T14:00:00"), 10.99m);

            // ��������, ��� ������ ������ ������� � ������������� �������
            Assert.AreEqual("15b9189c-fa43-4716-9a55-b396da96c8d8", eventObj.Id);
            Assert.AreEqual("Test Event", eventObj.Title);
            Assert.AreEqual("Description", eventObj.Description);
            Assert.AreEqual(DateTime.Parse("2024-03-13T12:00:00"), eventObj.DateTimeStart);
            Assert.AreEqual(DateTime.Parse("2024-03-13T14:00:00"), eventObj.DateTimeEnd);
            Assert.AreEqual(10.99m, eventObj.Price);

            Console.WriteLine("���� ������� ��������!");
        }

        // ���� ��� �������� �������� ������� � ������������ ��������
        [Test]
        public void EventCreationWithIncorrectFormat()
        {
            Console.WriteLine("�������� ������������ �������� ������� � ������������ ��������...");

            // �������� ������� � ������������� �������
            // � ������ ������, �� ����� ������������, ��� ����������� ������ ������������ ����������

            // �������� ������� � ������������ ����� ������
            Assert.Throws<ArgumentException>(() => new Event("15b9189c-fa43-4716-9a55-b396da96c8d8", "Test Event", "Description", DateTime.Parse("2024-03-13 12:00:00"), DateTime.Parse("2024-03-13T14:00:00"), 10.99m));
            Console.WriteLine("���� �� �������� ������� � ������������ ����� ������ �������� �������.");

            // �������� ������� � ������������� �����
            Assert.Throws<ArgumentException>(() => new Event("15b9189c-fa43-4716-9a55-b396da96c8d8", "Test Event", "Description", DateTime.Parse("2024-03-13T12:00:00"), DateTime.Parse("2024-03-13T14:00:00"), -10.99m));
            Console.WriteLine("���� �� �������� ������� � ������������� ����� �������� �������.");

            // �������� ������� � ������ ����������
            Assert.Throws<ArgumentException>(() => new Event("15b9189c-fa43-4716-9a55-b396da96c8d8", "", "Description", DateTime.Parse("2024-03-13T12:00:00"), DateTime.Parse("2024-03-13T14:00:00"), 10.99m));
            Console.WriteLine("���� �� �������� ������� � ������ ���������� �������� �������.");

            Console.WriteLine("����� ���������!");
        }
    }
}
