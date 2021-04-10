using SocialerMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialerMobile.Services
{
    class MockSocialerDataStore : ISocialerDataStore
    {
        private List<Person> people = new List<Person>();

        public async Task AddEventAsync(string personId, Event @event)
        {
            var person = await GetPersonAsync(personId);

            var entity = new Event
            {
                Id = new Guid().ToString(),
                Title = @event.Title,
                Note = @event.Note,
                Time = @event.Time,
                RatingChange = @event.RatingChange,
            };

            person.Rating += entity.RatingChange;
            person.Events.Add(entity);
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
                Events = new List<Event>(),
            };

            people.Add(entity);

            return Task.FromResult(entity.Id);
        }

        public Task<Person> GetPersonAsync(string id)
        {
            var person = people.Find(p => p.Id == id);
            if (person == null)
            {
                throw new KeyNotFoundException("Person with this id does not exist");
            }

            return Task.FromResult(person);
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return people;
        }

        public Task RemovePersonAsync(string id)
        {
            people.RemoveAll(p => p.Id == id);
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
