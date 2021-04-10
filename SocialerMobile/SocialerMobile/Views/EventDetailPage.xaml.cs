using SocialerMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SocialerMobile.Views
{
    public partial class EventDetailPage : ContentPage
    {
        public EventDetailPage()
        {
            InitializeComponent();
            BindingContext = new EventDetailViewModel();
        }
    }
}