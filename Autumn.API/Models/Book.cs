using System;
using System.Collections.Generic;

namespace Autumn.API.Models
{
    public partial class Book
    {
        public Book()
        {
            BookPage = new HashSet<BookPage>();
        }

        public long Id { get; set; }
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
