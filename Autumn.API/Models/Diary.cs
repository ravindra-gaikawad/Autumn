﻿using System;
using System.Collections.Generic;

namespace Autumn.API.Models
{
    public partial class Diary : BaseEntity
    {
        public Diary()
        {
            DiaryPage = new HashSet<DiaryPage>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int PageCount { get; set; }
        public bool IsPublic { get; set; }
        public long AuthorId { get; set; }

        public User Author { get; set; }
        public ICollection<DiaryPage> DiaryPage { get; set; }
    }
}
