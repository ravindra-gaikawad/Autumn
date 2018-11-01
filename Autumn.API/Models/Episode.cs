using System;
using System.Collections.Generic;

namespace Autumn.API.Models
{
    public partial class Episode
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ForDate { get; set; }
        public string Location { get; set; }
        public long AuthorId { get; set; }

        public User Author { get; set; }
    }
}
