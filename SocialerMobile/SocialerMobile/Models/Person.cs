using System;
using System.Collections.Generic;
using System.Text;

namespace SocialerMobile.Models
{
    public class Person
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public int Rating { get; set; }

        public int TargetRating { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
