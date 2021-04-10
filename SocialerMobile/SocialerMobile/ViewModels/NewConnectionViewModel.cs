using SocialerMobile.Models;
using System.Diagnostics;
using Xamarin.Forms;

namespace SocialerMobile.ViewModels
{
    public class NewConnectionViewModel : BaseConnectionViewModel
    {
        public NewConnectionViewModel()
        {
            Debug.WriteLine("socialer - entering new connection view model");
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
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
            await SocialerDataStore.AddPersonAsync(new Person
            {
                Name = Name,
                Note = Note,
                Rating = Rating,
                TargetRating = TargetRating,
            });

            await Shell.Current.GoToAsync("..");
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
    }
}
