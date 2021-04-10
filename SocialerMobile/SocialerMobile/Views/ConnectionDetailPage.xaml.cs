using SocialerMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SocialerMobile.Views
{
    public partial class ConnectionDetailPage : ContentPage
    {
        public ConnectionDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}