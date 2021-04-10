using SocialerMobile.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialerMobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ConnectionDetailViewModel : BaseConnectionViewModel
    {
        private string _itemId;

        public string Id { get; set; }

        public string ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
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
