using System;
using SocialerMobile.Models;
using Xamarin.Forms;

namespace SocialerMobile.ViewModels
{
    public class NewEventViewModel : BaseEventViewModel
    {
        public string PersonId { get; set; }

        public NewEventViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            RatingChange = 0;
            Time = DateTime.Now;
        }


        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            await SocialerDataStore.AddEventAsync(PersonId, new Event
            {
                Name = Name,
                Note = Note,
                Time = Time,
                RatingChange = RatingChange,
            });

            await Shell.Current.GoToAsync("..");
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
    }
}
