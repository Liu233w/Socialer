using SocialerMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialerMobile.Services
{
    public interface ISocialerDataStore
    {
        Task<string> AddPersonAsync(Person person);

        Task RemovePersonAsync(string id);

        Task UpdatePersonAsync(Person person);

        Task<Person> GetPersonAsync(string id);

        Task<IEnumerable<Person>> GetPersonsAsync();

        Task AddEventAsync(string personId, Event @event);
    }
}
