namespace Autumn.API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class BookPage : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public long BookId { get; set; }

        public short Sequence { get; set; }

        public Book Book { get; set; }
    }
}
