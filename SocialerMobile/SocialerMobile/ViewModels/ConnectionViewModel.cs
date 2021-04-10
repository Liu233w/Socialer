using System;
using System.Collections.ObjectModel;
using SocialerMobile.Models;

namespace SocialerMobile.ViewModels
{
    public class ConnectionViewModel:BaseViewModel
    {
        public ConnectionViewModel()
        {
            Title = "Connections";
        }

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public void OnAppearing()
        {
            throw new NotImplementedException();
        }
    }
}
