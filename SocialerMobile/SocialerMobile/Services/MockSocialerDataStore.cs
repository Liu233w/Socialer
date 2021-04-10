using SocialerMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialerMobile.Services
{
    class MockSocialerDataStore : ISocialerDataStore
    {
        public MockSocialerDataStore()
        {
#if DEBUG
            AddPersonAsync(new Person
            {
                Name = "Tom",
                Note = "Nooo",
                Rating = 3,
                TargetRating = 4,
            }).Wait();
            AddPersonAsync(new Person
            {
                Name = "Jerry",
                Note = "yyyyy",
                Rating = 4,
                TargetRating = 3,
            }).Wait();
#endif
        }

        private List<Person> _people = new List<Person>();

        private List<Event> _events = new List<Event>();

        public async Task AddEventAsync(string personId, Event @event)
        {
            var person = await GetPersonAsync(personId);

            var entity = new Event
            {
                Id = new Guid().ToString(),
                PersonId = person.Id,
                Name = @event.Name,
                Note = @event.Note,
                Time = @event.Time,
                RatingChange = @event.RatingChange,
            };

            person.Rating += entity.RatingChange;

            _events.Add(entity);
        }

        public async Task<Event> GetEventAsync(string eventId)
        {
            var entity = _events.Find(e => e.Id == eventId);
            if (entity == null)
            {
                throw new KeyNotFoundException("Event with this id is not found");
            }

            return entity;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync(string personId)
        {
            return _events.Where(e => e.PersonId == personId);
        }

        public async Task RemoveEventAsync(string eventId)
        {
            _events.RemoveAll(e => e.Id == eventId);
        }

        public Task<string> AddPersonAsync(Person person)
        {
            var entity = new Person
            {
                Id = new Guid().ToString(),
                Name = person.Name,
                Note = person.Note,
                Rating = person.Rating,
                TargetRating = person.TargetRating,
            };

            _people.Add(entity);

            return Task.FromResult(entity.Id);
        }

        public Task<Person> GetPersonAsync(string id)
        {
            var person = _people.Find(p => p.Id == id);
            if (person == null)
            {
                throw new KeyNotFoundException("Person with this id does not exist");
            }

            return Task.FromResult(person);
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return _people;
        }

        public Task RemovePersonAsync(string id)
        {
            _people.RemoveAll(p => p.Id == id);
            _events.RemoveAll(e => e.PersonId == id);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Update data fields of Person. Does not update the events list
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task UpdatePersonAsync(Person person)
        {
            var entity = await GetPersonAsync(person.Id);

            entity.Name = person.Name;
            entity.Note = person.Note;
            entity.Rating = person.Rating;
            entity.TargetRating = person.TargetRating;
        }
    }
}
