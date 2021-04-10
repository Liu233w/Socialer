using SocialerMobile.Models;
using SocialerMobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialerMobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ConnectionDetailViewModel : BaseConnectionViewModel
    {
        private string _itemId;

        public ConnectionDetailViewModel()
        {
            Events = new ObservableCollection<Event>();

            AddEventCommand = new Command(OnAddEvent);
            DeletePersonCommand = new Command(OnPersonDelete);
            EventTapped = new Command<Event>(OnEventTap);
        }

        public ObservableCollection<Event> Events { get; }

        public string Id { get; set; }

        public string ItemId
        {
            get { return _itemId; }
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await SocialerDataStore.GetPersonAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Note = item.Note;
                Rating = item.Rating;
                TargetRating = item.TargetRating;

                var events = await SocialerDataStore.GetEventsAsync(itemId);
                Events.Clear();
                foreach (var @event in events)
                {
                    Events.Add(@event);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnAddEvent(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(NewEventPage)}?{nameof(NewEventViewModel.PersonId)}={Id}");
        }

        private async void OnEventTap(Event @event)
        {
            if (@event == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(EventDetailPage)}?{nameof(EventDetailViewModel.Id)}={@event.Id}");
        }

        private async void OnPersonDelete(object obj)
        {
            var confirmed =
                await Shell.Current.DisplayAlert("Delete?", "Do you want to delete this connection?", "Yes", "No");
            if (confirmed)
            {
                await SocialerDataStore.RemovePersonAsync(Id);
            }

            await Shell.Current.GoToAsync("..");
        }

        public Command AddEventCommand { get; }
        public Command DeletePersonCommand { get; }
        public Command<Event> EventTapped { get; }
    }
}
