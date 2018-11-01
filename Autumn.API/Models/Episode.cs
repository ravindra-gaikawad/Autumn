namespace Autumn.API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Episode : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ForDate { get; set; }

        public string Location { get; set; }

        public long AuthorId { get; set; }

        public User Author { get; set; }
    }
}
