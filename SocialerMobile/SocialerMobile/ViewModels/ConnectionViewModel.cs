using SocialerMobile.Models;
using SocialerMobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialerMobile.ViewModels
{
    public class ConnectionViewModel : BaseViewModel
    {
        public ConnectionViewModel()
        {
            Title = "Connection Detail";

            LoadPeopleCommand = new Command(async () => await ExecuteLoadPeopleCommand());

            AddPersonCommand = new Command(OnAddPerson);
            PersonTapped = new Command<Person>(OnPersonSelected);
        }

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadPeopleCommand()
        {
            IsBusy = true;

            try
            {
                People.Clear();
                var items = await SocialerDataStore.GetPersonsAsync();
                foreach (var item in items)
                {
                    People.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddPerson(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewConnectionPage));
        }

        async void OnPersonSelected(Person item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ConnectionDetailPage)}?{nameof(ConnectionDetailViewModel.ItemId)}={item.Id}");
        }

        public Command AddPersonCommand { get; }
        public Command LoadPeopleCommand { get; }
        public Command<Person> PersonTapped { get; }
    }
}
