using SocialerMobile.Models;
using SocialerMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialerMobile.Views
{
    public partial class NewEventPage : ContentPage
    {
        public NewEventPage()
        {
            InitializeComponent();
            BindingContext = new NewEventViewModel();
        }
    }
}