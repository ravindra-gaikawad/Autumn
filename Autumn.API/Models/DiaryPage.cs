using System;
using System.Collections.Generic;

namespace Autumn.API.Models
{
    public partial class DiaryPage : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long DiaryId { get; set; }
        public short Sequence { get; set; }
        public DateTime ForDate { get; set; }

        public Diary Diary { get; set; }
    }
}
