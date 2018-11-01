namespace Autumn.API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Book : BaseEntity
    {
        public Book()
        {
            this.BookPage = new HashSet<BookPage>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int PageCount { get; set; }

        public byte ChapterCount { get; set; }

        public bool IsPublic { get; set; }

        public long AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<BookPage> BookPage { get; set; }
    }
}
