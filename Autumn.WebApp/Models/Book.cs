namespace Autumn.WebApp.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Book : BaseEntity
    {
        public Book()
        {
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int PageCount { get; set; }

        public byte ChapterCount { get; set; }

        public bool IsPublic { get; set; }
    }
}
