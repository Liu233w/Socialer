using System;

namespace SocialerMobile.ViewModels
{
    public class BaseEventViewModel : BaseViewModel
    {
        private DateTime _time;
        private string _name;
        private string _note;
        private int _ratingChange;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public DateTime Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        public int RatingChange
        {
            get => _ratingChange;
            set => SetProperty(ref _ratingChange, value);
        }
    }
}
