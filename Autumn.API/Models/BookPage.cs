using System;
using System.Collections.Generic;

namespace Autumn.API.Models
{
    public partial class BookPage
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long BookId { get; set; }
        public short Sequence { get; set; }

        public Book Book { get; set; }
    }
}
