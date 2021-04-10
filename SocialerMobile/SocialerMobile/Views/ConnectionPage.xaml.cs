using SocialerMobile.Models;
using SocialerMobile.ViewModels;
using System.Windows.Input;
using Xamarin.Forms;

namespace SocialerMobile.Views
{
    public partial class ConnectionPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ConnectionPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
