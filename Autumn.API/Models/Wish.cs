namespace Autumn.API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Wish : BaseEntity
    {
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsPublic { get; set; }

        public long AuthorId { get; set; }

        public User Author { get; set; }
    }
}
