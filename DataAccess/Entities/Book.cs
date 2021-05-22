using System;

namespace EndavaWebAPI.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }

        public bool IsTaken { get; set; }
        public DateTime TakedOn { get; set; }



    }
}
