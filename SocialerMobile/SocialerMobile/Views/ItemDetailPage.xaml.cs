using SocialerMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SocialerMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}