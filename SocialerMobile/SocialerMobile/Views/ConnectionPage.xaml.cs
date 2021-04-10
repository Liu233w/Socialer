using SocialerMobile.Models;
using SocialerMobile.ViewModels;
using System.Windows.Input;
using Xamarin.Forms;

namespace SocialerMobile.Views
{
    public partial class ConnectionPage : ContentPage
    {
        ConnectionViewModel _viewModel;

        public ConnectionPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ConnectionViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
