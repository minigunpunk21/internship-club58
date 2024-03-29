using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EventApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly List<Event> _events = new List<Event>
        {
            new Event
            {
                Id = "15b9189c-fa43-4716-9a55-b396da96c8d8",
                Title = "ЧЕРНАЯ ПЯТНИЦА",
                Description = "лютейшее описание",
                DateTimeStart = DateTime.Now.AddDays(1),
                DateTimeEnd = DateTime.Now.AddDays(2),
                Price = 10.99m
            },
            new Event
            {
                Id = "91b4c250-b3bf-4af6-96ae-8b3f25d57904",
                Title = "ПРИКОЛ",
                Description = "пиво по кидке",
                DateTimeStart = DateTime.Now.AddDays(3),
                DateTimeEnd = DateTime.Now.AddDays(4),
                Price = 20.49m
            }
        };

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(_events);
        }

        [HttpGet("{eventId}")]
        public IActionResult GetEvent(string eventId)
        {
            var @event = _events.Find(e => e.Id == eventId);
            if (@event == null)
            {
                return NotFound();
            }
            return Ok(@event);
        }
    }

    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public decimal Price { get; set; }

        // Пустой конструктор нужен для сериализации объекта JSON
        public Event() { }

        // Конструктор с параметрами
        public Event(string id, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
            Price = price;
        }
    }
}
