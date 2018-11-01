namespace Autumn.API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class User : BaseEntity
    {
        public User()
        {
            this.Book = new HashSet<Book>();
            this.Diary = new HashSet<Diary>();
            this.Episode = new HashSet<Episode>();
            this.Wish = new HashSet<Wish>();
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string EmailId { get; set; }

        public ICollection<Book> Book { get; set; }

        public ICollection<Diary> Diary { get; set; }

        public ICollection<Episode> Episode { get; set; }

        public ICollection<Wish> Wish { get; set; }
    }
}
