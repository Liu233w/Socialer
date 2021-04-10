using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SocialerMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.familyrelationships.gov.au/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}