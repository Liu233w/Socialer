using SocialerMobile.Models;
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

        public Command AddPersonCommand { get; }
        public Command LoadPeopleCommand { get; }
    }
}
