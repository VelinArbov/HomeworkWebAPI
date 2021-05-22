using System;
using System.Collections.Generic;
using System.Text;

namespace EndavaWebAPI.DataAccess.Entities
{
    public class Author
    {
        public Author(ICollection<Book> books)
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
