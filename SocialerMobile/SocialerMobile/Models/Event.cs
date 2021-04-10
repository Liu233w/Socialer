using System;
using System.Collections.Generic;
using System.Text;

namespace SocialerMobile.Models
{
    public class Event
    {
        public string Id { get; set; }

        public DateTime Time { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public int RatingChange { get; set; }
    }
}
