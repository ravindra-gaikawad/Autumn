using System;
using System.Collections.Generic;

namespace Autumn.API.Models
{
    public partial class User
    {
        public User()
        {
            Book = new HashSet<Book>();
            Diary = new HashSet<Diary>();
            Episode = new HashSet<Episode>();
            Wish = new HashSet<Wish>();
        }

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailId { get; set; }

        public ICollection<Book> Book { get; set; }
        public ICollection<Diary> Diary { get; set; }
        public ICollection<Episode> Episode { get; set; }
        public ICollection<Wish> Wish { get; set; }
    }
}
