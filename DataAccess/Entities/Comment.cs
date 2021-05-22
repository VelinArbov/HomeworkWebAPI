using System;
using System.Collections.Generic;
using System.Text;

namespace EndavaWebAPI.DataAccess.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        //public AppUser? Author { get; set; }

        public DateTime CreatedOn => DateTime.UtcNow;

        public Book? Book { get; set; }

        public bool IsApproved { get; set; }
    }
}
