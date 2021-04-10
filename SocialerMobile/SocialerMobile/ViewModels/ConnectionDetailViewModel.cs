using SocialerMobile.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialerMobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ConnectionDetailViewModel : BaseViewModel
    {
        private string name;
        private string note;
        private int rating;
        private int targetRating;
        private string itemId;

        public string Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Note
        {
            get => note;
            set => SetProperty(ref note, value);
        }

        public int Rating
        {
            get => rating;
            set => SetProperty(ref rating, value);
        }

        public int TargetRating
        {
            get => targetRating;
            set => SetProperty(ref targetRating, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await SocialerDataStore.GetPersonAsync(itemId);
                Id = item.Id;
                Name = item.Id;
                Note = item.Note;
                Rating = item.Rating;
                TargetRating = item.TargetRating;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
