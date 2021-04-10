using SocialerMobile.Models;
using SocialerMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialerMobile.Views
{
    public partial class NewConnectionPage : ContentPage
    {
        public Item Item { get; set; }

        public NewConnectionPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}