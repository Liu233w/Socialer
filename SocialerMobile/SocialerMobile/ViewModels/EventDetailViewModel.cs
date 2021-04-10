using System;
using System.Diagnostics;

namespace SocialerMobile.ViewModels
{
    public class EventDetailViewModel : BaseEventViewModel
    {
        private string _eventId;
        public string Id { get; set; }

        public string EventId
        {
            get { return _eventId; }
            set
            {
                _eventId = value;
                LoadEventId(value);
            }
        }

        public async void LoadEventId(string itemId)
        {
            try
            {
                var item = await SocialerDataStore.GetEventAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Note = item.Note;
                RatingChange = item.RatingChange;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
