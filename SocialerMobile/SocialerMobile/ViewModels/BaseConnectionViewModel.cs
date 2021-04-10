using System;
using System.Collections.Generic;
using System.Text;

namespace SocialerMobile.ViewModels
{
    public class BaseConnectionViewModel : BaseViewModel
    {
        private string _name;
        private string _note;
        private int _rating;
        private int _targetRating;

        public BaseConnectionViewModel()
        {
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        public int Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }

        public int TargetRating
        {
            get => _targetRating;
            set => SetProperty(ref _targetRating, value);
        }
    }
}
