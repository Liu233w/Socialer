using SocialerMobile.ViewModels;
using SocialerMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SocialerMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(PeoplePage), typeof(PeoplePage));
        }

    }
}
